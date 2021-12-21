using System;
using System.Collections.Generic;
using System.Diagnostics;
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


            Console.WriteLine($"Удаление поддерева со значением - {treeNode.Root.Left.Data}");

            treeNode.RemoveSubTree(treeNode.Root, treeNode.Root.Left.Data);  //Удаление поддерева   

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
    public class Lesson4_2 : Lesson
    {
        public override string Name => "4.2";

        public override string Description => "Создание массива и HashSet с 10000 строками, проверка производительности для метода наличия строк";

        public override string Condition => null;

        public override void Demo()
        {
            long count = 10000;
            var array = BuildingStringArray(count);
            var hashSet = BuildingStringHashSet(count);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("String\t|\tArray\t\t\t|\tHashSet\t\t\t|\tRatio");
            Console.ResetColor();
            while (count < 100000)
            {
                TimeSpan ts1 = TestArray(array);
                TimeSpan ts2 = TestHashSet(hashSet);
                Console.WriteLine($"{count}\t|\t{ts1}\t|\t{ts2}\t|\t{ts1 / ts2}");
                count += 10000;
            }
        }

        public override void WorkWithClientData()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Заполнение массива случайными строками
        /// </summary>
        /// <param name="count">количество элементов массива</param>
        /// <returns></returns>
        public string[] BuildingStringArray(long count)
        {
            var array = new string[count];

            for (long i = 0; i < array.Length; i++)
            {
                array[i] += BuildingString();
            }
            return array;
        }
        /// <summary>
        /// Заполнение HashSet случайными строками
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public HashSet<string> BuildingStringHashSet(long count)
        {
            var hashSet = new HashSet<string>();

            for (long i = 0; i < count; i++)
            {
                hashSet.Add(BuildingString());
            }
            return hashSet;
        }
        /// <summary>
        /// Создание случайных строк
        /// </summary>
        /// <returns></returns>
        public string BuildingString()
        {
            var rnd = new Random();
            var length = rnd.Next(0, 100);
            var str = string.Empty;

            while (length-- > 0)
            {
                str += (char)rnd.Next(0, 256);
                length--;
            }
            return str;
        }
        /// <summary>
        /// Тест на производительность HashSet
        /// </summary>
        /// <param name="hashSet"></param>
        /// <returns></returns>
        TimeSpan TestHashSet(HashSet<string> hashSet)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var item in hashSet)
            {
                IsString(item);
            }
            sw.Stop();
            return sw.Elapsed;
        }
        /// <summary>
        /// Тест на производительность Array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        TimeSpan TestArray(string[] str)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < str.Length; i++)
            {
                IsString(str[i]);
            }
            sw.Stop();
            return sw.Elapsed;
        }
        /// <summary>
        /// Проверка на строку
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        bool IsString(string str)
        {
            if (str == null)
            {
                return false;
            }
            return true;
        }
    }
}
