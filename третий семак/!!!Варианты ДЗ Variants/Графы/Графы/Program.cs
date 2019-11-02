using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Графы
{
    class Program
    {
        public class Node
        {
            public Node()
            {
                ErrorName:
                Console.WriteLine("Введите имя вершины(0-недопустимое имя):");
                string n1 = Console.ReadLine();
                if (n1 == "0") { Console.WriteLine("Недопустимый ввод! Повторите попытку!"); goto ErrorName; }  //проверка ввода имени
                Name = n1;
            }

            public string Name { get; set; }
            public Stack <Node> Arc { get; set; }
            public Stack <int> Weight { get; set; }
        }

        static void Main(string[] args)
        {
            Stack <Node> nodes = new Stack <Node>();

            //цикл создающий вершины
            while (true)
            {
                string f;
                Console.WriteLine("Вы хотите создать вершину?");
                Console.WriteLine("1-да    0-нет");
                f = Console.ReadLine();
                if (f == "0") { break; }
                else if (f != "1") { Console.WriteLine("Невеный ввод!!! Повторите попытку."); continue; }           //проверка ввода f

                Node n = new Node();
                nodes.Push(n);
            }
            Console.Clear();
            //цикл для запроса связей и их веса
            foreach (Node n in nodes) 
            {
                n.Arc = new Stack<Node>();
                n.Weight = new Stack<int>();
                while (true)
                {
                    string f1;
                    Console.WriteLine("Введите одну вершину с которой связана вершина {0}", n.Name);
                    Console.WriteLine("Если она не связана ни с одной вершиной или ввод вершин закончен введите 0");
                    f1 = Console.ReadLine();
                    if (f1 == "0") break;
                    int i = 1;                                                      
                    foreach (Node m in nodes)  //цикл для проверки наличия вершины и добавления связи и веса
                    {
                        if (m.Name == f1)
                        {
                            n.Arc.Push(m);
                            Errorweight:
                            Console.WriteLine("Вес связи с вершиной {0}", m.Name);
                            int w = int.Parse(Console.ReadLine());
                            if (w <= 0) { Console.WriteLine("Вес не может быть меньше или равен 0! Повторите ввод."); goto Errorweight; }
                            n.Weight.Push(w);
                            break;
                        }
                        if (i == nodes.Count) { Console.WriteLine("Введена несуществующая вершина!Повторите ввод!!!"); break; }
                        i++;
                        
                    }
                }
            }
            Console.Clear();


            Console.WriteLine("Итоговый граф в виде матрицы смежности:");
            foreach(Node n in nodes)
            {
                if(n.Arc.Count == 0) //если связей нет
                {
                    for (int i = 0; i < nodes.Count; i++)
                    { Console.Write("0"); }
                    Console.WriteLine();
                    continue;
                }
                int j = 0;
                int y = 0;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if (j == n.Arc.Count) { j--; }
                    if (nodes.ElementAt(y).Name == n.Arc.ElementAt(j).Name) { Console.Write(n.Weight.ElementAt(j)); j++; }
                    else { Console.Write("0"); }
                    y++;
                    // Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //поиск в глубину
            A:
            Console.WriteLine("Введите имя вершины с которой надо начать обход в глубину:");
            string name = Console.ReadLine();
            Console.WriteLine();

            int index = 0;
            foreach(Node n in nodes)
            {
                if(nodes.ElementAt(index).Name == name) { break; }
                index++;
                if (index == nodes.Count) { Console.WriteLine("Введена несуществующая вершина!!! Повторите ввод."); goto A; }
            }
            var stack = new Stack<Node>();
            var visitedNodes = new Stack<Node>();
            stack.Push(nodes.ElementAt(index));
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (!visitedNodes.Contains(node))
                {
                    Console.WriteLine(node.Name);
                    visitedNodes.Push(node);
                }
                foreach (var i in node.Arc)
                {
                    if (!visitedNodes.Contains(i))
                    {
                        stack.Push(i);
                    }
                }

            }

        }
    }
}
