using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    public class CompositeCondition
    {
        private List<Func<bool>> _conditions = new();

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
            for (int i = 0; i < _conditions.Count; i++)
            {
                var condition = _conditions[i];
                if (condition.Invoke() == false)
                    return false;
            }
            return true;
        }
    }
}