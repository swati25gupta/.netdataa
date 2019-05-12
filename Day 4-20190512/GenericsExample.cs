using System;
using System.Collections.Generic;
/*
 * Generics are type safe collections introduced in .NET 2.0.
 * U can still use the older collections under the namespace System.Collections. 
 * All Generic collection classes implement a certain no of interfaces to give a set of common operations. 
 * U could create UR own custom Collections by implementing those interfaces. 
 * Some of the readyto use classes: List<T>, HashSet<T>, Dictionary<K,V>, Queue<T>, Stack<T>..
 * Collections were created to resolve the limitations of Arrays. This include fixed size and same format of storing the elements. (top to bottom)
 */
namespace SampleConApp
{
    class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Cost { get; set; }

        public override int GetHashCode()
        {
            return ItemName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Item)
            {
                return this.ItemName == (obj as Item).ItemName;
            }
            return false;
        }
    }

    
    class GenericDemo
    {
        static void Main(string[] args)
        {
            //listExample();//Complete alternative to Arrays...
            //hashsetExample();
            //basketExample();
            //dictionaryExample();
            //Queue and Stack:Do it urself...
        }

        private static void dictionaryExample()
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(1, "Phaniraj");
            employees.Add(2, "Banu Prakash");
            employees.Add(3, "Vinod");
            if(employees.ContainsKey(1))
                Console.WriteLine("ID already exists");
            else
               employees.Add(1, "Ramnath");
            employees[4] = "JoyDip Mondal";//This will add if the key does not exist in the dictionary, else it replaces the value of that key...
            //foreach(KeyValuePair<int, string> pair in employees)
              //  Console.WriteLine($"Key:{pair.Key}, Value:{pair.Value}");
              foreach(int key in employees.Keys)
                Console.WriteLine($"Key:{key}, Value:{employees[key]}");
        }

        private static void basketExample()
        {
            HashSet<Item> basket = new HashSet<Item>();
            basket.Add(new Item { ItemID = 12, Cost=560, ItemName="Tin Pack"});
            basket.Add(new Item { ItemID = 12, Cost=560, ItemName="Tin Pack"});
            Console.WriteLine("The total no: " + basket.Count);
        }

        private static void hashsetExample()
        {
            HashSet<string> basket = new HashSet<string>();
            basket.Add("Apple");
            basket.Add("PineApple");//Add works like List<T>::Add but stores only unique value
            basket.Add("Mango");
            basket.Add("Apple");//No duplicates are allowed...
            basket.Add("Apple");
            Console.WriteLine("The no of items: " + basket.Count);
        }

        private static void listExample()
        {
            //list implements IList
            List<string> items = new List<string>();
            items.Add("Potatoes");//Adds to the bottom of the list....
            items.Add("Tomatoes");
            items.Add("Onions");
            items.Insert(2, "Mangoes");
            items.Add("Chillies");
            items.Add("Coconuts");
            Console.WriteLine("The no of elements in the basket:" + items.Count);//gets the no of elements...
            foreach(string item in items)
                Console.WriteLine(item);
            if(items.Remove("Tomatoe"))
                Console.WriteLine("Removed successfully");
            else
                Console.WriteLine("No item found to remove");

        }
    }
}