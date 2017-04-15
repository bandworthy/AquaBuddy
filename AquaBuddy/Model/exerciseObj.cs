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

        //private enum intensity { get;set;} // need to make it yet
        //private enum type {get;set;} // need to make it yet

            // needs to be limited to 140char 
        private String description { get; set; }


        public exerciseObj ( String name, int duration, String description)
        {
            this.name = name;
            this.duration = duration;
            this.description = description;
        }

    }
}