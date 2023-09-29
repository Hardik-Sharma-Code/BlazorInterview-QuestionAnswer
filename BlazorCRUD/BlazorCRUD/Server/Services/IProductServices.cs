using BlazorCRUD.Shared;

namespace BlazorCRUD.Server.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> CreateAsync(ProductDTO products);
        Task<ProductDTO> UpdateAsync(string id, ProductDTO products);
        Task<ProductDTO> GetById(string Id);
    }
}
