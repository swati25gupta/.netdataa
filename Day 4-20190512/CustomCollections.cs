using System;
using System.Collections;
using System.Collections.Generic;
//namespace can span across multiple files...
namespace SampleConApp
{
    class Basket : IEnumerable<Item>
    {
        public Item this[int index]//indexer....
        {
            get { return _items[index]; }
        }
        public int Length
        {
            get
            {
                return _items.Count;
            }
        }
        private List<Item> _items = new List<Item>();

        public void AddToBasket(Item item)
        {
            _items.Add(item);
        }

        public void Remove(Item item)
        {
            foreach(Item i in _items)
            {
                if (i.Equals(item))
                {
                    _items.Remove(i);
                    return;
                }
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public int TotalBill//read only property....
        {
            get
            {
                int total = 0;
                foreach (Item i in _items)
                    total += i.Cost;
                return total;
            }
        }

       
    }
    class Cls
    {
        public int data;
        public override bool Equals(object obj)
        {
            if(obj is Cls)
            {
                var temp = obj as Cls;
                if (temp.data == this.data)
                    return true;
                else return false;
            }
            return false;
        }
    }
    class CustomCollectionExample
    {
        static void Main(string[] args)
        {
            Cls obj = new Cls();
            obj.data = 123;
            Cls obj2 = new Cls();
            Console.WriteLine(obj.Equals(obj2));//false
            //Basket flipKart = new Basket();
            //flipKart.AddToBasket(new Item { ItemID = 1, Cost = 56, ItemName = "Chillies" });
            //flipKart.AddToBasket(new Item { ItemID = 1, Cost = 56, ItemName = "Chillies" });
            //flipKart.AddToBasket(new Item { ItemID = 1, Cost = 56, ItemName = "Chillies" });
            //flipKart.AddToBasket(new Item { ItemID = 1, Cost = 56, ItemName = "Chillies" });
            //Console.WriteLine("The total Bill:" + flipKart.TotalBill);

            ////foreach (Item item in flipKart)
            ////    Console.WriteLine(item.ItemName);

            //for (int i = 0; i < flipKart.Length; i++)
            //{
            //    Console.WriteLine(flipKart[i]);
            //}
            //IEnumerator<Item> iterator = flipKart.GetEnumerator();
            //while(iterator.MoveNext())
            //    Console.WriteLine(iterator.Current.ItemName);
        }
    }
}