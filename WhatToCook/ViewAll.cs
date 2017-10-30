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

namespace WhatToCook
{
    [Activity(Label = "كل الأكلات")]
    public class ViewAll : Activity
    {
        TextView txt;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view);
            txt = FindViewById<TextView>(Resource.Id.txt);
            var foods = this.Intent.GetStringExtra("Foods");
            if (string.IsNullOrEmpty(foods)) return;
            txt.Text = foods;
        }


        #region Events
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Main);
        } 
        #endregion
    }
}