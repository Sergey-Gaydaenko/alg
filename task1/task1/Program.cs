using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace task1
{
    class Program
    {

        private static void Main(string[] args)
        {
            string message = "catsanddogs";
            Console.WriteLine(WordSegmentation(message, GetDictionary()));

            Console.ReadLine();
        }

        public static string WordSegmentation(string message, HashSet<string> dictionary)
        {
            string result = String.Empty;

            for (int i = 1; i < message.Length; i++)
            {
                string prefix = message.Substring(0, i);

                if (dictionary.Contains(prefix))
                {
                    string suffix = message.Substring(i);
                    result += prefix + " ";

                    if (dictionary.Contains(suffix))
                    {
                        return result + suffix;
                    }
                    return result + WordSegmentation(suffix, dictionary);
                }
            }
            return result;
        }

        public static HashSet<string> GetDictionary()
        {
            HashSet<string> dictionary = new HashSet<string>();
            var path = "dict_en.txt";
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                dictionary.Add(line);
            }
            return dictionary;
        }
    }
}
