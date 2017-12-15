using System;
using System.Collections.Generic;
using System.Text;

namespace KnapsackOOP
{
    internal class Item : IItem, IEquatable<Item>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }

        public int ResultingPartialWeight => Weight - Value;

        public Item() => Id = Guid.NewGuid();

        public int CompareTo(object obj)
        {
            var item2 = (Item)obj;
            return this.Weight / this.Value > item2.Weight / item2.Value ? 1 : 0;
        }

        public override string ToString()
        {
            return $"{Name} " +
                   $"with weight: {Weight}  " +
                   $"and relative value: {Value} ,";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Item);
        }

        public bool Equals(Item obj)
        {
            return obj != null
                   && obj.Id == this.Id
                   && obj.Name == this.Name
                   && obj.Value == this.Value
                   && obj.Weight == this.Weight;
        }

        public override int GetHashCode()
        {
            var hashCode = -808003945;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Weight.GetHashCode();
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + ResultingPartialWeight.GetHashCode();
            return hashCode;
        }
    }
}

