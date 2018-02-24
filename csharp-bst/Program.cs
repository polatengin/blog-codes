using System;
using System.Collections.Generic;

namespace bst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var nodeValues = new List<int>();

            var random = new Random();
            for(var iLoop = 0; iLoop <= 15; iLoop++)
            {
                nodeValues.Add(random.Next(1, 10000));
            }

            var tree = new Tree<int>();
            tree.Add(nodeValues.ToArray());

            var result = tree.Display();

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
