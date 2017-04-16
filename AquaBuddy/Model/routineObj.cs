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
    class RoutineObj
    {
        private MusicObj Music { get; set; }
        private ExerciseObj Exercises { get; set; }

        public RoutineObj(MusicObj mUsic,ExerciseObj eXercise)
        {
            this.Music = mUsic;
            this.Exercises = eXercise;
        }
    }
}