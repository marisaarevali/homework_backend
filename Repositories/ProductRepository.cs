using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;
 
namespace ProductsApi.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly IDataContext _context;
    public ProductRepository(IDataContext context)
    {
      _context = context;
 
    }
    public async Task Add(products product)
    {        
      _context.Products.Add(product);
      await _context.SaveChangesAsync();
    }
 
    public async Task Delete(int id)
    {
        var itemToRemove = await _context.Products.FindAsync(id);
        if (itemToRemove == null)
            throw new NullReferenceException();
         
        _context.Products.Remove(itemToRemove);
        await _context.SaveChangesAsync();
    }
 
    public async Task<products> Get(int id)
    {
        return await _context.Products.FindAsync(id);
    }
 
    public async Task<IEnumerable<products>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }
 
    public async Task Update(products product)
    {
        var itemToUpdate = await _context.Products.FindAsync(product.Id);
        if (itemToUpdate == null)
            throw new NullReferenceException();
        itemToUpdate.name = product.name;
        itemToUpdate.price = product.price;
        itemToUpdate.quantity = product.quantity;
        await _context.SaveChangesAsync();
 
    }
  }
}