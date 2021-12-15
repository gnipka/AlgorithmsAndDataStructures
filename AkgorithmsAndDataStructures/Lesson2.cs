using System;

namespace AlgorithmsAndDataStructures
{
    class Lesson2 : Lesson
    {
        private string name = "2";
        /// <summary>
        /// Код урока
        /// </summary>
        public override string Name
        {
            get { return name; }
        }
        private string description = "Реализация класса двусвязного списка и операции вставки, удаления и поиска элемента в нем в соответствии с интерфейсом";
        /// <summary>
        /// Описание урока
        /// </summary>
        public override string Description
        {
            get { return description; }
        }
        private string condition = null;
        /// <summary>
        /// Условия для ввода данных (при пользовательском вводе)
        /// </summary>
        public override string Condition
        {
            get { return condition; }
        }

        /// <summary>
        /// Вывод списка
        /// </summary>
        /// <param name="currentNode"></param>
        public void OutputNode(Node currentNode)
        {
            while (currentNode != null)
            {
                Console.Write($"{currentNode.Value} ");
                currentNode = currentNode.NextNode;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Тестирование задания 2
        /// </summary>
        public override void Demo()
        {
            //пример добавления элементов в лист
            Console.WriteLine("Добавление элементов в список (1 - 10)");
            NodeList nodeList = new NodeList();
            for (int i = 0; i < 10; i++)
            {
                nodeList.AddNode(i + 1);
            }
            Node currentNode = nodeList.StartNode;
            OutputNode(currentNode);

            //пример добавления элемента после определенного элемента
            nodeList.AddNodeAfter(nodeList.FindNode(2), 5);
            Console.WriteLine("Добавление элемента со значением 5 после элемента со значением 2");
            OutputNode(currentNode);

            //вывод количества элементов
            Console.WriteLine($"Количество элементов списка: {nodeList.GetCount()}");

            //пример удаления элемента по порядковому номеру 2
            nodeList.RemoveNode(3);
            Console.WriteLine("Удаление элемента с индексом 3");
            OutputNode(currentNode);

            //пример удаления элемента со значением 9
            Console.WriteLine("Удаление элемента со значением 9");
            nodeList.RemoveNode(nodeList.FindNode(9));
            OutputNode(currentNode);
        }

        public override void WorkWithClientData(string str)
        {

        }
    }
    /// <summary>
    /// Двусвязный список
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Значение элемента
        /// </summary>
        public int Value { get; set; }
        /// <summary>
        /// Ссылка на следующий элемент
        /// </summary>
        public Node NextNode { get; set; }
        /// <summary>
        /// Ссылка на предыдущий элемент
        /// </summary>
        public Node PrevNode { get; set; }
    }
    /// <summary>
    /// Интерфейс с методами для работы с двусвязным списком
    /// </summary>
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }

    public class NodeList : ILinkedList
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Node StartNode { get; set; }
        /// <summary>
        /// добавляет новый элемент списка
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            var node = StartNode;
            if (StartNode == null)
            {
                var newNode = new Node { Value = value };
                StartNode = newNode;
            }
            else
            {
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }
                var newNode = new Node { Value = value };
                node.NextNode = newNode;
                newNode.PrevNode = node;
            }
        }
        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        public void AddNodeAfter(Node node, int value)
        {
            var nextNode = node.NextNode;
            var newNode = new Node { Value = value, PrevNode = node, NextNode = nextNode };
            nextNode.PrevNode = newNode;
            node.NextNode = newNode;
        }
        /// <summary>
        /// ищет элемент по его значению
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public Node FindNode(int searchValue)
        {
            var currentNode = StartNode;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue) return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null;
        }
        /// <summary>
        /// возвращает количество элементов в списке
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            var currentNode = StartNode;
            int count = 0;
            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.NextNode;
            }
            return count;
        }
        /// <summary>
        /// удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index"></param>
        public void RemoveNode(int index)
        {
            index -= 1;
            if (index == 0)
            {
                var newStartNode = StartNode.NextNode;
                newStartNode.PrevNode = null;
                StartNode.NextNode = null;
                StartNode = newStartNode;
            }
            int currentIndex = 0;
            var currentNode = StartNode;
            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    var nextNode = currentNode.NextNode;
                    var prevNode = currentNode.PrevNode;
                    prevNode.NextNode = nextNode;
                    nextNode.PrevNode = prevNode;
                    currentNode.NextNode = null;
                    currentNode.PrevNode = null;
                }
                currentNode = currentNode.NextNode;
                currentIndex++;
            }
        }
        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        /// <param name="node"></param>
        public void RemoveNode(Node node)
        {
            var currentNode = StartNode;
            if (currentNode == node)
            {
                var nextNode = StartNode.NextNode;
                nextNode.PrevNode = null;
                currentNode.NextNode = null;
                return;
            }
            while (currentNode != null)
            {
                if (currentNode == node)
                {
                    var nextNode = currentNode.NextNode;
                    var prevNode = currentNode.PrevNode;
                    prevNode.NextNode = nextNode;
                    nextNode.PrevNode = prevNode;
                    currentNode.PrevNode = null;
                    currentNode.NextNode = null;
                }
                currentNode = currentNode.NextNode;
            }
        }
    }
}
