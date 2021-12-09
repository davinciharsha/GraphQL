using GraphQLProject.Interfaces;
using System.Collections.Generic;
using GraphQLProject.Models;
using System.Linq;

namespace GraphQLProject.Services
{
    public class ProductService : IProduct
    {
        private static List<Product> products = new List<Product>()
        {
            new Product(){Id=1, Name="Coffee", Price=15 },
            new Product(){Id=2, Name="Chocolate", Price=25 }
        };

        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        public void DeleteProduct(int Id)
        {
            var index = products.FindIndex(x => x.Id == Id);
            products.RemoveAt(index);

        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int Id)
        {
            return products.Find(x => x.Id == Id);
        }

        public Product UpdateProduct(int Id, Product product)
        {
            var index = products.FindIndex(x => x.Id == Id);
            products[index] = product;
            return product;
        }
    }
}
