using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    public class CompositeCondition
    {
        private readonly List<Func<bool>> _conditions = new();

        public void Add(Func<bool> condition)
        {
            _conditions.Add(condition);
        }

        public void Remove(Func<bool> condition)
        {
            _conditions.Remove(condition);
        }

        public bool IsTrue()
        {
            foreach (var condition in _conditions)
            {
                if (condition.Invoke() == false)
                    return false;
            }

            return true;
        }
    }
}