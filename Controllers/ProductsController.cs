using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Dtos;
using ProductsApi.Models;
using ProductsApi.Repositories;
using Microsoft.AspNetCore.Cors;
 
namespace ProductsApi.Controllers
{
  [EnableCors("AllowAll")]  
  [ApiController]
  [Route("[controller]")]

  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _productRepository;
    public ProductsController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }
    
    [EnableCors("AllowAll")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<products>>> GetProducts()
    {
        var products = await _productRepository.GetAll();
        return Ok(products);
    }
    
    [EnableCors("AllowAll")]
    [HttpGet("{id}")]
    public async Task<ActionResult<products>> GetProduct(int id)
    {
        var product = await _productRepository.Get(id);
        if(product == null)
            return NotFound();
 
        return Ok(product);
    }
    
    [EnableCors("AllowAll")]
    [HttpPost]
    public async Task<ActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        products product = new()
        {
            name = createProductDto.name,
            price = createProductDto.price,
            quantity = createProductDto.quantity
        };
 
        await _productRepository.Add(product);
        return Ok();
    }
    [EnableCors("AllowAll")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        await _productRepository.Delete(id);
        return Ok();
    }
    

    [EnableCors("AllowAll")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProduct(int id, UpdateProductDto updateProductDto)
    {
        products product = new()
        {
            Id = id,
            name = updateProductDto.name,
            price = updateProductDto.price,
            quantity = updateProductDto.quantity           
        };
 
        await _productRepository.Update(product);
        return Ok();
    }
  }
}