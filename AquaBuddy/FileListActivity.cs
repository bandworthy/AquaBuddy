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
using Android.Media;

namespace AquaBuddy
{

    

    [Activity(Label = "File List Test")]
    public class fileListActivity : ListActivity
    {

        string[] fileList;
        List<string> newlist = new List<string>();
        //AudioService audio = new AudioService();
        protected MediaPlayer player = new MediaPlayer();
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //since the default listview is built in you dont assign a custom view
            //SetContentView(Resource.Layout.FileListLO);

            // Create your application here
            //string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).ToString();
            try
            {
                //var musicFiles = Directory.EnumerateFiles(Android.OS.Environment.DirectoryMusic, "*.mp3");
                var musicFiles = Directory.EnumerateFiles("/storage/emulated/0/Music/", "*.mp3");
                fileList = musicFiles.ToArray();

                //or do a foreach var
                foreach (var b in fileList)
                {
                    //Toast.MakeText(this, b, ToastLength.Long).Show();
                    //removing unwanted text from each song name
                    // adding to new list which will become the display array
 
                    string c = b;
                    c = b.Replace(".mp3", "");
                    c = c.Replace("/storage/emulated/0/Music/", "");

                    newlist.Add(c);
                }

                newlist.ToArray();


                ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, newlist);



            }
            catch (DirectoryNotFoundException e)
            {
                // no directory
                Toast.MakeText(this, "No Music Folder", ToastLength.Long).Show();
            }

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = newlist[position];
            Toast.MakeText(this, t, ToastLength.Short).Show();
            //audio.PlayAudioFile("/storage/emulated/0/Music/"+t+".mp3");
            StartPlayer("/storage/emulated/0/Music/" + t + ".mp3");
        }

        //basic play selected song
        public void StartPlayer(String filePath)
        {
            
            if (player == null)
            {
                player = new MediaPlayer();
            }
            else
            {
            player.Reset();
            player.SetDataSource(filePath);
            player.Prepare();
            player.Start();
            } 

        }
    }
}
