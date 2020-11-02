﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double calories = 2;
        private readonly Dictionary<string, double> DefaultFlourTypes = new Dictionary<string, double>()
        {
            {"white",1.5},
            {"wholegrain",1.0}
        };

        private readonly Dictionary<string, double> DefaultBakingTechniques = new Dictionary<string, double>()
        {
            {"crispy",0.9},
            {"chewy",1.1},
            {"homemade",1.0}
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.Weight = weight;
            this.BakingTechnique = bakingTechnique;
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (!this.DefaultFlourTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (!this.DefaultBakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid baking technique.");
                }
                this.bakingTechnique = value.ToLower();
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value<1||value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double DoughCalories => this.DefaultFlourTypes[this.FlourType]
            * this.DefaultBakingTechniques[this.BakingTechnique]
            * calories
            * this.Weight;
            

    }
}
