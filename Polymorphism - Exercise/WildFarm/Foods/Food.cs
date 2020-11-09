namespace WildFarm.Foods
{
    public abstract class Food
    {
        private int quantity;

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get { return quantity; }
            internal set { quantity = value; }
        }

    }
}
