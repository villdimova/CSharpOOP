﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IBuyer
    {
        public int Food { get; set; }
        public string Name { get; set; }

        public int BuyFood();
       
    }
}
