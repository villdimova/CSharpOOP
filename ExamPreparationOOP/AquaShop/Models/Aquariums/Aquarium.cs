using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
            this.Name = name;
            this.Capacity = capacity;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                capacity = value;
            }
        }
        public int Comfort => this.decorations.Sum(c => c.Comfort);
        public ICollection<IDecoration> Decorations
        {
            get
            {
                return this.decorations.AsReadOnly();
            }
        }
        public ICollection<IFish> Fish
        {
            get
            {
                return this.fish.AsReadOnly();
            }
        }

        public  void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }
        public  void AddFish(IFish fish)
        {
            if (this.Capacity<=this.fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }
        public  void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }
        public  string GetInfo()
        {
            if (this.Fish.Count==0)
            {
                Console.WriteLine("none");
            }

            StringBuilder sb = new StringBuilder();

            
            sb.AppendLine($"{this.Name} ({this.GetType().Name})");
            sb.AppendLine($"Fish: {string.Join(", ", this.Fish.Select(f=>f.Name))}");
            sb.AppendLine($"Decorations:  {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

           return sb.ToString().TrimEnd();

        }
        public  bool RemoveFish(IFish fish)
        {
            IFish removedFish = this.Fish.FirstOrDefault(f => f.Name == fish.Name);
            if (removedFish==null)
            {
                return false;
            }

            this.Fish.Remove(removedFish);
            return true;
        }
    }
}
