﻿using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = new RandomList { "eli", "maria", "petya", "moni" };
            Console.WriteLine(list.RandomString());
            Console.WriteLine(String.Join(",", list));
        }
    }
}
