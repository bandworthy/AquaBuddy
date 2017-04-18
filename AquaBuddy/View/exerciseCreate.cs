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
    [Activity(Label = "Add Exercise")]
    public class exerciseCreate : Activity
    {
        private NumberPicker.IOnValueChangeListener _listener;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            NumberPicker numberpicker;
            TextView duration = FindViewById<TextView>(Resource.Id.textViewDuration);

            SetContentView(Resource.Layout.exerciseCreate);

            numberpicker = (NumberPicker)FindViewById(Resource.Id.numberpickerDuration);
            //this needs to be changed to an object so i can have a settings default value edited by user
            numberpicker.MaxValue = 120;
            numberpicker.MinValue = 10;
            numberpicker.Value = 20;
            numberpicker.SetOnValueChangedListener(_listener);

            _listener.OnValueChange(numberpicker, numberpicker.Value, numberpicker.Value);

            

        }

        
        
    }
}
