using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    class Lesson1_1
    {
        /// <summary>
        /// Интерфейс программы
        /// </summary>
        public static void OutputConsole()
        {
            Console.WriteLine("Тестирование программы:");
            Test();
            Console.WriteLine("Для возвращения в меню введите return");
            while (true)
            {
                Console.WriteLine("Введите число");
                string str = Console.ReadLine();
                if (str.Trim() == "return")
                {
                    return;
                }
                if (IsNum(str))
                {
                    PrimeOrNotPrimeNumber(Convert.ToInt32(str));
                }
            }
        }
        /// <summary>
        /// Проверка строки на число
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool IsNum(string str)
        {
            int num;
            bool isNum = int.TryParse(str, out num);
            if (isNum)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Введенное число некорректно!");
                return false;
            }
        }
        /// <summary>
        /// Алгоритм для определения простое число или нет
        /// </summary>
        /// <param name="number"></param>
        static void PrimeOrNotPrimeNumber(int number)
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
        /// Тестирование функции PrimeOrNotPrimeNumber
        /// </summary>
        static void Test()
        {
            int a = 37;
            int b = 8;
            Console.WriteLine("Положительный сценарий: ");
            PrimeOrNotPrimeNumber(a);

            Console.WriteLine("Отрицательный сценарий: ");
            PrimeOrNotPrimeNumber(b);
        }
    }
}
