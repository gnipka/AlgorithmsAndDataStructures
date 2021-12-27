using System;

namespace LibLesson
{
    public abstract class Lesson : ILesson
    {
        public abstract void Demo();
        public abstract void WorkWithClientData();

        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract string Condition { get; }

        public void Output()
        {
            Console.Clear();
            Console.WriteLine("Тестирование программы:");
            Demo();
            while (true)
            {
                Console.WriteLine("Для возвращения в меню введите return");
                Console.WriteLine("Для продолжения введите любые другие символы");
                if (Console.ReadLine().Trim() == "return")
                {
                    break;
                }
                WorkWithClientData();
            }
        }
    }
}
