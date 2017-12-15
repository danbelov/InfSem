using System;
using System.Collections.Generic;

namespace KnapsackOOP
{
    class Program
    {
        /* 
         * This is a
         * TEST DATA which is
         * taken here: https://people.sc.fsu.edu/~jburkardt/datasets/knapsack_01/knapsack_01.html 
         * And belongs to its respective owners.
         * Data Set ID: P07
         * 
         * Correct weights selection:
         * A1 - 1
         * A2 - 0
         * A3 - 1
         * A4 - 0
         * A5 - 1
         * A6 - 0
         * A7 - 1
         * A8 - 1
         * A9 - 1
         * A10 - 0
         * A11 - 0
         * A12 - 0
         * A13 - 0
         * A14 - 1
         * A15 - 1
         */
        static void Main(string[] args)
        {
            int maxWeight = 750;
            ICollection<Item> testItems = new List<Item>
            {
                new Item { Name = "A1", Weight = 70, Value = 135 },
                new Item { Name = "A2", Weight = 73, Value = 139 },
                new Item { Name = "A3", Weight = 77, Value = 149 },
                new Item { Name = "A4", Weight = 80, Value = 150 },
                new Item { Name = "A5", Weight = 82, Value = 156 },
                new Item { Name = "A6", Weight = 87, Value = 163 },
                new Item { Name = "A7", Weight = 90, Value = 173 },
                new Item { Name = "A8", Weight = 94, Value = 184 },
                new Item { Name = "A9", Weight = 98, Value = 192 },
                new Item { Name = "A10", Weight = 106, Value = 201 },
                new Item { Name = "A11", Weight = 110, Value = 210 },
                new Item { Name = "A12", Weight = 113, Value = 214 },
                new Item { Name = "A13", Weight = 115, Value = 221 },
                new Item { Name = "A14", Weight = 118, Value = 229 },
                new Item { Name = "A15", Weight = 120, Value = 240 }
            };
            Console.WriteLine("Hello World!");
        }
    }
}
