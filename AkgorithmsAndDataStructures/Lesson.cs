using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine(homework.Condition);
                string str = Console.ReadLine();
                if (str.Trim() == "return")
                {
                    return;
                }
                homework.WorkWithClientData(str);
                Console.WriteLine();
            }
        }
    }
}
