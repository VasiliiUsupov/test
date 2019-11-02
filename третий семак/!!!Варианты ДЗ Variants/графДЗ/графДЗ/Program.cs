using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace графДЗ
{
    class Program
    {
        public class Node
        {
            public string Name { get; set; }
            public List<Node> Arc { get; set; }
            public List<int> Weight { get; set; }
        }

        public class Graph
        {
            public List<Node> Nodes { get; set; }

            public void Search(Node startPoint, HashSet<Node> visitedNodes)
            {
                Console.WriteLine(startPoint.Name);
                visitedNodes.Add(startPoint);
                foreach (var node in startPoint.Arc)
                {
                    if (!visitedNodes.Contains(node))
                        Search(node, visitedNodes);
                }
            }

            public void Dfs(Node startPoint)
            {
                var stack = new Stack<Node>();
                var visitedNodes = new HashSet<Node>();
                stack.Push(startPoint);
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    Console.WriteLine(node.Name);
                    visitedNodes.Add(node);
                    foreach (var i in node.Arc)
                    {
                        if (!visitedNodes.Contains(i))
                            stack.Push(i);
                    }

                }

            }
        }

        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>();

            while (true)
            {
                int f;
                Console.WriteLine("Вы хотите создать вершину?");
                Console.WriteLine("1-да    0-нет");
                f = int.Parse(Console.ReadLine());
                //Console.WriteLine(f);
                if (f == 0) { break; }                  
                else if (f != 1) { Console.WriteLine("Невеный ввод!!! Повторите попытку.");continue; }           //проверка ввода f

                Console.WriteLine("Введите имя вершины(0-недопустимое имя):");
                string n1 = Console.ReadLine();
                if (n1 == "0") { Console.WriteLine("Недопустимый ввод! Повторите попытку!"); continue; }  //проверка ввода имени

                Node n = new Node();
                n.Name = n1;
                nodes.Add(n);
            }

            foreach(Node n in nodes) //цикл для запроса связей
            {
                n.Arc = new List<Node>();
                while (true) 
                {
                    string f1;
                    Console.WriteLine("Введите одну вершину с которой связана вершина {0}", n.Name);
                    Console.WriteLine("Если она не связана ни с одной вершиной или ввод вершин закончен введите 0");
                    f1 = Console.ReadLine();
                    if (f1 == "0") break;
                    int i = 1;
                    foreach (Node m in nodes)  //цикл для проверки наличия вершины и добавления связи
                    {
                        if(m.Name == f1) { n.Arc.Add(m); break; }
                        if(i == nodes.Count) { Console.WriteLine("Введена несуществующая вершина!Повторите ввод!!!"); break; }
                        i++;
                    }
                }
            }

            foreach(Node n in nodes)  //цикл для запроса веса связей
            {
                n.Weight = new List<int>();
                Console.WriteLine("Введите вес связей вершины {0}", n.Name);
                int y = 0;
                foreach (Node m in n.Arc)
                {
                    Errorw:
                    Console.WriteLine("Вес связи с вершиной {0}", m.Name);
                    int w = int.Parse(Console.ReadLine());
                    if (w <= 0) { Console.WriteLine("Вес не может быть меньше или равен 0! Повторите ввод."); goto Errorw; }
                    n.Weight.Add(w);
                    y++;
                }
            }

            var graph = new Graph();
            graph.Nodes = nodes;
            /*
            foreach(Node n in nodes) //Вывод матрицы на экран
            {
                for (int x = 0;x < n.Arc.Count;x++)
                {
                    foreach(Node m in nodes)
                    {
                        if (m == n.Arc[x]) { Console.Write(n.Weight[x]); }
                        else { Console.Write('0'); }
                    }
                    Console.WriteLine();
                }
               Console.WriteLine();

            }
            */
            Console.WriteLine("Введите вершину с которой начать обход:");
            string start = Console.ReadLine();
            Node realstart = nodes[1];
            int count = 1;
            foreach (Node m in nodes)
            {
                if (m.Name == start) { realstart = m; break; }
                if (count == nodes.Count) { Console.WriteLine("Введена несуществующая вершина! Обход начнётся с {0}", nodes[1].Name); }
                count++;
            }
            graph.Dfs(realstart);
        }
    }
    
}
