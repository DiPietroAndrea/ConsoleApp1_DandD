using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AD.Helper
{
    public static class Extension
    {
        #region --> XML

        /// <summary>
            /// Serializza una lista di oggetti in XML
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="anyobjects">
            /// Elenco da serializzare
            /// </param>
            /// <returns>
            /// Restituisce una stringa xml
            /// </returns>

        public static string ToXML<T>(this T anyobjects)
        {
            XmlSerializer serializer1 = new XmlSerializer(typeof(T));
            using (StringWriter sw = new StringWriter())
            {
                    serializer1.Serialize(sw, anyobjects);
                    return sw.ToString();
            };
        }

        /// <summary>
            /// Serializza una lista di oggetti in XML in un file.txt
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="anyobject">
            /// Elenco da scrivere sul file.txt
            /// </param>
            /// <param name="filepath">
            /// Path nel quale si trova il file.txt
            /// </param>
            /// <returns>
            /// Restituisce un file.txt con dentro scritto una stringa XML
            /// </returns>

        public static void ToXMLFile<T>(this T anyobject, string filepath)
        {
            var xml = anyobject.ToXML();
            if (File.Exists(filepath))
                 File.Delete(filepath);
                 File.WriteAllText(filepath, xml);
        }

        /// <summary>
            /// Deserializza una lista di oggetti in XML
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="xml">
            /// Elenco degli oggetti da deserializzare
            /// </param>
            /// <returns>
            /// Restituisce l'elenco deserializzato
            /// </returns>
            /// <exception cref="ArgumentNullException">
            /// Se la stringa di oggetti è vuota o nulla restituisce un'eccezione
            /// </exception>

        public static T? FromXML<T>(this string xml)
        {
            if (string.IsNullOrEmpty(xml)) throw new ArgumentNullException("xml");
            XmlSerializer serializer1 = new XmlSerializer(typeof(T));
            using (StringReader sw = new StringReader(xml))
            {
                var r = serializer1.Deserialize(sw);
                if (r == null) return default(T);
                return (T)r;
            };
        }

        /// <summary>
            /// Deserializza una lista di oggetti in xml da un file.txt
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="filepath">
            /// Path dove è contenuto il file.txt
            /// </param>
            /// <returns>
            /// Restituisce un file.txt con dentro una stringa</returns>

        public static T? FromXMLFile<T>(this string filepath)
        {
            if (!File.Exists(filepath)) throw new Exception($"{filepath} non esiste.");
            var xml = File.ReadAllText(filepath);
            return FromXML<T>(xml);
        }
        
        #endregion

        #region --> CSV

        /// <summary>
            /// Serializza una lista di oggetti in CSV
            /// </summary>
            /// <typeparam name="T">di tipo generico
            /// </typeparam>
            /// <param name="anyobject">elenco da serializzare
            /// </param>
            /// <param name="Delimiter">
            /// Delimitatore ;
            /// </param>
            /// <returns>
            /// Restituisce una stringa CSV
            /// </returns>

        public static string ToCSV<T>(this IEnumerable<T> anyobject)
        {
            return anyobject.ToCSV(";");
        }

        public static string ToCSV<T>(this IEnumerable<T> anyobject, string Delimiter)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture);
            {
                Delimiter = ";";
            };

            using (StringWriter sw = new StringWriter())
            {
                using (CsvWriter csv = new CsvWriter(sw, csvConfig))
                {
                    csv.WriteRecords(anyobject);
                    return sw.ToString();
                }
            }
        }

        /// <summary>
            /// Serializza una lista di oggetti in CSV in un file.txt
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="anyobject">
            /// Elenco da serializzare
            /// </param>
            /// <param name="Delimiter">
            /// Delimitatore ;
            /// </param>
            /// <returns>
            /// Restituisce all'interno del file.txt una stringa CSV
            /// </returns>

        public static void ToCSVFile<T>(this IEnumerable<T> anyobject, string filepath)
        {
            anyobject.ToCSV(";");
        }

        public static void ToCSVFile<T>(this IEnumerable<T> anyobject, string Delimiter, string filepath)
        {
            var csv = anyobject.ToCSV(Delimiter);
            if (File.Exists(filepath))
                File.Delete(filepath);
            File.WriteAllText(filepath, csv);
        }


        /// <summary>
            /// Deserializza una lista di oggetti csv
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="anyobject">
            /// Lista di oggetti da deserializzare
            /// </param>

        public static IEnumerable<T> FromCSV<T>(this string anyobject)
        {
            return anyobject.FromCSV<T>(";");
        }

        public static IEnumerable<T> FromCSV<T>(this string anyobject, string delimiter)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture);
            {
                delimiter = ";";
            }

            if (string.IsNullOrEmpty(anyobject)) throw new ArgumentNullException("csv");

            using (StringReader sr = new StringReader(anyobject))
            using (CsvReader csv = new CsvReader(sr, csvConfig))
            {
                var c = csv.GetRecords<T>();
                return c.ToArray();
            }
        }

        /// <summary>
            /// Deserilizza un lista di oggetti csv in un file.txt
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="anyobject">
            /// Lista di oggetti da deserializzare
            /// </param>
            /// <param name="filePath">
            /// path del file.txt
            /// </param>

        public static IEnumerable<T> FromCSVFile<T>(this string filepath)
        {
            return filepath.FromCSVFile<T>(";");
        }

        public static IEnumerable<T> FromCSVFile<T>(this string filepath, string delimiter)
        {
            if (!File.Exists(filepath)) throw new Exception($"{filepath} non esiste.");
            var c = File.ReadAllText(filepath);
            return FromCSV<T>(c);
        }

        #endregion

        #region --> JSON

        /// <summary>
            /// Serializza una lista di oggetti in Json
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="anyobject">
            /// Elenco da serializzare
            /// </param>
            /// <returns>
            /// Restituisce l'elenco in formato Json
            /// </returns>

        public static string ToJSON<T>(this T anyobject)
        {
            string json = JsonConvert.SerializeObject(anyobject);
            return json;
        }

        /// <summary>
            /// Serializza una lista di oggeti in Json in un file.txt
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="anyobject">
            /// Elenco da serializzare all'intenro del file
            /// </param>
            /// <param name="filepath">
            /// Percorso del file.txt
            /// </param>
            /// <returns>
            /// Restituisce l'elenco serializzato in un file.txt  
            /// </returns>

        public static string ToJSONFile<T>(this T anyobject, string filepath)
        {
            var json = anyobject.ToJSON();
            if (File.Exists(filepath))
                File.Delete(filepath);
            File.WriteAllText(filepath, json.ToString());
            return json.ToString();
        }

        /// <summary>
            /// Deserializza una lista di oggetti in json
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="json">
            /// Elenco da deserializzare</param>
            /// <returns>
            /// Restituisce una stringa</returns>
            /// <exception cref="ArgumentNullException">
            /// Se la stringa è nulla o vuota restituisce un eccezione
            /// </exception>

        public static T? FromJSON<T>(this string json)
        {
            if (string.IsNullOrEmpty(json)) throw new ArgumentNullException("json");
            using (StringReader sr = new StringReader(json))
            {
                var j = JsonConvert.DeserializeObject<T>(json);
                if (j == null) return default(T);
                return (T)j;
            }
        }

        /// <summary>
            /// Deserializza una lista di oggetti in json in un file.txt
            /// </summary>
            /// <typeparam name="T">
            /// di tipo generico
            /// </typeparam>
            /// <param name="filepath">
            /// path dove si trova il file.txt
            /// </param>
            /// <returns>
            /// Restituisce una stringa dentro un file.txt
            /// </returns>

        public static T? FromJSONFile<T>(this string filepath)
        {
            if (!File.Exists(filepath)) throw new Exception($"{filepath} non esiste.");
            var js = File.ReadAllText(filepath);
            return FromJSON<T>(js);
        }
        #endregion
    }
}
