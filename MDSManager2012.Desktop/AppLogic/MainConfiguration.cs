using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;
using MDSManager2012.Desktop.AppLogic;

namespace MDSManager2012.Desktop
{
    [Serializable]
    public class MainConfiguration
    {
        public Guid ConfigGuid { get; set; }

        public List<ConfigValue> ConfigValues { get; set; }

        public static string ConfigFilePath { get; set; }

        public MainConfiguration(string configFilePath)
        {
            ConfigFilePath = configFilePath;
            ConfigValues = new List<ConfigValue>();
        }


        public MainConfiguration()
        {
            //a parameterless constructor is required by the serializer.
            ConfigValues = new List<ConfigValue>();
        }

        public MainConfiguration(Guid configGuid, List<ConfigValue> configValues)
        {
            this.ConfigGuid = configGuid;
            this.ConfigValues = configValues;
        }

        public MainConfiguration SaveConfig()
        {
            var configPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ApplicationConstants.DefaultConfigurationFileName);
            return SaveConfig(configPath);
        }

        private MainConfiguration SaveConfig(string filePath)
        {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(MainConfiguration));
                StreamWriter text = File.CreateText(filePath);
                xmlSerializer.Serialize((TextWriter)text, this);
                ((TextWriter)text).Flush();
                text.Close();
                return this;
           
        }

        public static string FormatPath(string path1, string path2)
        {
            return Path.Combine(path1.EndsWith("\\") ? path1 : path1 + "\\", path2.StartsWith("\\") ? path2.Remove(0, 1) : path2);
        }

        public static string GetConfigString(string file)
        {
            try
            {
                string str1 = string.Empty;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(MainConfiguration));
                StreamReader streamReader = File.OpenText(file);
                string str2 = streamReader.ReadToEnd();
                streamReader.Close();
                return str2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static MainConfiguration GetConfig()
        {
            var configPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), ApplicationConstants.DefaultConfigurationFileName);
            return GetConfig(configPath);
        }

        public static MainConfiguration GetConfig(string file)
        {
            if (!File.Exists(file))
            {
                return new MainConfiguration(file).SaveConfig();
            }
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(MainConfiguration));
                StreamReader streamReader = File.OpenText(file);
                MainConfiguration mainConfiguration = xmlSerializer.Deserialize((TextReader)streamReader) as MainConfiguration;
                streamReader.Close();
                return mainConfiguration;
           
        }

        //private static MainConfiguration GetConfig(StringBuilder XmlConfigurationString)
        //{
        //    try
        //    {
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(MainConfiguration));
        //        StringReader stringReader = new StringReader(((object)XmlConfigurationString).ToString());
        //        XmlTextReader xmlTextReader = new XmlTextReader((TextReader)stringReader);
        //        MainConfiguration mainConfiguration = xmlSerializer.Deserialize((XmlReader)xmlTextReader) as MainConfiguration;
        //        xmlTextReader.Close();
        //        stringReader.Close();
        //        return mainConfiguration;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public static List<ConfigValue> GetConfigValues()
        {
           return  MainConfiguration.GetConfig().ConfigValues;          
        }

        public void SetConfig(string configname, string domain, string username, string password, Uri endpoint, BindingType bindingType)
        {
           
                DeleteConfigValue(configname);
                ConfigValues.Add(new ConfigValue(configname, domain, username, password, endpoint, bindingType));
                SaveConfig();
           
        }

        public void DeleteConfigValue(string configname)
        {
            ConfigValue configValue = ConfigValues.FirstOrDefault(t => t.ConfigName == configname);
            if (configValue != null)
                ConfigValues.Remove(configValue);
            SaveConfig();
        }

        
    }
}
