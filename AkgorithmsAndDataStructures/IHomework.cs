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
