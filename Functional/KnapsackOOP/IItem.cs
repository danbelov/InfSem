using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackOOP
{
    internal interface IItem
    {
            Guid Id { get; set; }
            string Name { get; set; }
            int Weight { get; set; }
            int Value { get; set; }
    }
}
