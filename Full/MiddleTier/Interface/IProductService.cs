using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedAll.DTO;
using SharedAll.Models;

namespace Back.MiddleTier.Interface
{
    public interface IProductService
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>>  GetAllProducts();
        Task<Product> AddProduct(ProductDTO productDto);
    }
}
