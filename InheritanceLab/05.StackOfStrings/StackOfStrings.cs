using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        
        public bool IsEmpty()
        {
            if (this.Count==0)
            {
                return true;
            }
            return false;
        }
        public void AddRange(IEnumerable<string> values)
        {
            foreach (var item in values)
            {
                this.Push(item);
            }
            
        }
    }
}
