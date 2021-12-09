using GraphQLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        Product GetProductById(int Id);
        Product AddProduct(Product product);
        Product UpdateProduct(int Id, Product product);
        void DeleteProduct(int Id);
    }
}
