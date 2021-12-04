using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{  
    public class Lesson1
    {
        public void Output(IHomework homework)
        {
            Console.WriteLine("Тестирование программы:");
            homework.Test();
            Console.WriteLine("Для возвращения в меню введите return");
            while (true)
            {
                Console.WriteLine("Введите число");
                string str = Console.ReadLine();
                if (str.Trim() == "return")
                {
                    return;
                }
                if (homework.IsNum(str))
                {
                    homework.Algorithms(Convert.ToInt32(str));
                }
            }
        }

    }
    class Lesson1_1:Lesson1, IHomework
    {

        public void Algorithms(int number)
        {
            int d = 0;
            int i = 2;

            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }

            if (d == 0)
            {
                Console.WriteLine($"{number} - простое");
            }
            else
            {
                Console.WriteLine($"{number} - не простое");
            }
        }
        /// <summary>
        /// Проверка строки на число
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>  
        public bool IsNum(string str)
        {
            int num;
            bool isNum = int.TryParse(str, out num);
            if (isNum)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Введенное значение не является числом {str}");
                return false;
            }
        }

        public void Test()
        {
            int a = 37;
            int b = 8;
            Console.WriteLine("Положительный сценарий: ");
            Algorithms(a);

            Console.WriteLine("Отрицательный сценарий: ");
            Algorithms(b);
        }
    }
    class Lesson1_3 : Lesson1, IHomework
    {
        public void Algorithms(int number)
        {

        }

        public bool IsNum(string str)
        {
            return true;
        }

        public void Test()
        {

        }
    }
}
