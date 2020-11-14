namespace AquaShop.Models.Fish
{
    public class SaltwaterFish: Fish
    {
        public SaltwaterFish(string name, string species, decimal price)
            : base(name, species, price)
        {
            this.Size = 5;
        }

        //TODO live only in SaltWaterAquarium
        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
