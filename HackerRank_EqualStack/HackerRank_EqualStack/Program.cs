using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank_EqualStack
{
    internal class Program
    {
        private static int EqualStacks(int[] box1, int[] box2, int[] box3)
        {
            try
            {
                // Declare remove step to make you that we remove the top cylinder ↓↓↓
                int removeStepOfBox1 = 0;
                int removeStepOfBox2 = 0;
                int removeStepOfBox3 = 0;

                // Calculate height of each box ↓↓↓
                int heightOfBox1 = box1.Sum();
                int heightOfBox2 = box2.Sum();
                int heightOfBox3 = box3.Sum();

                // While all box are not equal, we will remove the top cylinder of tallest box until are equal ↓↓↓
                while (heightOfBox1 != heightOfBox2 || heightOfBox1 != heightOfBox3 || heightOfBox2 != heightOfBox3)
                {
                    // Declare a variable to store index of tallest box ↓↓↓
                    int tallestBoxIndex = 0;

                    // If Box1 is heighest ↓↓↓
                    if (heightOfBox1 >= heightOfBox2 && heightOfBox1 >= heightOfBox3)
                        tallestBoxIndex = 0;

                    // If Box2 is heighest ↓↓↓
                    if (heightOfBox2 >= heightOfBox1 && heightOfBox2 >= heightOfBox3)
                        tallestBoxIndex = 1;

                    // If Box3 is heighest ↓↓↓
                    if (heightOfBox3 >= heightOfBox1 && heightOfBox3 >= heightOfBox2)
                        tallestBoxIndex = 2;

                    // Calculate heigh of tallest box again by subtract the top cylinder height ↓↓↓
                    switch (tallestBoxIndex)
                    {
                        case 0: heightOfBox1 -= box1[removeStepOfBox1]; removeStepOfBox1++; break;
                        case 1: heightOfBox2 -= box2[removeStepOfBox2]; removeStepOfBox2++; break;
                        case 2: heightOfBox3 -= box3[removeStepOfBox3]; removeStepOfBox3++; break;
                    }
                }

                // Return whatever, because all box are equal now ↓↓↓
                return heightOfBox1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] n1N2N3 = Console.ReadLine().Split(' ');

            int n1 = Convert.ToInt32(n1N2N3[0]);
            int n2 = Convert.ToInt32(n1N2N3[1]);
            int n3 = Convert.ToInt32(n1N2N3[2]);

            int[] h1 = Array.ConvertAll(Console.ReadLine().Split(' '), h1Temp => Convert.ToInt32(h1Temp));
            int[] h2 = Array.ConvertAll(Console.ReadLine().Split(' '), h2Temp => Convert.ToInt32(h2Temp));
            int[] h3 = Array.ConvertAll(Console.ReadLine().Split(' '), h3Temp => Convert.ToInt32(h3Temp));

            textWriter.WriteLine(EqualStacks(h1, h2, h3));
            textWriter.Flush();
            textWriter.Close();

            Console.WriteLine(EqualStacks(h1, h2, h3));
        }
    }
}