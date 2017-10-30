using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WhatToCook
{
    public class DataLayer
    {
        SQLiteConnection conn;
        public DataLayer()
        {
            this.InitDatabase();
        }
        private void InitDatabase()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(folder, "foods.db");
            if (File.Exists(path))
            {
                conn = new SQLiteConnection(path);
                return;
            }
            conn = new SQLiteConnection(path);
            conn.CreateTable<Foods>();
        }
        public bool AddFood(string foodName)
        {
            try
            {
                if (conn == null) return false;
                //var res = conn.Execute($"INSERT INTO FOODS(FoodName) VALUES('{foodName}')");
                var res = conn.Table<Foods>().Append(new Foods() { FoodName = foodName });
                conn.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveFood(string foodName)
        {
            try
            {
                if (conn == null) return false;
                //var res = conn.Execute($"DELETE FROM FOODS WHERE FoodName = '{foodName}'");
                var res = conn.Table<Foods>().Delete(x => x.FoodName == foodName);
                conn.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Foods> GetAllFoods()
        {
            return conn.Table<Foods>().ToList();
        }
    }
}