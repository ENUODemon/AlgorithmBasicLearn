﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBasicLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lists = { 2, 66, 53, 54, 52, 76, 42, 33, 18, 99 };
            lists = BasicSort.QuickSort(lists,0,lists.Count()-1);

            foreach (var l in lists)
            {
                Console.WriteLine(l);
            }
            Console.Read();
        }

    }
}
