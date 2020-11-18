namespace ReflectionDemo
{
   public abstract class Animal
    {
        protected Animal(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        
    }
}
