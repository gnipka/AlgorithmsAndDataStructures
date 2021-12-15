using System;

namespace AlgorithmsAndDataStructures
{

    //Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
    //1. Реализовать в виде консольного приложения.
    //2. Алгоритм реализовать в отдельном классе согласно блок-схеме.
    //3. Написать проверочный код(один положительный, один отрицательный сценарий) в отдельной функции и вызывать его при запуске.
    //4. Код выложить на GitHub.
    class Lesson1_1 : Lesson
    {
        private string name = "1.1";
        /// <summary>
        /// Код урока
        /// </summary>
        public override string Name
        {
            get { return name; }
        }
        private string description = "Анализ принадлежности к множеству простых чисел.";
        /// <summary>
        /// Описание урока
        /// </summary>
        public override string Description
        {
            get { return description; }
        }
        private string condition = "Введите число";
        /// <summary>
        /// Условия для ввода данных (при пользовательском вводе)
        /// </summary>
        public override string Condition
        {
            get { return condition; }
        }

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
        /// Тестирование числа с положительным и отрицательным исходом
        /// </summary>
        public override void Demo()
        {
            int a = 37;
            int b = 8;
            Console.WriteLine("Положительный сценарий: ");
            Algorithms(a);

            Console.WriteLine("Отрицательный сценарий: ");
            Algorithms(b);
        }
        /// <summary>
        /// Проверка на корректоность введенных данных, при положительном исходе вызов вычислительной функции
        /// </summary>
        /// <param name="str"></param>
        public override void WorkWithClientData(string str)
        {
            int num;
            bool isNum = int.TryParse(str, out num);
            if (isNum)
            {
                Algorithms(Convert.ToInt32(str));
            }
            else
            {
                Console.WriteLine($"Введенное значение не является числом {str}");
                return;
            }
        }
    }

    //1. Реализовать рекурсивную версию и версию без рекурсии(через цикл);
    //2. Обе реализации сделать методами отдельного класса;
    //3. На вход методы должны принимать целочисленный параметр, определяющий количество элементов формируемой последовательности.
    class Lesson1_3 : Lesson
    {
        private string name = "1.3";
        public override string Name
        {
            get { return name; }
        }
        private string description = "Реализация вывода чисел Фибоначчи с рекурсией и без";
        /// <summary>
        /// Описание урока
        /// </summary>
        public override string Description
        {
            get { return description; }
        }
        private string condition = "Введите число - количество чисел для вывода последовательности Фибоначчи";
        /// <summary>
        /// Условия для ввода данных (при пользовательском вводе)
        /// </summary>
        public override string Condition
        {
            get { return condition; }
        }

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
        /// Тестирование числа на значениях 5 и 15
        /// </summary>
        public override void Demo()
        {
            Algorithms(5);
            Algorithms(15);
        }
        /// <summary>
        /// Проверка введенных данных, при положительном исходе вызов вычислительной функции
        /// </summary>
        /// <param name="str"></param>
        public override void WorkWithClientData(string str)
        {
            int num;
            bool isNum = int.TryParse(str, out num);
            if (isNum)
            {
                Algorithms(Convert.ToInt32(str));
            }
            else
            {
                Console.WriteLine($"Введенное значение не является числом {str}");
                return;
            }
        }
    }
}
