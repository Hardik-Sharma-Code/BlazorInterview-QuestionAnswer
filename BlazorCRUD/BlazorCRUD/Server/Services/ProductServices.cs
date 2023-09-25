using BlazorCRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDBContext _db;

        public ProductServices(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<Products> CreateAsync(Products products)
        {
            _db.Add(products);
            await _db.SaveChangesAsync();
            return products;
        }

        public async Task<Products> GetById(string Id)
        {
            var productsById = await _db.Products.FirstOrDefaultAsync(a => a.CategoryId == Id);
            return productsById;
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            List<Products> productList = await _db.Products.ToListAsync();
            return productList;
        }

        public async Task<Products> UpdateAsync(string id, Products products)
        {
            _db.Entry(products).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return (products);
        }
    }
}
