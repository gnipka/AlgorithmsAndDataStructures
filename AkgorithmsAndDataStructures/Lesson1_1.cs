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
                    Console.WriteLine();
                }
            }
        }

    }

    //Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
    //1. Реализовать в виде консольного приложения.
    //2. Алгоритм реализовать в отдельном классе согласно блок-схеме.
    //3. Написать проверочный код(один положительный, один отрицательный сценарий) в отдельной функции и вызывать его при запуске.
    //4. Код выложить на GitHub.

    class Lesson1_1 :Lesson1, IHomework
    {
        /// <summary>
        /// Функция проверки числа на простое
        /// </summary>
        /// <param name="number"></param>
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
        /// <summary>
        /// Тестирование числа с положительным и отрицательным исходом
        /// </summary>
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
    //1. Реализовать рекурсивную версию и версию без рекурсии(через цикл);
    //2. Обе реализации сделать методами отдельного класса;
    //3. На вход методы должны принимать целочисленный параметр, определяющий количество элементов формируемой последовательности.

    class Lesson1_3 : Lesson1, IHomework
    {
        public void Algorithms(int count)
        {
            Console.Write("Вывод последовательности Фибоначчи с рекурсией: ");
            FibonacciRecursion(0, 1, 1, count);
            Console.WriteLine();
            Console.Write("Вывод последовательности Фибоначчи без рекурсии: ");
            Fibonacci(count);
            Console.WriteLine();

        }
        /// <summary>
        /// Функция нахождения чисел Фибоначчи рекурсивным методом
        /// </summary>
        /// <param name="a"> первое число последновательности </param>
        /// <param name="b"> второе число последновательности  </param>
        /// <param name="counter"> счетчик </param>
        /// <param name="count"> количество чисел для вывода </param>
        private static void FibonacciRecursion(int a, int b, int counter, int count)
        {
            if (counter <= count)
            {
                Console.Write($"{a} ");
                FibonacciRecursion(b, a + b, counter + 1, count);
            }
        }
        /// <summary>
        /// Функция нахождения чисел Фибоначчи не рекурсивным методом
        /// </summary>
        /// <param name="count"> количество чисел для вывода </param>
        private static void Fibonacci(int count)
        {
            int a = 0;
            int b = 1;
            int c = 0;
            if (count == 0) return;
            if (count == 1)
            {
                Console.Write($"{a} ");
                return;
            }
            Console.Write($"{a} ");
            if (count == 2)
            {
                Console.Write($"{a} {b} ");
                return;
            }
            Console.Write($"{b} ");
            for (int i = 2; i < count; i++)
            {
                c = a + b;
                Console.Write($"{c} ");
                a = b;
                b = c;
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
        /// <summary>
        /// Тестирование числа на значениях 5 и 15
        /// </summary>
        public void Test()
        {
            Algorithms(5);
            Algorithms(15);
        }
    }
}
