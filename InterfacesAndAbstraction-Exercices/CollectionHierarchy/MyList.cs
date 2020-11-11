using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        public int Used => this.Collection.Count;

        public List<string> Collection { get; }

        public MyList()
        {
            this.Collection = new List<string>();
        }

        public int Add(string item)
        {
            if (this.Used < 100)
            {
                this.Collection.Insert(0, item);
                return 0;
            }
            return 0;
        }

        public string Remove()
        {
            string item = this.Collection[0];
            this.Collection.RemoveAt(0);
            return item;

        }
    }
}
