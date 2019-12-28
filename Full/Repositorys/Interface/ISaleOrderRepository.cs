using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedAll.Models;

namespace Back.Repositorys.Interface
{
    public interface ISaleOrderRepository : IRepository<SaleOrder>
    {
        Task<SaleOrder> GetSaleOrders(int id);
        Task<List<SaleOrder>> GetAllSaleOrders();
    }
}
