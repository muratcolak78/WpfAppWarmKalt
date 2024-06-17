using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace WpfAppWarmKalt
{
    public static class JSONHelper
    {
        public static void saveAsJson<T>(List<T> list, string path)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Newtonsoft.Json.Formatting.Indented
                };

                string jsonString = JsonConvert.SerializeObject(list, settings);
                File.WriteAllText(path, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving data to {path}: {ex.Message}");
            }
        }

        public static List<T> readFromJson<T>(string path)
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                List<T> list = JsonConvert.DeserializeObject<List<T>>(jsonString, settings);
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while reading data from {path}: {ex.Message}");
                return null;
            }
        }
    }
}
