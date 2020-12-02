using OnlineShop.Models.Products.Computers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {

        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComputer> Computers => this.computers;
        public IReadOnlyCollection<IComponent> Components => this.components;
        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckIfComputerExists(computerId);
            var wantedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            IComponent component=null;

            if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);

            }

            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);

            }
            else if (componentType == nameof(VideoCard))
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            var createdComponent = this.components.FirstOrDefault(c => c.Id == id);
            if (createdComponent != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            this.components.Add(component);
            wantedComputer.AddComponent(component);
            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

        }



        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            
            if (computerType == nameof(Laptop))
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }


            var wantedComputer = this.computers.FirstOrDefault(c => c.Id == id);
            if (wantedComputer != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            this.computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer,id);

        }


        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckIfComputerExists(computerId);
            var wantedComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            IPeripheral peripheral;

            if (peripheralType == nameof(Headset))
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);

            }
            else if (peripheralType == nameof(Keyboard))
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);

            }

            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            var createdPeripheral = this.peripherals.FirstOrDefault(p => p.Id == id);
            if (createdPeripheral != null)
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            this.peripherals.Add(peripheral);
            wantedComputer.AddPeripheral(peripheral);
            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);


        }

        public string BuyBest(decimal budget)
        {
            var computer = this.Computers.OrderByDescending(x => x.OverallPerformance).FirstOrDefault(x => x.Price <= budget);

            if (computer==null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckIfComputerExists(id);

            var computer = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(computer);

            return computer.ToString();

        }

       
        public string GetComputerData(int id)
        {
            CheckIfComputerExists(id);
            var computer=this.computers.FirstOrDefault(c => c.Id == id);

            return computer.ToString();
        }


        public string RemoveComponent(string componentType, int computerId)
        {
            CheckIfComputerExists(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.RemoveComponent(componentType);
            var removedComponent = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(removedComponent);
            return String.Format(SuccessMessages.RemovedComponent, componentType, removedComponent.Id);

        }


        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckIfComputerExists(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.RemovePeripheral(peripheralType);
            var removedPeripheral = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            this.peripherals.Remove(removedPeripheral);
            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, removedPeripheral.Id);
        }

        public void CheckIfComputerExists(int id)
        {
            var computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        
    }
}
