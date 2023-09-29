using BlazorCRUD.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace BlazorCRUD.Server.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDBContext _db;

        public ProductServices(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<ProductDTO> CreateAsync(ProductDTO productDTO)
        {
            Products product = new Products
            {
                Id = Guid.NewGuid().ToString(),
                ProductCode = productDTO.ProductCode,
                ProductName = productDTO.ProductName,
                Qty = productDTO.Qty,
                Price = productDTO.Price,
                Description = productDTO.Description,
                CategoryId = productDTO.CategoryId
            };

            _db.Add(product);
            await _db.SaveChangesAsync();
            return productDTO;
        }

        public async Task<ProductDTO> GetById(string Id)
        {

            var productsById = await _db.Products.Where(a => a.CategoryId == Id).FirstOrDefaultAsync();

            if (productsById is not null)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    ProductCode = productsById.ProductCode,
                    ProductName = productsById.ProductName,
                    Qty = productsById.Qty,
                    Price = productsById.Price,
                    Description = productsById.Description,
                    CategoryId = productsById.CategoryId
                };
                return productDTO;
            }
            else
            {
                return null;
            }

        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            List<ProductDTO> productDtoList = new List<ProductDTO>();
            var productList = await _db.Products.ToListAsync();
            if (productList != null && productList.Count() > 0)
            {
                foreach (var product in productList)
                {
                    ProductDTO productDTO = new ProductDTO
                    {
                        ProductCode = product.ProductCode,
                        ProductName = product.ProductName,
                        Qty = product.Qty,
                        Price = product.Price,
                        Description = product.Description,
                        CategoryId = product.CategoryId
                    };
                    productDtoList.Add(productDTO);
                }
                return productDtoList;
            }

            return productDtoList;

        }

        public async Task<ProductDTO> UpdateAsync(string id, ProductDTO productDTO)
        {
            Products product = new Products
            {
                ProductCode = productDTO.ProductCode,
                ProductName = productDTO.ProductName,
                Qty = productDTO.Qty,
                Price = productDTO.Price,
                Description = productDTO.Description,
                CategoryId = productDTO.CategoryId
            };
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return (productDTO);
        }
    }
}
