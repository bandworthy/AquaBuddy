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
    class routineObj
    {
        private musicObj music { get; set; }
        private exerciseObj exercises { get; set; }

        public routineObj(musicObj mUsic,exerciseObj eXercise)
        {
            this.music = mUsic;
            this.exercises = eXercise;
        }
    }
}