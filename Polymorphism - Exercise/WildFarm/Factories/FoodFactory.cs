namespace WildFarm.Factories
{
    using System;
    using WildFarm.Foods;
    public class FoodFactory
    {
       public Food GetFood(string typeFood,int quantity)
        {
            string type = typeFood.ToLower();
            if (type== "vegetable")
            {
                return new Vegetable(quantity);

            }
            else if (type == "fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "seeds")
            {
                return new Seeds(quantity);
            }
            else if (type == "meat")
            {
                return new Meat(quantity);
            }
            else
            {
                throw new ArgumentException("Invalid food!");
            }
        }

        
    }
}
