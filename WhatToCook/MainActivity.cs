using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Xml;
using System;
using Android.Content;
using SQLite;
using System.Collections.Generic;

namespace WhatToCook
{
    [Activity(Label = "أطبخ إيه؟", MainLauncher = true, Icon ="@drawable/icon")]
    public class MainActivity : Activity
    {
        XmlDocument doc;
        Button btnWhatToCook, btnViewAll, btnAddNew;
        DataLayer dl;
        List<Foods> foods;
        #region Life
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            #region Init Database
            dl = new DataLayer();
            #endregion

            #region Load files
            LoadFoods();
            #endregion

            #region Init Buttons
            btnWhatToCook = FindViewById<Button>(Resource.Id.btnCook);
            btnAddNew = FindViewById<Button>(Resource.Id.btnAddNew);
            btnViewAll = FindViewById<Button>(Resource.Id.btnViewAll);
            #endregion

            #region Linking Events
            btnWhatToCook.Click += BtnWhatToCook_Click;
            btnAddNew.Click += BtnAddNew_Click;
            btnViewAll.Click += BtnViewAll_Click;
            #endregion
        }

        
        #endregion
        #region Events
        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ViewAll));
            intent.PutExtra("Foods", GetAllFoods());
            StartActivity(intent);
        }
        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            
        }
        private void BtnWhatToCook_Click(object sender, System.EventArgs e)
        {
            var length = doc.ChildNodes[1].ChildNodes.Count;

            var index = new Random().Next(length - 1);
            var text = doc.ChildNodes[1].ChildNodes[index].InnerText;

            Toast.MakeText(this.ApplicationContext, text, ToastLength.Long).Show();
        }
        #endregion
        #region Methods
        private void SaveFoods()
        {
            //System.IO.File.WriteAllText("")
            doc.Save(("foods.xml"));
            LoadFoods();
        }
        private void LoadFoods()
        {
            //string content;
            //using (StreamReader sr = new StreamReader(Assets.Open("foods.xml")))
            //{
            //    content = sr.ReadToEnd();
            //}

            //doc = new XmlDocument();
            //doc.LoadXml(content);
            foods = dl.GetAllFoods();
        }
        //private string GetAllFoods()
        //{
        //    var content = string.Empty;
        //    foreach (XmlNode node in doc.ChildNodes[1].ChildNodes)
        //    {
        //        content += node.InnerText + "\n";
        //    }
        //    return content;
        //}
        #endregion
    }
}

