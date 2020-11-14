using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();

        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);

            }

            else
            {
                if (aquariumType == "SaltwaterAquarium")
                {
                    aquarium = new SaltwaterAquarium(aquariumName);
                    this.aquariums.Add(aquarium);
                }

                else if (aquariumType == "FreshwaterAquarium")
                {
                    aquarium = new FreshwaterAquarium(aquariumName);
                    this.aquariums.Add(aquarium);
                }
                
                return $"Successfully added {aquariumType}.";

            }
            
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType!= "Ornament"&& decorationType!= "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDecoration);
            }
            else
            {
                if (decorationType == "Ornament")
                {
                    decoration = new Ornament();
                    this.decorations.Add(decoration);
                }
                else if (decorationType == "Plant")
                {
                    decoration = new Plant();
                    this.decorations.Add(decoration);
                }

                return $"Successfully added {decorationType}.";

            }
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;

            if (fishType==nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }

            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            if ((aquarium.GetType()==typeof(FreshwaterAquarium)&&fishType!=nameof(FreshwaterFish))||
                aquarium.GetType() == typeof(SaltwaterAquarium) && fishType != nameof(SaltwaterFish))
            {
               
                return OutputMessages.UnsuitableWater;
            }
            else
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
           
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal value = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            foreach (var fish in aquarium.Fish)
            {
                fish.Eat();
            }

            int countFish = aquarium.Fish.Count();
            return string.Format(OutputMessages.FishFed, countFish);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.FindByType(decorationType);
            IAquarium aquarium = this.aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (decoration==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType,aquariumName);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
