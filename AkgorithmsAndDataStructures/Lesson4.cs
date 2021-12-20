using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures
{

    public class Lesson4 : Lesson
    {
        public override string Name => "4.1";

        public override string Description => "Реализация двоичного дерева поиска с операциями вставки, удаления, поиска. Вывод дерева в консоль.";

        public override string Condition => null;
        public override void Demo()
        {
            TreeNode<int> treeNode = new TreeNode<int>();

            Random random = new Random();
            int count = 20;
            for (int i = 0; i < count; i++)     //Создание дерева из 20 элементов
            {
                treeNode.AddElement(random.Next(100));
            }

            Console.WriteLine("Дерево из 20 элементов:");
            Console.WriteLine();
            treeNode.Print(treeNode.Root);    //Вывод дерева
            Console.WriteLine();

            int value = 15;
            treeNode.InsertNode(treeNode.Root, value);   //Вставка элемента
            Console.WriteLine($"Вставка значения - {value}");
            treeNode.Print(treeNode.Root);    //Вывод дерева
            Console.WriteLine();

            Console.WriteLine($"Удаление поддерева со значением - {treeNode.Root.Left.Left.Data}");

            treeNode.RemoveSubTree(treeNode.Root, treeNode.Root.Left.Left.Data);  //Удаление поддерева   

            treeNode.Print(treeNode.Root);    //Вывод дерева
            Console.WriteLine();

            Node<int> nodeSearch = treeNode.Search(treeNode.Root, treeNode.Root.Right.Right.Data);    //Поиск по дереву

            Console.WriteLine($"Поиск поддерева со значением - {treeNode.Root.Right.Right.Data}");
            treeNode.Print(nodeSearch);    //Вывод поддерева
            Console.WriteLine();
        }

        public override void WorkWithClientData()
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// Описывает узел двоичного дерева поиска
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> where T : IComparable
    {

        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }
        public Node() { }
        public Node(T data)
        {
            Data = data;
        }
    }

    public class TreeNode<T> where T : IComparable
    {
        public Node<T> Root { get; set; } //вершина
        /// <summary>
        /// Добавление узла дерева, если вершина есть, то вызов рекурсивного метода
        /// </summary>
        /// <param name="value"> Значение узла </param>
        public void AddElement(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value);
                return;
            }
            AddElementRecursion(Root, value);
        }
        /// <summary>
        /// Рекурсивный метод для добавления элемента в дерево
        /// Рассматривается текущая вершина currentNode и анализируется, куда надо добавлять новый элемент, в левое или правое поддерево
        /// </summary>
        /// <param name="currentNode">Текущая вершина</param>
        /// <param name="newElement">Добавляемый элемент</param>
        private static void AddElementRecursion(Node<T> currentNode, T value)
        {
            if (currentNode.Data.CompareTo(value) < 0) //Если новый элемент меньше текущего, то добавляем в правый узел
            {
                if (currentNode.Right == null) //Если правой ветки нет, то создаем узел, если есть, то вызываем функцию
                {
                    currentNode.Right = new Node<T>(value);
                    currentNode.Right.Parent = currentNode;
                }
                else
                    AddElementRecursion(currentNode.Right, value);
            }
            else //Иначе, если новый элемент больше или равен текущему, заходим в левую ветку
            {
                if (currentNode.Left == null) //Если левой ветки нет, то создаем узел, если есть, то вызываем функцию
                {
                    currentNode.Left = new Node<T>(value);
                    currentNode.Left.Parent = currentNode;
                }
                else
                    AddElementRecursion(currentNode.Left, value);
            }
        }
        /// <summary>
        /// Добавление узла
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="parent">Вершина к которой добавляется узел</param>
        /// <returns></returns>
        public Node<int> GetFreeNode(int value, Node<int> parent)
        {
            Node<int> tmp = new Node<int>();
            tmp.Left = tmp.Right = null;
            tmp.Data = value;
            tmp.Parent = parent;
            return tmp;
        }
        /// <summary>
        /// Вставка узла
        /// </summary>
        /// <param name="head">Голова дерева</param>
        /// <param name="value">Значение</param>
        /// <returns></returns>
        public Node<int> InsertNode(Node<int> head, int value)
        {
            Node<int> tmp = null;
            if (head == null)
            {
                head = GetFreeNode(value, null);
                return head;
            }
            tmp = head;
            while (tmp != null)
            {
                if (value > tmp.Data) //Если значение больше текущего узла спускаемся к правому поддереву
                {
                    if (tmp.Right != null)
                    {
                        tmp = tmp.Right;
                        continue;
                    }
                    else
                    {
                        tmp.Right = GetFreeNode(value, tmp);
                        return head;
                    }
                }
                else if (value < tmp.Data) //Если значение меньше текущего узла спускаемся к левому поддереву
                {
                    if (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                        continue;
                    }
                    else
                    {
                        tmp.Left = GetFreeNode(value, tmp);
                        return head;
                    }
                }
                else
                {
                    throw new Exception("Wrong tree state");  // Дерево построено неправильно
                }
            }
            return head;
        }
        /// <summary>
        /// Удаление поддерева
        /// </summary>
        /// <param name="head">Голова</param>
        /// <param name="value">Значение</param>
        public void RemoveSubTree(Node<int> head, int value)
        {
            if (head == null)
            {
                return;
            }
            if (head.Left?.Data == value)
            {
                head.Left = null;
                return;
            }

            if (head.Right?.Data == value)
            {
                head.Right = null;
                return;
            }

            if (value < head.Data)
            {
                RemoveSubTree(head.Left, value);
            }
            else
            {
                RemoveSubTree(head.Right, value);
            }
        }
        public Node<int> Search(Node<int> head, int value)
        {
            if (head == null) return null;
            if (value > head.Data)
            {
                return Search(head.Right, value);
            }
            else if (value < head.Data)
            {
                return Search(head.Left, value);
            }
            else if (value == head.Data)
            {
                return head;
            }
            else
            {
                return null;
            }
        }

        public void Print(Node<T> node)
        {
            if (node != null)
            {
                if (node.Parent == null)
                {
                    Console.WriteLine("ROOT:{0}", node.Data);
                }
                else
                {
                    if (node.Parent.Left == node)
                    {
                        Console.WriteLine("Left for {1}  --> {0}", node.Data, node.Parent.Data);
                    }

                    if (node.Parent.Right == node)
                    {
                        Console.WriteLine("Right for {1} --> {0}", node.Data, node.Parent.Data);
                    }
                }
                if (node.Left != null)
                {
                    Print(node.Left);
                }
                if (node.Right != null)
                {
                    Print(node.Right);
                }
            }
        }
    }
}
