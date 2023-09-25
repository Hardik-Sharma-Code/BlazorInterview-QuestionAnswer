using BlazorCRUD.Shared;

namespace BlazorCRUD.Server.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> CreateAsync(Products products);
        Task<Products> UpdateAsync(string id, Products products);
        Task<Products> GetById(string Id);
    }
}
