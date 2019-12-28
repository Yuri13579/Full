﻿using Back.MiddleTier;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.MiddleTier.Interface;
using Microsoft.EntityFrameworkCore;
using SharedAll.DTO;
using SharedAll.Models;

namespace Back.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: Controller
    {
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService
            )
        {
            _productService = productService;
        }

        //[HttpGet]
        //public async Task<Product> Get()
        //{
        //    int id = 1;
        //    var result = await _productService.GetAllProducts();
        //    return result;

        //}


        [HttpGet("GetSaleOrderById/{id}")]
        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var result = await _productService.GetProductById(id);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
           
        }
        
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts() 
        {
            try
            {
                var result = _productService.GetAllProducts();
                return Json(result); //result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDTO productDto)
        {
            var result = await _productService.AddProduct(productDto);

            return Json(result);
        } 

    }
}