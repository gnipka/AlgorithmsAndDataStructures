using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{
    public interface IHomework
    {
        /// <summary>
        /// Код урока
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; }
        string Condition { get; }
        /// <summary>
        /// Вывод тестовых данных
        /// </summary>
        void Demo();
        void WorkWithClientData(string str);
    }
}
