using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedAll.Models;

namespace Back.Repositorys.Interface
{
    public interface ISaleOrderDetailsRepository : IRepository<SaleOrderDetail>
    {
        Task<List<SaleOrderDetail>> GetAllSaleOrderDetails();
    }
}
