using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int? id)
    {
        //eager loading com o include
        var product = await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(x => x.Id == id);
        
        return product;
    }
    public async Task<Product> CreateAsync(Product product)
    {
        _context.Products.Add(product);
        
        await _context.SaveChangesAsync();
        
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        
        await _context.SaveChangesAsync();
        
        return product;
    }

    public async Task<Product> DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
        
        await _context.SaveChangesAsync();
        
        return product;
    }
}