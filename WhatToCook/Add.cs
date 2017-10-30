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
    [Activity(Label = "Add")]
    public class Add : Activity
    {
        Button btnAdd;
        EditText txtAdd, txtViewAll;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Add);

            #region Find Controls
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            txtAdd = FindViewById<EditText>(Resource.Id.txtAdd);
            txtViewAll = FindViewById<EditText>(Resource.Id.txtViewAll);
            #endregion

            txtViewAll.Text = ShowAllFoods();

            #region Attach Events
            btnAdd.Click += BtnAdd_Click;
            #endregion
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text == "") return;
            var dl = new DataLayer();
            if (dl.AddFood(txtAdd.Text))
            {
                Toast.MakeText(this.ApplicationContext, "تم الحفظ", ToastLength.Short).Show();
                txtAdd.Text = "";
                txtViewAll.Text = ShowAllFoods();
                return;
            }
            Toast.MakeText(this.ApplicationContext, "فشل الحفظ", ToastLength.Short).Show();
        }

        private string ShowAllFoods()
        {
            var content = string.Empty;
            new DataLayer().GetAllFoods().ForEach(x =>
            {
                content += x.FoodName + "\n";
            });
            return content;
        }
    }
}