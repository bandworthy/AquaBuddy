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

using AquaBuddy.Controller;

namespace AquaBuddy
{
    [Activity(Label = "MusicTestActivity")]
    public class MusicTestActivity : Activity
    {

        //private AudioService audio;
        AudioService audio = new AudioService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MusicTestLO);
            // Create your application here
            audio.PlayAudioFile("jib.mp3");
        }
    }
}