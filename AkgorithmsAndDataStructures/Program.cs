using System;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("0 - Выход из программы");
                Console.WriteLine("1 - Задание 1.1");
                Console.WriteLine("2 - Задание 1.2");
                Console.WriteLine("3 - Задание 1.3");

                switch (Console.ReadLine().Trim())
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Lesson1_1.OutputConsole();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        break;
                }

            }
        }
    }
}
