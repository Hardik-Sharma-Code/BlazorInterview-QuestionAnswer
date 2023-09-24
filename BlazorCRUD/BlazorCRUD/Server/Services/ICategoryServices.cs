using BlazorCRUD.Shared;

namespace BlazorCRUD.Server.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(string id, Category category);
        Task<Category> GetById(string Id);
    }
}
