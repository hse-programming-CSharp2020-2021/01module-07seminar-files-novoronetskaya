using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";

        static int[] ReadFile(string path)
        {
            string elements = File.ReadAllText(path);
            string[] numbers = elements.Split(' ');
            int[] result = new int[numbers.Length];
            int i = 0;
            foreach (string num in numbers)
            {
                int.TryParse(num, out result[i++]);
            }
            return result;
        }

        static bool CheckArray(int[] array)
        {
            foreach (int element in array)
            {
                if (element < -10 || element > 10)
                {
                    return false;
                }
            }
            return true;
        }

        static bool[] IntToBoolArray(int[] array)
        {
            bool[] isPositive = new bool[array.Length];
            int i = 0;
            foreach (int element in array)
            {
                if (element >= 0)
                {
                    isPositive[i++] = true;
                }
                else
                {
                    isPositive[i++] = false;
                }
            }
            return isPositive;
        }

        static void WriteFile(string path, bool[] array)
        {
            string answer = String.Empty;
            foreach (bool element in array)
            {
                answer += $"{element} ";
            }
            File.WriteAllText(path, answer);
        }

        // you do not need to fill your file, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();

            int[] A;
            bool[] L;
            try
            {
                A = ReadFile(inputPath);
                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // do not touch
            ConsoleOutput();
        }

        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}