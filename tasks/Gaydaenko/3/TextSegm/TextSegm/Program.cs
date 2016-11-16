using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSegm
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter the text: ");
            string text = Console.ReadLine();

            Console.Write("Enter the line width: ");
            string lineWidth = Console.ReadLine();

            if (text != null)
            {
                string[] words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int width;
                int.TryParse(lineWidth, out width);

                var result = FullJustify(words, width);
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadLine();
        }

        public static IList FullJustify(string[] words, int maxWidth)
        {
            var res = new List<string>();
            var oneline = new List<string>();
            var count = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (count + oneline.Count + words[i].Length > maxWidth)
                {
                    var stringbuilder = new StringBuilder();
                    var leftSpaces = maxWidth - count;
                    for (int j = 0; j < oneline.Count; j++)
                    {
                        stringbuilder.Append(oneline[j]);
                        if (j == oneline.Count - 1)
                        {
                            continue;
                        }
                        var spaceToAdd = leftSpaces / (oneline.Count - 1) +
                                         (leftSpaces % (oneline.Count - 1) > j ? 1 : 0);
                        stringbuilder.Append(' ', spaceToAdd);
                    }

                    res.Add(stringbuilder.ToString().PadRight(maxWidth));

                    count = 0;
                    oneline.Clear();
                }

                count += words[i].Length;
                oneline.Add(words[i]);
            }

            if (oneline.Any())
            {
                res.Add(string.Join(" ", oneline).PadRight(maxWidth));
            }

            return res;
        }
    }
}

