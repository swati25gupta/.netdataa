using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Item : IComparable<Item>
    {
        public Item()
        {
            //Default...
        }
        public Item(ProductTable product)
        {
            this.ID = product.ProductID;
            this.Name = product.ProductName;
            this.Price = Convert.ToDouble(product.ProductCost);
            this.Quantity = product.Quantity;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public int CompareTo(Item other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
namespace BusinessLayer
{
    using DataAccessLibrary;
    using DataAccessLibrary.Models;
    using Entities;
    
    public interface IBusinessComponent
    {
        List<Item> GetItems();
        List<Item> FindItems(string itemName);
        void AddNewItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int id);
    }

    public class BusinessObject : IBusinessComponent
    {

        public void AddNewItem(Item item)
        {
            try
            {
                //Convert Item to Product...
                var product = new ProductTable
                {
                    ProductID = item.ID,
                    ProductName = item.Name,
                    ProductCost = Convert.ToDecimal(item.Price),
                    Quantity = item.Quantity
                };
                //Create the Instance of the dal component
                var com = DataFactory.GetComponent();
                //Call its add Method
                com.AddNewProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DeleteItem(int id)
        {
            try
            {
                var com = DataFactory.GetComponent();
                com.DeleteProduct(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Item> FindItems(string itemName)
        {
            //Get All Products
            var com = DataFactory.GetComponent();
            var products = com.GetAllProducts();
            var selectedProducts = products.FindAll(p => p.ProductName.Contains(itemName));
            //Find a Subset of products based on Name
            //Convert all the Subset of products to Items
            List<Item> allItems = new List<Item>();
            foreach(var p in selectedProducts)
            {
                allItems.Add(new Item(p));
            }
            //return the items....
            return allItems;
        }

        public List<Item> GetItems()
        {
            //Get all the products from the Dal..
            var com = DataFactory.GetComponent();
            var products = com.GetAllProducts();
            //Convert all products to Items
            List<Item> allItems = new List<Item>();
            foreach (var p in products)
            {
                allItems.Add(new Item(p));
            }
            allItems.Sort();
            return allItems;
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException("Do it URself...");
        }
    }
}
