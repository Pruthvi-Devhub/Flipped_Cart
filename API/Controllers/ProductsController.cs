using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using  Core.Entities;
using Infrastructure.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{

    [ApiController]
     [Route("api/[Controller]")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
         _repo = repo;   
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProdcutsAsync();
            return Ok(products);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            var products = await _repo.GetProductByIdAsync(id);
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}