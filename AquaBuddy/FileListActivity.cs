using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AquaBuddy
{
    [Activity(Label = "File List Test")]
    public class fileListActivity : Activity
    {
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            SetContentView(Resource.Layout.FileListLO);

            // Create your application here
            //string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).ToString();
            try
            {
                //var musicFiles = Directory.EnumerateFiles(Android.OS.Environment.DirectoryMusic, "*.mp3");
                var musicFiles = Directory.EnumerateFiles("/storage/emulated/0/Music/","*.mp3");
                string[] fileList = musicFiles.ToArray();
            //or do a foreach var

                foreach (var b in musicFiles)
                {
                    Toast.MakeText(this, b, ToastLength.Long).Show();
                }
            }
            catch(DirectoryNotFoundException e)
            {
                // no directory
                Toast.MakeText(this, "No Music Folder", ToastLength.Long).Show();
            }

        }
    }
}
