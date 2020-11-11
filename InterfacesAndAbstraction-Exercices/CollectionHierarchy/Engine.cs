using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy
{
    public class Engine
    {
    
            ICollection<int> addCollectionIndexes = new List<int>();
            ICollection<int> addRemoveCollectionIndexes = new List<int>();
            ICollection<int> myListIndexes = new List<int>();
            ICollection<string> addRemoveCollectionRemovedItems = new List<string>();
            ICollection<string> myListRemovedItems = new List<string>();
        
        public void Run()
        {
            string[] data = Console.ReadLine().Split(" ");

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var item in data)
            {
                addRemoveCollectionIndexes.Add(addRemoveCollection.Add(item));
                myListIndexes.Add(myList.Add(item));
                addCollectionIndexes.Add(addCollection.Add(item));
            }
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                addRemoveCollectionRemovedItems.Add(addRemoveCollection.Remove());
                myListRemovedItems.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", addCollectionIndexes));
            Console.WriteLine(string.Join(" ", addRemoveCollectionIndexes));
            Console.WriteLine(string.Join(" ", myListIndexes));
            Console.WriteLine(string.Join(" ", addRemoveCollectionRemovedItems));
            Console.WriteLine(string.Join(" ", myListRemovedItems));
        }
    }
}
