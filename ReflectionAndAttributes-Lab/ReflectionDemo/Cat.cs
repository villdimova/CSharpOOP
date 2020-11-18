using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionDemo
{
    public class Cat : Animal
    {
        private int id;

        public Cat(string name) : base(name)
        {
        }

        public int GetId()
        {
            return this.id;
        }
    }
}
