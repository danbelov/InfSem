
using System.Collections.Generic;
using System.Linq;

namespace KnapsackOOP
{
    internal class Knapsack : IEnumerable<Item>
    {
        private ICollection<Item> _itemList = new List<Item>();

        private IList<Item> _itemsInKnapsack = new List<Item>();

        private IList<Item> _itemsToChoose = new List<Item>();

        protected int MaxCapacity { get; }

        public Knapsack(int maxCapacity)
        {
            MaxCapacity = maxCapacity;
        }

        /// <summary>
        /// Recursive solve the 0-1 Knapsack problem using dynamic programming method.
        /// </summary>
        private bool RecSolve(int i, int lastBound, int indexToAdd)
        {
            while (true)
            {
                if (!(lastBound < 0))
                {
                    if (_itemsInKnapsack[i].ResultingPartialWeight < _itemsToChoose[lastBound].ResultingPartialWeight)
                    {
                        indexToAdd = lastBound;
                    }
                    lastBound = lastBound - 1;
                    continue;
                }
                if (indexToAdd <= -1) return false;
                _itemsToChoose.Insert(indexToAdd, _itemsInKnapsack[i]);
                return true;
            }
        }

        /// <summary>
        /// Returns an optimization suggestion (Solution of 0-1 Knapsack problem)
        /// </summary>
        public IEnumerable<Item> CalculateSuggestion(List<Item> items)
        {
            _itemsInKnapsack = items;
            foreach (var menuItem in CurrentSolutionsList())
            {
                if (this.Sum(j => j.Weight) + menuItem.Weight <= MaxCapacity) _itemList.Add(menuItem);
            }
            return this;
        }

        /// <summary>
        /// Returns a list of a current solution suggestion (not the final solution)
        /// </summary>
        private IEnumerable<Item> CurrentSolutionsList()
        {
            _itemsToChoose.Add(_itemsInKnapsack[0]);
            for (var i = 1; i < _itemsInKnapsack.Count; i++)
            {
                var j = -1;
                if (!RecSolve(i, _itemsToChoose.Count - 1, j))
                {
                    _itemsToChoose.Add(_itemsInKnapsack[i]);
                }

            }
            return _itemsToChoose;
        }

        #region IEnumerable<Item> Members
        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            foreach (Item i in _itemList)
                yield return i;
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _itemList.GetEnumerator();
        }
        #endregion
    }
}
