using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;
        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;
        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;

                }

                return  base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);

            }

        }

        public override decimal Price =>
            this.Peripherals.Sum(p => p.Price) +
            this.Components.Sum(p => p.Price) +
            base.Price;
       
        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }

            this.components.Add(component);

        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(p => p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);

        }
        public IComponent RemoveComponent(string componentType)
        {
            var removedComponent = this.components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (removedComponent == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            else
            {
                this.components.Remove(removedComponent);
                return removedComponent;
            }
        }
        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var removedPeripheral = this.peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);
            if (removedPeripheral == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            else
            {
                this.peripherals.Remove(removedPeripheral);
                return removedPeripheral;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Overall Performance: {this.OverallPerformance:f2}. Price: {this.Price:f2} - {this.GetType().Name}: {this.Manufacturer} {this.Model} (Id: {this.Id})");
            sb.AppendLine($" Components ({this.Components.Count}):");
            if (this.Components.Count>0)
            {
                foreach (var component in components)
                {
                    sb.AppendLine($"  {component.ToString()}");
                }
            }
           
            
            if (this.Peripherals.Count>0)
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.peripherals.Average(p => p.OverallPerformance)}):");
                foreach (var peripheral in peripherals)
                {
                    sb.AppendLine($"  {peripheral.ToString()}");
                }

            }
            else
            {
                sb.AppendLine($" Peripherals (0); Average Overall Performance (0):");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
