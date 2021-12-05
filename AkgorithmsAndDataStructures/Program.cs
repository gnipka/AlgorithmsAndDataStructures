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
                Console.WriteLine("2 - Задание 1.3");

                Lesson1 lesson1 = new Lesson1();
                switch (Console.ReadLine().Trim())
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Lesson1_1 lesson1_1 = new Lesson1_1();
                        lesson1.Output(lesson1_1);
                        Console.Clear();
                        break;
                    case "2":
                        Lesson1_3 lesson1_3 = new Lesson1_3();
                        lesson1_3.Output(lesson1_3);
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
