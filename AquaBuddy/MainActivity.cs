﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
//using System;

namespace AquaBuddy
{
    [Activity(Label = "AquaBuddy", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Get our button from the layout resource
            //and attach an event to it

            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button text2speechbutton = FindViewById<Button>(Resource.Id.Text2SpeechTest);
            Button testmusic = FindViewById<Button>(Resource.Id.testMusic);

            var label = FindViewById<TextView>(Resource.Id.textView1);


            button.Click += delegate
            {
                count++;
                label.Text = $"You clicked {count} times";
            };

            //switching to text to speech test
            text2speechbutton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TextToSpeechActivity));
                StartActivity(intent);
            };

            //switch to music test
            testmusic.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(MusicTestActivity));
                StartActivity(intent);
            };

        }
    }
}

