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
    class exerciseObj
    {
        private String name { get; set; }
        private int duration { get; set; }

        private exerciseIntensity intensity { get; }
        private exerciseType type { get; }

            // needs to be limited to 140char 
        private String description { get; set; }


        public exerciseObj ( String name, int duration, String description)
        {
            this.name = name;
            this.duration = duration;
            this.description = description;
        }

        enum exerciseType
        {
            Cardio,
            Endurance,
            Resistance,
            Abdominals,
            Toning
        }

        enum exerciseIntensity
        {
            Low,
            Medium,
            High
        }

       

    }
}