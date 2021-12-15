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
        /// <summary>
        /// Условия для ввода данных (при пользовательском вводе)
        /// </summary>
        string Condition { get; }
        /// <summary>
        /// Вывод тестовых данных
        /// </summary>
        void Demo();
        /// <summary>
        /// Ввод данных пользователем с клавиутуры
        /// </summary>
        /// <param name="str"></param>
        void WorkWithClientData();
        /// <summary>
        /// Вывыд на экран
        /// </summary>
        void Output();
    }
}
