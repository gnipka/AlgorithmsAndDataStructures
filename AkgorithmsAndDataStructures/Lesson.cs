using System;

namespace AlgorithmsAndDataStructures
{
    public abstract class Lesson:IHomework
    {
        public abstract void Demo();
        public abstract void WorkWithClientData(string str);

        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract string Condition { get; }

        public void Output()
        {
            Console.Clear();
            Console.WriteLine("Тестирование программы:");
            Demo();
            Console.WriteLine("Для возвращения в меню введите return");
            while (true)
            {
                if (Condition != null)
                {
                    Console.WriteLine(Condition);
                }
                string str = Console.ReadLine();
                if (str.Trim() == "return")
                {
                    return;
                }
                if (Condition != null)
                {
                    WorkWithClientData(str);
                    Console.WriteLine();
                }
            }
        }
    }
}
