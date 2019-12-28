using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedAll.Models;

namespace Back.Repositorys.Interface
{
  public interface IProductRepository : IRepository<Product>
  {
      Task<Product> GetProduct(int id);
      Task<List<Product>> GetAllProducts();
      Task<Product> AddProduct(Product product);
  }
}
