using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Speech.Tts;

namespace AquaBuddy
{
    [Activity(Label = "TexttoSpeechTest")]
    public class TextToSpeechActivity : Activity, TextToSpeech.IOnInitListener
    {
        TextToSpeech textToSpeech;
        Context context;
        private readonly int MyCheckCode = 101, NeedLang = 103;
        Java.Util.Locale lang;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Text2SpeechLO);


            //is this another way to declare with a generic?
            var spinLanguages = FindViewById<Spinner>(Resource.Id.spinLanguage);
            var seekSpeed = FindViewById<SeekBar>(Resource.Id.seekSpeed);
            var seekPitch = FindViewById<SeekBar>(Resource.Id.seekPitch);


            Button button = FindViewById<Button>(Resource.Id.buttonSayIt);
            EditText edittext = FindViewById<EditText>(Resource.Id.editText1);

            //setup pitch and rate
            seekSpeed.Progress = seekPitch.Progress = 127;
            //txtSpeedVal.Text = txtPitchVal.Text = "0.5";

            //get the context - easiest way to obtain it from an on screen gadget
            context = button.Context;

            //setup the TextToSpeech object
            // third parameter is the speech engine to use
            textToSpeech = new TextToSpeech(this, this, "com.google.android.tts");


            //setup language spinner set top option as default
            var langAvailable = new List<string> { "Default" };

            //spinner needs to only contain languages supported by the tts and ignore the rest
            var localesAvailable = Java.Util.Locale.GetAvailableLocales().ToList();

            foreach (var locale in localesAvailable)
            {
                var res = textToSpeech.IsLanguageAvailable(locale);
                switch (res)
                {
                    case LanguageAvailableResult.Available:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                    case LanguageAvailableResult.CountryAvailable:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                    case LanguageAvailableResult.CountryVarAvailable:
                        langAvailable.Add(locale.DisplayLanguage);
                        break;
                }
            }

            langAvailable = langAvailable.OrderBy(t => t).Distinct().ToList();

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, langAvailable);
            spinLanguages.Adapter = adapter;

            //setup speech to use default language
            // if language is not available , then default lang is used.

            lang = Java.Util.Locale.Default;
            textToSpeech.SetLanguage(lang);

            //set the speed and pitch
            textToSpeech.SetPitch(1.5f);
            textToSpeech.SetSpeechRate(.8f);

            //connect up the events
            button.Click += delegate
            {
                // if there is nothing to say, don't say it
                if (!string.IsNullOrEmpty(edittext.Text))
                {
                    textToSpeech.Speak(edittext.Text, QueueMode.Flush, null, null);
                }
            };

            //sliders

            seekPitch.StopTrackingTouch += (object sender, SeekBar.StopTrackingTouchEventArgs e) =>
            {
                var seek = sender as SeekBar;
                var progress = seek.Progress / 255f;
                textToSpeech.SetSpeechRate(progress);
                //text display meant to go here but not bothering
            };

            spinLanguages.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
            {
                lang = Java.Util.Locale.GetAvailableLocales().FirstOrDefault(t => t.DisplayLanguage == langAvailable[(int)e.Id]);
                // create intent to check the TTS has this language installed
                var checkTTSIntent = new Intent();
                checkTTSIntent.SetAction(TextToSpeech.Engine.ActionCheckTtsData);
                StartActivityForResult(checkTTSIntent, NeedLang);
            };

        }

        void TextToSpeech.IOnInitListener.OnInit([GeneratedEnum] OperationResult status)
        {
            // if we get an error, default to the default language
            if (status == OperationResult.Error)
                textToSpeech.SetLanguage(Java.Util.Locale.Default);
            // if the listener is ok, set the lang
            if (status == OperationResult.Success)
                textToSpeech.SetLanguage(lang);
        }
        protected override void OnActivityResult(int req, Result res, Intent data)
        {
            if (req == NeedLang)
            {
                // we need a new language installed
                var installTTS = new Intent();
                installTTS.SetAction(TextToSpeech.Engine.ActionInstallTtsData);
                StartActivity(installTTS);
            }
        }

    }
}