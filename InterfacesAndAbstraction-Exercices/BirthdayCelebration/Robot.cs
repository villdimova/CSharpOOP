﻿using System;


namespace BirthdayCelebration
{
    public class Robot : IIdentifiable
    {

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Id { get; set; }
        public string Model { get; set; }


    }
}
