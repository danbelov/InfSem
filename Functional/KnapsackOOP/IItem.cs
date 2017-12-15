using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackOOP
{
    interface IItem
    {
            Guid Id { get; set; }
            string Name { get; set; }
            int Square { get; set; }
            int Value { get; set; }
            int Quantity { get; set; }
    }
}
