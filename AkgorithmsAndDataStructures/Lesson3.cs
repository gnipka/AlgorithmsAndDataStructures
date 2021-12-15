using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public override void WorkWithClientData()
        {
            return;
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
        /// Возвращает расстояние между точками
        /// </summary>
        /// <param name="pointClassDouble"></param>
        /// <param name="pointStructDouble"></param>
        /// <returns></returns>
        double DistanceBetweemPoints(PointClassDouble pointOne, PointStructDouble pointTwo)
        {
            return Math.Sqrt((pointTwo.X - pointOne.X) * (pointTwo.X - pointOne.X) + (pointTwo.Y - pointOne.Y) * (pointTwo.Y - pointOne.Y));
        }

    }
}
