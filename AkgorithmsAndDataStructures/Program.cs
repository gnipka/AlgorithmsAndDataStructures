using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static List<IHomework> _homeworks = new List<IHomework>()
        {
            new Lesson1_1(),
            new Lesson1_3()
        };
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - Выход из программы");
                Console.WriteLine("Для выбора задания введите его код");
                Console.WriteLine("Доступные задания:");

                foreach (IHomework homework in _homeworks)
                {
                    Console.WriteLine($"Код задания: {homework.Name} ({homework.Description})");
                }
                while (true)
                {
                    string nameLesson = Console.ReadLine();
                    try
                    {
                        IHomework homeworkNow = _homeworks.Single(h => h.Name == nameLesson.Trim());
                        Lesson lesson = new Lesson();
                        lesson.Output(homeworkNow);
                        break;
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine($"Задания с кодом {nameLesson} не найдено");
                        Console.WriteLine("Введите код");
                    }
                }
            }
        }
    }
}
