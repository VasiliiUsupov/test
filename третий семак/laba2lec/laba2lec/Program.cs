using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace laba2lec
{
    class Program
    {
        static void Main(string[] args)
        {
            string catalog = @"D:\ШАРАГА";
            string name = @"1.txt";

            foreach (string findedFile in Directory.EnumerateFiles(catalog, name,SearchOption.AllDirectories))
            {
                FileInfo FI;
                FI = new FileInfo(findedFile);
                Console.WriteLine(FI.Name + "\n" + FI.FullName + "\n" + FI.Length + " байт\n" + "Создан: " + FI.CreationTime + "\n");
            }
        }
    }
}
