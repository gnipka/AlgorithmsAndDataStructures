using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    class Lesson3 : Lesson
    {
        public override string Name => "3";

        public override string Description => "Проверка производительности двух методов 1)Расстояние между парой точек; 2)Создание массива точек и заполнение его случайными значениями";

        public override string Condition => null;

        public override void Demo()
        {
            Stopwatch sw = new Stopwatch();
            long count = 50000;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Points     |     PointStructDouble    |     PointClassDouble     |     Ratio");
            Console.ResetColor();
            while (count < 5000000)
            {
                TimeSpan ts1 = TestClass(count);
                TimeSpan ts2 = TestStruct(count);
                if (count / 100000 == 0)
                {
                    Console.WriteLine($"{count}      |     {ts1}     |     {ts2}     |     {ts1 / ts2}");
                }
                else if (count / 1000000 == 0)
                {
                    Console.WriteLine($"{count}     |     {ts1}     |     {ts2}     |     {ts1 / ts2}");
                }
                else
                {
                    Console.WriteLine($"{count}    |     {ts1}     |     {ts2}     |     {ts1 / ts2}");
                }
                count = count * 2;
            }
        }
        /// <summary>
        /// Рассчет производительности метода, который находит расстояние между точками классса
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        TimeSpan TestClass(long count)
        {
            Stopwatch sw = new Stopwatch();
            PointClassDouble[] pointClass = CreateRandomArrayClass(count);
            sw.Start();
            for (int i = 0; i < count - 1; i++)
            {
                DistanceBetweemClassPoints(pointClass[i], pointClass[i + 1]);
            }
            sw.Stop();
            return sw.Elapsed;
        }
        /// <summary>
        /// Расчет производительности метода, который находит расстояние между точками структур
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        TimeSpan TestStruct(long count)
        {
            Stopwatch sw = new Stopwatch();
            PointStructDouble[] pointStruct = CreateRandomArrayStruct(count);
            sw.Start();
            for (int i = 0; i < count - 1; i++)
            {
                DistanceBetweemStructPoints(pointStruct[i], pointStruct[i + 1]);
            }
            sw.Stop();
            return sw.Elapsed;
        }
        public override void WorkWithClientData()
        {
            Console.WriteLine("Ввод пользовательских данных не предусмотрен");
        }
        /// <summary>
        /// структура точек
        /// </summary>
        public struct PointStructDouble
        {
            public double X;
            public double Y;
        }
        /// <summary>
        /// класс точек
        /// </summary>
        public class PointClassDouble
        {
            public double X;
            public double Y;
        }
        /// <summary>
        /// Возвращает расстояние между точками (класс)
        /// </summary>
        /// <param name="pointClassDouble"></param>
        /// <param name="pointStructDouble"></param>
        /// <returns></returns>
        double DistanceBetweemClassPoints(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            return Math.Sqrt((pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X) + (pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y));
        }
        /// <summary>
        /// Возвращает расстояние между точками (структура)
        /// </summary>
        /// <param name="pointClassDouble"></param>
        /// <param name="pointStructDouble"></param>
        /// <returns></returns>
        double DistanceBetweemStructPoints(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            return Math.Sqrt((pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X) + (pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y));
        }
        /// <summary>
        /// Создание массива структур точек
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        PointStructDouble[] CreateRandomArrayStruct(long count)
        {
            Random random = new Random();
            PointStructDouble[] pointStructDoubles = new PointStructDouble[count];
            for (long i = 0; i < count; i++)
            {
                pointStructDoubles[i].X = random.Next(100) + random.NextDouble();
                pointStructDoubles[i].Y = random.Next(100) + random.NextDouble();
            }
            return pointStructDoubles;
        }
        /// <summary>
        /// Создание массива экземпляров класса точек
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        PointClassDouble[] CreateRandomArrayClass(long count)
        {
            Random random = new Random();
            PointClassDouble[] pointClassDoubles = new PointClassDouble[count];
            for (long i = 0; i < count; i++)
            {
                pointClassDoubles[i] = new PointClassDouble();
                pointClassDoubles[i].X = random.Next(100) + random.NextDouble();
                pointClassDoubles[i].Y = random.Next(100) + random.NextDouble();
            }
            return pointClassDoubles;
        }
    }
}
