using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures
{
    class Lesson5 : Lesson
    {

        public override string Name => "5";

        public override string Description => "Методы поиска в дереве - \"Поиск в ширину\" и \"Поиск в глубину\"";

        public override string Condition => throw new NotImplementedException();

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
            string str = string.Empty;
            Console.WriteLine("Алгоритм обхода в глубину:");
            DFS(treeNode.Root, ref str, true);
            Console.WriteLine(str);
            Console.WriteLine("Алгоритм обхода в ширину:");
            str = string.Empty;
            BFC(treeNode.Root, ref str, true);
            Console.WriteLine(str);
        }

        public override void WorkWithClientData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Алгоритм обхода в глубину
        /// </summary>
        /// <param name="node"> корень дерева</param>
        /// <param name="s"> строка в которую записываем результат </param>
        /// <param name="detailed">для красивого вывода </param>
        private void DFS(Node<int> node, ref string s, bool detailed)
        {
            if (node != null)
            {
                if (detailed)
                    s += "получение значения " + node.Data.ToString() + Environment.NewLine;
                else
                    s += node.Data.ToString() + " ";
                if (detailed) s += "    обход левого поддерева" + Environment.NewLine;
                DFS(node.Left, ref s, detailed); // рекурурсивно заходим в левое поддерево
                if (detailed) s += "    обход правого поддерева" + Environment.NewLine;
                DFS(node.Right, ref s, detailed); // рекурурсивно заходим в правое поддерево
            }
            else if (detailed) s += "значение отсутствует - null" + Environment.NewLine;
        }

        /// <summary>
        /// Алгоритм обхода в ширину
        /// </summary>
        /// <param name="node"> корень дерева</param>
        /// <param name="s"> строка в которую записываем результат </param>
        /// <param name="detailed"> для красивого вывода </param>
        private void BFC(Node<int> node, ref string s, bool detailed)
        {
            var queue = new Queue<Node<int>>();
            if (detailed) s += "    помещаем в очередь значение " + node.Data.ToString() + Environment.NewLine; queue.Enqueue(node);
            while (queue.Count != 0) // пока очередь не пуста
            {
                //добавляем поддеревья
                if (queue.Peek().Left != null)
                {
                    if (detailed) s += "    помещаем в очередь значение " + queue.Peek().Left.Data.ToString() + " из левого поддерева" + Environment.NewLine;
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null)
                {
                    if (detailed) s += "    помещаем в очередь значение " + queue.Peek().Right.Data.ToString() + " из правого поддерева" + Environment.NewLine;
                    queue.Enqueue(queue.Peek().Right);
                }
                if (detailed) s += "получение значения из очереди: " + queue.Peek().Data.ToString() + Environment.NewLine;
                else s += queue.Peek().Data.ToString() + " ";
                queue.Dequeue();
            }
        }

    }
}
