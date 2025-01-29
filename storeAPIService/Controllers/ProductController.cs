using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using storeAPIService.Data;
using storeAPIService.DTOs.Product;
using storeAPIService.Mappers;
using storeAPIService.Interfaces;
using storeAPIService.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace storeAPIService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductRepository _productRepository;
        public ProductController(ApplicationDBContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository =productRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var products =  await _productRepository.GetAllAsync(query);
            var productsDTo = products.Select(s=> s.toProductDTO());
            return Ok(productsDTo);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var product =  await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product.toProductDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest ProductDTO ){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var ProductModel = ProductDTO.toProducctFromDTO();
            await _productRepository.CreateAsync(ProductModel);
            return CreatedAtAction(nameof(GetById),new{id= ProductModel.Id},ProductModel.toProductDTO());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateProductRequest ProductDTO){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var ProductModel =  await _productRepository.UpdateAsync(id,ProductDTO);
            if (ProductModel ==null)
                return NotFound();
            return Ok(ProductModel.toProductDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var ProductModel =  await _productRepository.DeleteAsync(id);
            if (ProductModel ==null)
                return NotFound();
            return NoContent();
        }
    }
}