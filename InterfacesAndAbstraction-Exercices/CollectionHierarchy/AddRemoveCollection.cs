using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        public List<string> Collection { get; }

        public AddRemoveCollection()
        {
            this.Collection = new List<string>();
        }

        public int Add(string item)
        {
            if (this.Collection.Count<100)
            {
                this.Collection.Insert(0, item);
            }
            
            return 0;
        }

        public string Remove()
        {
            string item = this.Collection[this.Collection.Count - 1];
            this.Collection.Remove(item);
           
            return item;
        }
    }
}
