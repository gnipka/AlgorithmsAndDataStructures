﻿using System;

namespace AlgorithmsAndDataStructures
{
    public abstract class Lesson:IHomework
    {
        public abstract void Demo();
        public abstract void WorkWithClientData();

        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract string Condition { get; }

        public void Output()
        {
            InputOutput.IInputOutputHelper inputOutputHelper = new InputOutput.ConsoleInputOutputHelper();
            Console.Clear();
            Console.WriteLine("Тестирование программы:");
            Demo();
            while (true)
            {
                Console.WriteLine("Для возвращения в меню введите return");
                Console.WriteLine("Для продолжения введите любые другие символы");
                if(Console.ReadLine().Trim() == "return")
                {
                    break;
                }
                WorkWithClientData();
            }
        }
    }
}
