using P03.DetailPrinter;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer
{
    public class Worker : Employee
    {
        public Worker(string name) 
            : base(name)
        {
        }

        public override string Print()
        {
            return this.Name;
        }
    }
}
