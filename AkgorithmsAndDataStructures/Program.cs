using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static List<ILesson> _homeworks = new List<ILesson>()
        {
            new Lesson1_1(),
            new Lesson1_3(),
            new Lesson2(),
            new Lesson3()
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - Выход из программы");
                Console.WriteLine("Для выбора задания введите его код");
                Console.WriteLine("Доступные задания:");

                foreach (ILesson homework in _homeworks)
                {
                    Console.WriteLine($"Код задания: {homework.Name} ({homework.Description})");
                }
                while (true)
                {
                    string nameLesson = Console.ReadLine();
                    try
                    {
                        ILesson homeworkNow = _homeworks.Single(h => h.Name == nameLesson.Trim());
                        homeworkNow.Output();
                        break;
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine($"Задание с кодом {nameLesson} не найдено");
                        Console.WriteLine("Введите код");
                    }
                }
            }
        }
    }
}
