using System;

namespace AlgorithmsAndDataStructures
{
    public class Lesson
    {
        public void Output(IHomework homework)
        {
            Console.Clear();
            Console.WriteLine("Тестирование программы:");
            homework.Demo();
            Console.WriteLine("Для возвращения в меню введите return");
            while (true)
            {
                if (homework.Condition != null)
                {
                    Console.WriteLine(homework.Condition);
                }
                string str = Console.ReadLine();
                if (str.Trim() == "return")
                {
                    return;
                }
                if (homework.Condition != null)
                {
                    homework.WorkWithClientData(str);
                    Console.WriteLine();
                }
            }
        }
    }
}
