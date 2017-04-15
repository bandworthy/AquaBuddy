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

namespace AquaBuddy.Model
{
    class musicObj
    {
        private String musicDirectory { get; set; }
        private String[] musicFileNames { get; set; }

        public musicObj(String musicdirectory,String[] musicfilenames)
        {
            this.musicDirectory = musicdirectory;
            this.musicFileNames = musicfilenames;
        }
    }
}