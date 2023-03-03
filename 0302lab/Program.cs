using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace _0302lab
{
    class Program
    {
        public static bool ifFibonacci(int a)
        {
            if (a == 1)
            {
                return true;
            }
            else if (a < 1)
            {
                throw new Exception("Out of range");
            }
            else
            {
                int FirstNum = 0;
                int SecondNum = 1;
                int CurrentNum;
                for (int i = 0; i < a; i++)
                {
                    CurrentNum = FirstNum + SecondNum;
                    if (CurrentNum == a)
                    {
                        return true;
                    }
                    else
                    {
                        FirstNum = SecondNum;
                        SecondNum = CurrentNum;
                    }
                }
                return false;
            }
        }

        public static bool ifPrime(int a)
        {
            if (a == 1)
            {
                return true;
            }
            else if (a < 1)
            {
                throw new Exception("Out of range");
            }
            else
            {
                for (int i = 2; i < a; i++)
                {
                    if (a % i == 0)
                        return false;
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            #region 1
            int[] arr = new int[100];
            Random r = new Random();
            try
            {
                StreamWriter fibonacci = new StreamWriter("Fibonacci.txt", false);
                StreamWriter prime = new StreamWriter("Prime.txt", false);
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = r.Next(1, 100);
                    if (ifFibonacci(arr[i]) == true)
                    {
                        fibonacci.WriteLine(arr[i]);
                        Console.WriteLine("Fibonacci: " + arr[i]);
                    }
                    if (ifPrime(arr[i]) == true)
                    {
                        prime.WriteLine(arr[i]);
                        Console.WriteLine("Prime: " + arr[i]);
                    }
                }
                prime.Close();
                fibonacci.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region 2
            try
            {
                StreamReader reader = new StreamReader("Text.txt", Encoding.UTF8);
                string line;
                string text = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    text += line;
                    text += "\n";
                    Thread.Sleep(100);
                }
                reader.Close();
                Console.WriteLine("Enter a word to replace:");
                string word = Console.ReadLine();
                if (text.Contains(word) == false)
                {
                    throw new Exception("Word not found");
                }
                else
                {
                    Console.WriteLine("Enter the replace word:");
                    text = text.Replace(word, Console.ReadLine());
                    Console.WriteLine(text);
                }
                StreamWriter writer = new StreamWriter("Text.txt", true);
                writer.WriteLine(text);
                writer.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region 3
            try
            {
                Console.WriteLine("Enter the path: ");
                string path = Console.ReadLine();
                StreamReader reader = new StreamReader(path, Encoding.UTF8);
                string line;
                string text = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    text += line;
                    text += "\n";
                    Thread.Sleep(100);
                }
                reader.Close();
                int choice;
                do
                {
                    Console.WriteLine("1.Enter a new word to censor \n2.Stop");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter a word to censor:");
                            string word = Console.ReadLine();
                            if (text.Contains(word) == false)
                            {
                                Console.WriteLine("Word not found");
                            }
                            else
                            {
                                string censoring = "";
                                for (int j = 0; j < word.Length; j++)
                                {
                                    censoring += "*";
                                }
                                text = text.Replace(word, censoring);
                                Console.WriteLine(text);
                            }
                            break;
                        case 2:
                            Console.WriteLine("Stop");
                            break;
                        default:
                            break;
                    }
                }
                while (choice != 2);

                StreamWriter writer = new StreamWriter("Censor.txt", true);
                writer.WriteLine(text);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region 4
            try
            {
                Console.WriteLine("Enter the path: ");
                string path = Console.ReadLine();
                StreamReader reader = new StreamReader(path, Encoding.UTF8);
                string line;
                string text = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    text += line;
                    text += "\n";
                    Thread.Sleep(100);
                }
                reader.Close();

                char[] chararray = text.ToCharArray();
                Array.Reverse(chararray);
                text = new string(chararray);

                StreamWriter writer = new StreamWriter("Reverse.txt", true);
                writer.WriteLine(text);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region 5
            try
            {
                StreamWriter nums = new StreamWriter("Numbers.txt", false);
                StreamWriter pos = new StreamWriter("Positive.txt", false);
                StreamWriter neg = new StreamWriter("Negative.txt", false);
                StreamWriter twodig = new StreamWriter("TwoDigit.txt", false);
                StreamWriter fivedig = new StreamWriter("FiveDigit.txt", false);
                int poscount = 0, negcount = 0, twodigcount = 0, fivedigcount = 0;

                for (int i = 0; i < 10000; i++)
                {
                    int num = r.Next(-100000, 100000);
                    nums.WriteLine(num);
                    if (num > 0)
                    {
                        pos.WriteLine(num);
                        poscount++;
                    }
                    if (num < 0)
                    {
                        neg.WriteLine(num);
                        negcount++;
                    }
                    string numstr = Convert.ToString(num);
                    if (numstr.Length == 2&&num>0)
                    {
                        twodig.WriteLine(num);
                        twodigcount++;
                    }
                    if (numstr.Length == 3 && num < 0)
                    {
                        twodig.WriteLine(num);
                        twodigcount++;
                    }
                    if (numstr.Length == 5&&num>0)
                    {
                        fivedig.WriteLine(num);
                        fivedigcount++;
                    }
                    if (numstr.Length == 6 && num < 0)
                    {
                        fivedig.WriteLine(num);
                        fivedigcount++;
                    }
                }
                nums.Close();
                Console.WriteLine("Positive: " + poscount + "\nNegative: " + negcount + "\nTwo-digit: " + twodigcount + "\nFive-digit: " + fivedigcount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion


        }
    }
}
