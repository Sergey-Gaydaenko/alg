using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter first sequnce: ");
            string firstSequence = Console.ReadLine();

            Console.Write("Enter second sequence: ");
            string secondSequence = Console.ReadLine();

            if (!string.IsNullOrEmpty(firstSequence) && !string.IsNullOrEmpty(secondSequence))
            {
                int[,] lengths = new int[firstSequence.Length + 1, secondSequence.Length + 1];

                LcsLength(firstSequence, secondSequence, lengths);
                string result = FindLcs(firstSequence, secondSequence, lengths);

                Console.WriteLine("LCS: {0}", result);
            }
            else
            {
                Console.WriteLine("Invalid data for sequences");
            }
            
            Console.ReadLine();
        }

        private static void LcsLength(string firstSequence, string secondSequense, int[,] lengths)
        {
            int firstSequenceLength = firstSequence.Length;
            int secondSequenceLength = secondSequense.Length;

            for (int i = 0; i <= secondSequenceLength; i++)
            {
                lengths[0, i] = 0;
            }

            for (int i = 0; i <= firstSequenceLength; i++)
            {
                lengths[i, 0] = 0;
            }

            for (int i = 1; i <= firstSequenceLength; i++)
            {
                for (int j = 1; j <= secondSequenceLength; j++)
                {
                    if (firstSequence[i - 1] == secondSequense[j - 1])
                    {
                        lengths[i, j] = lengths[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        lengths[i, j] = (lengths[i - 1, j] > lengths[i, j - 1]) ?
                            lengths[i - 1, j] : lengths[i, j - 1];
                    }
                }
            }
        }

        private static string FindLcs(string firstSequence, string secondSequence, int[,] lengths)
        {
            int n = firstSequence.Length;
            int m = secondSequence.Length;

            string lcs = "";

            for (int i = n; i > 0; i--)
            {
                for (int j = m; j > 0;)
                {
                    if (lengths[i, j] == lengths[i, j - 1])
                    {
                        j = --m;
                        continue;
                    }

                    if (lengths[i, j] != lengths[i - 1, j])
                    {
                        lcs = firstSequence[i - 1] + lcs;
                        --m;
                    }

                    break;
                }
            }
            return lcs;
        }
    }
}
