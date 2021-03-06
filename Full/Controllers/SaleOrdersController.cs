﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Context;
using Back.MiddleTier.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedAll.Models;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrdersController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly ISaleOrderSevrice _saleOrderService;

        public SaleOrdersController(ApplicationContext context,
            ISaleOrderSevrice saleOrderService

            )
        {
            _context = context;
            _saleOrderService = saleOrderService;
        }

        // GET: api/SaleOrders
        [HttpGet("GetSaleOrders")]
        public async Task<IActionResult> GetSaleOrders()
        {
        
          try
            {
                var result = _saleOrderService.GetAllSaleOrder();
                return Json(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // GET: api/SaleOrders
        [HttpGet("ALLSales")]
        public async Task<IActionResult> ALLSales()
        {
            try
            {
                var result = _saleOrderService.GetAllSale();
                return Json(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
     
        [HttpGet("GetPaginationSale/{page}/{pageSize}")]
        public async Task<IActionResult> GetPaginationSale(
            int page,
            int pageSize)
        {
            try
            {
                var result = await _saleOrderService.GetPaginationSale( 
                    page,
                 pageSize);
                return Json(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        // GET: api/SaleOrders/5
        [HttpGet("GetSaleOrder/{id}")]
        public async Task<ActionResult<SaleOrder>> GetSaleOrder(int id)
        {
            var saleOrder = await _context.SaleOrders.FindAsync(id);

            if (saleOrder == null)
            {
                return NotFound();
            }

            return saleOrder;
        }

        // PUT: api/SaleOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleOrder(int id, SaleOrder saleOrder)
        {
            if (id != saleOrder.SaleOrderID)
            {
                return BadRequest();
            }

            _context.Entry(saleOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SaleOrders
        [HttpPost]
        public async Task<ActionResult<SaleOrder>> PostSaleOrder(SaleOrder saleOrder)
        {
            _context.SaleOrders.Add(saleOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleOrder", new { id = saleOrder.SaleOrderID }, saleOrder);
        }

        // DELETE: api/SaleOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SaleOrder>> DeleteSaleOrder(int id)
        {
            var saleOrder = await _context.SaleOrders.FindAsync(id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            _context.SaleOrders.Remove(saleOrder);
            await _context.SaveChangesAsync();

            return saleOrder;
        }

        private bool SaleOrderExists(int id)
        {
            return _context.SaleOrders.Any(e => e.SaleOrderID == id);
        }
    }
}
