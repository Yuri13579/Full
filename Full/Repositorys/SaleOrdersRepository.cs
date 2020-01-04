using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Context;
using Back.Repositorys.Interface;
using Microsoft.EntityFrameworkCore;
using SharedAll.DTO;
using SharedAll.Models;

namespace Back.Repositorys
{
    public class SaleOrdersRepository : ISaleOrderRepository
    {
        private readonly ApplicationContext _context;
        public SaleOrdersRepository(ApplicationContext context)// : base(context)
        {
            _context = context;
        }

        public async Task<SaleOrder> Add(SaleOrder entity)
        {
           var s = await _context.SaleOrders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return s.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            var delSaleOrders = await _context.SaleOrders.FindAsync(id);
            _context.SaleOrders.Remove(delSaleOrders);
            var res = _context.SaveChanges();
            if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<SaleOrder> Get(int id)
        {
            return await _context.SaleOrders.FindAsync(id);
        }

        public Task<List<SaleOrder>> GetAll()
        {
            return _context.SaleOrders.ToListAsync();
          //  return await _context.SaleOrders.ToListAsync();
        }

        public Task<List<SaleOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SaleOrder>>  GetAllSaleOrders()
        {
            var res = await _context.SaleOrders.ToListAsync();
            return res;
        }

        public Task<SaleOrder> GetSaleOrders(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SaleOrder> Update(SaleOrder entity)
        {
            throw new NotImplementedException();
        }

        //public Task<List<SaleDTO>> GetPaginationSale()
        //{
        //    var res = await _context.


        //    return null;
        //}
    }
}
