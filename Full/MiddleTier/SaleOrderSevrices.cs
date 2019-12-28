using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.MiddleTier.Interface;
using Back.Repositorys.Interface;
using SharedAll.DTO;
using Microsoft.EntityFrameworkCore;
using SharedAll.Models;

namespace Back.MiddleTier
{
    public class SaleOrderSevrices : ISaleOrderSevrice
    {
        private readonly ISaleOrderRepository _saleOrderRepository;
        private readonly ISaleOrderDetailsRepository _saleOrderDetailsRepository;
        private readonly IProductRepository _productRepository;
    //    private readonly IRepository<Shop> _shop;

       public SaleOrderSevrices(ISaleOrderRepository saleOrderRepository,
            ISaleOrderDetailsRepository saleOrderDetailsRepository,
            IProductRepository productRepository
          //  ,IRepository<Shop> shop
           )
        {
            _saleOrderRepository = saleOrderRepository;
            _saleOrderDetailsRepository = saleOrderDetailsRepository;
            _productRepository = productRepository;
          //  _shop = shop;
        }

        public Task<List<SaleOrder>> GetAllSaleOrder()
        {
            return _saleOrderRepository.GetAllSaleOrders();
        }

        public Task<SaleOrder> GetSaleOrderById(int id)
        {
            return _saleOrderRepository.GetSaleOrders(id);
        }

        public async Task<List<SaleDTO>> GetAllSale()
        {
            
            var result =  (from saleOrder in _saleOrderRepository.GetAllSaleOrders().Result
                join detail in _saleOrderDetailsRepository.GetAllSaleOrderDetails().Result
                    on saleOrder.SaleOrderID equals detail.SaleOrderId.GetValueOrDefault()
                join product in _productRepository.GetAllProducts().Result
                 on detail.ProductId equals product.ProductId
               // join shop in _shop.GetAll() 
               //     on saleOrder.ShopId equals shop. 

                select new SaleDTO
                {
                    SaleOrderID = saleOrder.SaleOrderID,
                    SaleOrderDetailId= detail.SaleOrderDetailId,
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    ProductDescription = product.Description,
                    ProductBarcode = product.Barcode,
                    Count = detail.Count,
                    DataTime = saleOrder.DataTime,
                    PriceCost = detail.PriceCost,
                    PriseSale = detail.PriseSale,
                    Summ = detail.Summ,
                    ShopId = saleOrder.ShopId.GetValueOrDefault()
                    //  public string ShopName { get; set; }
                    //  public string ShopAddress { get; set; }
                }).ToList();

            return result;

        }


        public async Task<List<SaleDTO>> GetPaginationSale()
        {
            var query = (from saleOrder in _saleOrderRepository.GetAllSaleOrders().Result
                join detail in _saleOrderDetailsRepository.GetAllSaleOrderDetails().Result
                    on saleOrder.SaleOrderID equals detail.SaleOrderId.GetValueOrDefault()
                join product in _productRepository.GetAllProducts().Result
                    on detail.ProductId equals product.ProductId
                select new SaleDTO
                {
                    SaleOrderID = saleOrder.SaleOrderID,
                    SaleOrderDetailId = detail.SaleOrderDetailId,
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    ProductDescription = product.Description,
                    ProductBarcode = product.Barcode,
                    Count = detail.Count,
                    DataTime = saleOrder.DataTime,
                    PriceCost = detail.PriceCost,
                    PriseSale = detail.PriseSale,
                    Summ = detail.Summ,
                    ShopId = saleOrder.ShopId.GetValueOrDefault()
                    //  public string ShopName { get; set; }
                    //  public string ShopAddress { get; set; }
                }).AsQueryable();
            
            query = query.Skip(1);
            var result = await query.ToListAsync();
            
            return result;
        }

    }
}
