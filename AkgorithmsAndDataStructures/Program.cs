using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static List<ILesson> _homeworks = new List<ILesson>()
        {
            //new Lesson1(),
            //new Lesson1_3(),
            //new Lesson2(),
            //new Lesson3(),
            //new Lesson4(),
            //new Lesson4_2(),
            //new Lesson5()
        };

        static void Main(string[] args)
        {
            while (true)
            {
                var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\Users\admin\source\repos\AkgorithmsAndDataStructures\LibLesson\bin\Debug\net5.0\LibLesson.dll");
                Type myType1 = myAssembly.GetType("LibLesson.Lesson1");
                dynamic obj1 = Activator.CreateInstance(myType1);
                _homeworks.Add(obj1);

                var myType13 = myAssembly.GetType("LibLesson.Lesson1_3");
                dynamic obj13 = Activator.CreateInstance(myType13);
                _homeworks.Add(obj13);

                var myType2 = myAssembly.GetType("Lesson2.Lesson2");
                dynamic obj2 = Activator.CreateInstance(myType2);
                _homeworks.Add(obj2);

                var myType3 = myAssembly.GetType("Lesson3");
                dynamic obj3 = Activator.CreateInstance(myType3);
                _homeworks.Add(obj3);

                var myType4 = myAssembly.GetType("Lesson4.Lesson4");
                dynamic obj4 = Activator.CreateInstance(myType4);
                _homeworks.Add(obj4);

                var myType42 = myAssembly.GetType("Lesson4.Lesson4_2");
                dynamic obj42 = Activator.CreateInstance(myType42);
                _homeworks.Add(obj42);

                var myType5 = myAssembly.GetType("Lesson5");
                dynamic obj5 = Activator.CreateInstance(myType5);
                _homeworks.Add(obj5);

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
                        ILesson homeworkNow = _homeworks.SingleOrDefault(h => h.Name == nameLesson.Trim());
                        homeworkNow.Output();
                        break;
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine($"Задание с кодом {nameLesson} не найдено");
                        Console.WriteLine("Введите код");
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine($"Задание с кодом {nameLesson} не найдено");
                        Console.WriteLine("Введите код");
                    }
                }
            }
        }
    }
}
