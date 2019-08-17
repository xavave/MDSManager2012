// Type: Common.Tools
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using System.Xml;
using Common.MDSService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Common.Exceptions;
using Common.Model;

namespace Common
{
    public static class Tools
    {
        public static void OpenUrl(string url)
        {
            new Process()
            {
                StartInfo =
                {
                    FileName = url
                }
            }.Start();
        }

        public static List<CustomEntity> FilterEntities(List<CustomEntity> listTofilter, string filterText)
        {
            List<CustomEntity> list = listTofilter;
            if (listTofilter != null && !string.IsNullOrEmpty(filterText))
            {
                string[] searchStrings = filterText.ToLower().Split(new char[1]
        {
          ';'
        }, StringSplitOptions.RemoveEmptyEntries);
                StringComparison comp = StringComparison.CurrentCulture;
                list = Enumerable.ToList<CustomEntity>(Enumerable.Where<CustomEntity>((IEnumerable<CustomEntity>)listTofilter, (Func<CustomEntity, bool>)(line => Enumerable.All<string>((IEnumerable<string>)searchStrings, (Func<string, bool>)(item => line.Name.ToLower().IndexOf(item, comp) >= 0)))));
            }
            return list;
        }

        public static List<Identifier> FilterIdentifier(List<Identifier> listTofilter, string filterText)
        {
            List<Identifier> list = listTofilter;
            if (listTofilter != null && !string.IsNullOrEmpty(filterText))
            {
                string[] searchStrings = filterText.ToLower().Split(new char[1]
        {
          ';'
        }, StringSplitOptions.RemoveEmptyEntries);
                StringComparison comp = StringComparison.CurrentCulture;
                list = Enumerable.ToList<Identifier>(Enumerable.Where<Identifier>((IEnumerable<Identifier>)listTofilter, (Func<Identifier, bool>)(line => Enumerable.All<string>((IEnumerable<string>)searchStrings, (Func<string, bool>)(item => line.Name.ToLower().IndexOf(item, comp) >= 0)))));
            }
            return list;
        }

        public static TCollection ConvertAll<TInput, TOutput, TCollection>(this IEnumerable<TInput> input, Converter<TInput, TOutput> convert) where TCollection : IList<TOutput>, new()
        {
            TCollection collection = new TCollection();
            foreach (TInput input1 in input)
                collection.Add(convert(input1));
            return collection;
        }



        public static void SerializeSecurityXml(string fileName, object toSerialize)
        {
            if (toSerialize == null)
                throw new ArgumentNullException("toSerialize");

     
            // Serialization.
            var serializer = new XmlSerializer(typeof(SecurityInformation));

            using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var xmlWriter = XmlDictionaryWriter.CreateBinaryWriter(fs);

                // Serializes the security information.
                serializer.Serialize(xmlWriter, toSerialize);
                fs.Flush();
            }
        }

        public static T DeserializeFile<T>(string fullFilePath)
        {
            if (String.IsNullOrEmpty(fullFilePath))
                throw new ArgumentNullException("fullFilePath");


            if (!File.Exists(fullFilePath))
                throw new ArgumentException("The file does not exist. " + fullFilePath);

            var serializer = new XmlSerializer(typeof(T));
            using (var fileStream = new FileStream(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlDictionaryReader xmlReader = XmlDictionaryReader.CreateBinaryReader(fileStream, XmlDictionaryReaderQuotas.Max);

                // Derializes the XML
                return (T)serializer.Deserialize(xmlReader);
            }

        }

        public static string Encrypt(string strPassword)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(strPassword);
                for (int index = 0; index < bytes.Length; ++index)
                    bytes[index] = Convert.ToByte(Convert.ToInt64(bytes[index]) + 4L);
                return Encoding.ASCII.GetString(bytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string Decrypt(string strPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(strPassword))
                    return string.Empty;
                byte[] bytes = Encoding.ASCII.GetBytes(strPassword);
                for (int index = 0; index < bytes.Length; ++index)
                    bytes[index] = Convert.ToByte(Convert.ToInt64(bytes[index]) - 4L);
                return Encoding.ASCII.GetString(bytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string HandleErrors(OperationResult result, bool throwIfError = false)
        {
            if (result.Errors.Count > 0)
            {
                string str = string.Empty;
                foreach (Error error in result.Errors)
                    str = str + error.Code + "; " + error.Context + "; " + error.Description + Environment.NewLine;
                if (throwIfError)
                    throw new MDSManagerException(str);
                else
                    return str;

            }
            return String.Empty;
        }

        public static string HandleErrors(Exception exception, bool throwIfError = false)
        {
            if (exception != null)
            {
                if (throwIfError)
                    throw new MDSManagerException(exception.Message);
                
            }
            return String.Empty;
        }
    }
}
