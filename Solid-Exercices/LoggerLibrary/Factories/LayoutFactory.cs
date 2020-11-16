using LoggerLibrary.Layots;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerLibrary.Factories
{
    public static class LayoutFactory
    {
        public static ILayout CreateLayout(string type)
        {
            if (type== "SimpleLayout")
            {
                return new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                return new XmlLayout();
            }

            else if (type == "JsonLayout")
            {
                return new JsonLayout();
            }

            else
            {
                throw new ArgumentException("Not valid Layout!");
            }
        }
    }
}
