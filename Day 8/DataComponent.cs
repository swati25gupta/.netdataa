using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    using DataAccessLibrary.Models;
    //Know how to create interface and its methods....
    public interface IDataComponent
    {
        List<ProductTable> GetAllProducts();
        void UpdateProduct(ProductTable product);
        void AddNewProduct(ProductTable product);
        void DeleteProduct(int productID);
    }

    public class DataFactory
    {
        public static IDataComponent GetComponent()
        {
            return new DataComponent();
        }
    }

    class DataComponent : IDataComponent
    {

        public void AddNewProduct(ProductTable product)
        {
            ProductEntities entities = new ProductEntities();
            if (product == null)
            {
                throw new Exception("Product details are not set");
            }
            entities.ProductTables.Add(product);
            entities.SaveChanges();

        }

        public void DeleteProduct(int productID)
        {
            ProductEntities entities = new ProductEntities();
            if (productID <= 0)
            {
                throw new Exception("Not a valid Product ID to delete");
            }
            //find the product in our table matching the id of the passed object..
            var foundProduct = entities.ProductTables.FirstOrDefault(p => p.ProductID == productID);
            if (foundProduct == null)
            {
                throw new Exception("No Product is found to delete");
            }
            entities.ProductTables.Remove(foundProduct);
            entities.SaveChanges();
        }

        public List<ProductTable> GetAllProducts() => new ProductEntities().ProductTables.ToList();

        public void UpdateProduct(ProductTable product)
        {
            ProductEntities entities = new ProductEntities();
            if (product == null)
            {
                throw new Exception("Product details are not set to update");
            }
            //find the product in our table matching the id of the passed object..
            var foundProduct = entities.ProductTables.FirstOrDefault(p => p.ProductID == product.ProductID);
            if(foundProduct == null)
            {
                throw new Exception("No Product is found to update");
            }
            foundProduct.ProductName = product.ProductName;
            foundProduct.ProductCost = product.ProductCost;
            foundProduct.Quantity = product.Quantity;
            entities.SaveChanges();
        }
    }
}
