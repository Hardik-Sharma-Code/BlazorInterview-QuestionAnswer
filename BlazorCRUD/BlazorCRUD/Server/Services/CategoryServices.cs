using BlazorCRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDBContext _db;

        public CategoryServices(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateAsync(Category model)
        {
            _db.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Category> GetById(string Id)
        {
            var category = await _db.Category.FirstOrDefaultAsync(a => a.CategoryId == Id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
                List<Category> categoryList = await _db.Category.ToListAsync();
                return categoryList;
        }

        public async Task<Category> UpdateAsync(string id, Category category)
        {
            _db.Entry(category).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return(category);
        }
    }
}
