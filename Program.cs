using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Shortener
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path to the directory.");
            string strDir = Console.ReadLine();
            Console.WriteLine("Enter number of characters to remove from each file.");
            int charactersToRemove = int.Parse(Console.ReadLine());
            IEnumerable<string> files = Directory.EnumerateFiles(strDir);
            foreach (string f in files)
            {
                string suffix = f.Substring(f.LastIndexOf("."), f.Length - f.LastIndexOf("."));
                File.Move(f, f.Remove(f.Length - charactersToRemove - suffix.Length) + suffix);
            }
            files = Directory.EnumerateFiles(strDir);
            Console.WriteLine("Done");
        }
    }
}
