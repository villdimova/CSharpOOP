namespace CollectionHierarchy
{
    using System;
    using System.Collections.Generic;

    public class AddCollection : IAddCollection
    {
        private readonly List<string> Collection;

        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        public int Add(string item)
        {
            if (this.Collection.Count<100)
            {
                
                this.Collection.Add(item);
            }
            
            int index = this.Collection.Count - 1;
            return index;
        }
    }
}
