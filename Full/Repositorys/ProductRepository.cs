using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Const;
using Back.Context;
using Back.Repositorys.Interface;
using Microsoft.EntityFrameworkCore;
using SharedAll.Models;

namespace Back.Repositorys
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)// : base(context)
        {
            _context = context;
        }

        public Task<Product> Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {

            var delProduct = await _context.Products.FindAsync(id);
            _context.Products.Remove(delProduct);
            var res = _context.SaveChanges();
            if (res> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Product> GetProduct(int id)
        {
            try
            {
                var res = await _context.Products.FindAsync(id);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
           
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }

        Task<Product> IRepository<Product>.Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var res = await _context.Products.ToListAsync();
            return res;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var res = await _context.Products.ToListAsync();
            return res;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var res = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return res.Entity;
        }
        
        public async Task<Product> PutProduct(Product product)
        {
            var oldProduct = await _context.Products.FindAsync(product.ProductId);
            oldProduct.Barcode = product.Barcode;
            oldProduct.CategoryId = product.CategoryId;
            oldProduct.Description = product.Description;
            oldProduct.Name = product.Name;
            var res = _context.Products.Update(oldProduct);
             _context.SaveChanges();
            return res.Entity;
        }

    }
}
