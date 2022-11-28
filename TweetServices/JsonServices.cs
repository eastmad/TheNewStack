using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BackEnd
{
    public class JsonServices
    {
        const string BASEDIRECTORY = "/Users/eastmad/Projects/TheNewStack/";
        const string IDENTITYFILENAME = "identities.json";


        public static void WriteTweetsToFile(List<Tweet> tweets, Identity id)
        {
            WriteToFile(tweets, id.StoreFile);
        }

        private static void WriteToFile<T>(List<T> list, string filename)
        {    
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize<List<T>>(list, options);
            File.WriteAllText(Path.Combine(BASEDIRECTORY, filename), jsonString);
        }

        public static List<Tweet> ReadTweetsFromFile(Identity id)
        {
            return ReadFromFile<Tweet>(id.StoreFile);
        }

        public static List<Identity> ReadIdentitesFromFile()
        {
            return ReadFromFile<Identity>(IDENTITYFILENAME);
        }

        private static List<T> ReadFromFile<T>(string filename)
        {
            List<T>? list = null;

            filename = Path.Combine(BASEDIRECTORY, filename);

            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                list = JsonSerializer.Deserialize<List<T>>(jsonString);
            }
            else Console.WriteLine("No existing file found for " + filename);

            return list ?? new List<T>();
        }
    }
}

