using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedAll.DTO;
using SharedAll.Models;

namespace Back.MiddleTier.Interface
{
    public interface ISaleOrderSevrice
    {
        Task<SaleOrder> GetSaleOrderById(int id);
        Task<List<SaleOrder>> GetAllSaleOrder();
        Task<List<SaleDTO>> GetAllSale();
        Task<List<SaleDTO>> GetPaginationSale(
            int page,
            int pageSize);
    }
}
