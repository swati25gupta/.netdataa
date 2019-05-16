using System;
using System.Collections.Generic;
/*
 * Ability to compare 2 objects of the same type is required for reasons like sorting. 
 * Sort method of the List<T> looks for objects that are comparable.
 * A Class that implements IComparable has the ability to be compared. 
 * If U want to compare on multiple criteria, then  U could create a seperate class that implements IComparer<T> which provides a function called Compare that has 2 args of the type U R Comparing.
 * Sort method of the List<T> is overloaded to do default sorting thro IComparable Interface(Sort()), another with IComparer interface object which is used to compare on multiple conditions(Sort(IComparer comparer)).  
 */
namespace SampleConApp
{
    enum ItemType { ID, Name, Cost }
    class ItemComparer : IComparer<Item>
    {
        ItemType comparingType;
        public ItemComparer(ItemType comparingType)
        {
            this.comparingType = comparingType;
        }
        public int Compare(Item x, Item y)
        {
            switch (comparingType)
            {
                case ItemType.ID:
                    return x.ItemID.CompareTo(y.ItemID);
                case ItemType.Name:
                    return x.CompareTo(y);
                case ItemType.Cost:
                    return x.Cost.CompareTo(y.Cost);
                default:
                    return 0;
            }
        }
    }
    class Item : IComparable<Item>
    {
        public override string ToString()
        {
            return $"Name:{ItemName}, Cost:{Cost}, ID:{ItemID}";
        }
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Cost { get; set; }

        public override int GetHashCode()
        {
            return ItemName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Item)
            {
                return this.ItemName == (obj as Item).ItemName;
            }
            return false;
        }

        public int CompareTo(Item other)
        {
            return this.ItemName.CompareTo(other.ItemName);
        }
    }
    class ObjectComparision
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            items.Add(new Item { ItemID = 111, ItemName = "Samsung GURU", Cost = 1200 });
            items.Add(new Item { ItemID = 121, ItemName = "Apple S3", Cost = 56200 });
            items.Add(new Item { ItemID = 101, ItemName = "MI Note5", Cost = 11200 });
            items.Add(new Item { ItemID = 131, ItemName = "Samsung Note5", Cost = 41200 });
            items.Add(new Item { ItemID = 145, ItemName = "OPPO V3", Cost = 21200 });
            //basicSort(items);
            comparingSort(items);
        }

        private static void comparingSort(List<Item> items)
        {
            items.Sort(new ItemComparer(ItemType.ID));
            foreach(var item in items)
                Console.WriteLine(item);
        }

        private static void basicSort(List<Item> items)
        {
            foreach (var item in items)
                Console.WriteLine(item.ItemName);
            Console.WriteLine("After sorting....");

            items.Sort();//List Class

            foreach (var item in items)
                Console.WriteLine(item.ItemName);
        }
    }
}