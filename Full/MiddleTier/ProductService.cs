using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Back.Const;
using Back.MiddleTier.Interface;
using Back.Repositorys.Interface;
using Microsoft.EntityFrameworkCore;
using SharedAll.DTO;
using SharedAll.Models;

namespace Back.MiddleTier
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(
            IProductRepository productRepository
        )
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductById(int id)
        {
           return await _productRepository.GetProduct(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<Product> AddProduct(ProductDTO productDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO ,Product >());
            var mapper = new Mapper(config);
            Product product = mapper.Map<Product>(productDto);
            var res = await _productRepository.AddProduct(product);
            return res;
        }

        public async Task<Product> PutProduct(ProductDTO productDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>());
            var mapper = new Mapper(config);
            Product product = mapper.Map<Product>(productDto);
            product.ProductId = productDto.Id;
            var res = await _productRepository.PutProduct(product);
            return res;
        }

        
        public async Task<string> DeleteProduct(int id)
        {
            var res = await _productRepository.Delete(id);
            if (res)
            {
                return SysConst.DeleteSuccessful; // Task.FromResult(SysConst.DeleteSuccessful); 
            }
            else
            {
                return SysConst.SomethingWentWrong; //Task.FromResult(SysConst.SomethingWentWrong);
            }
            
        }
    }
}
