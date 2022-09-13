using LiveCards.Models;
using LiveCards.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiveCards.Web.Models
{
    public class SettingsManager
    {
        public static string GetSetting(ApplicationDbContext context, SettingsKeys key)
        {
            var setting = context.Settings.Find(key.ToString());
            var value = setting == null ? null : string.IsNullOrEmpty(setting.KVal) ? setting.DefaultValue : setting.KVal;
            return value;
        }


        public static string SetSetting(ApplicationDbContext context, SettingsKeys key, string value)
        {
            var setting = context.Settings.Find(key.ToString());

            if (setting == null)
            {
                setting = new Setting()
                {
                    KKey = key.ToString(),
                    Title = key.ToString(),
                    KVal = value,
                    DefaultValue = " ",
                    Group = "",
                };
                context.Settings.Add(setting);
            }
            else
            {
                setting.KVal = value;
                context.Settings.Update(setting);
            }

            context.SaveChanges();
            return setting.KVal;
        }
    }
}