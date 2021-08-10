using Microsoft.EntityFrameworkCore;
using Products.Infrastructure.Context;
using Products.Infrastructure.Model;
using Products.Infrastructure.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context; 
        }
        public Task<List<ProductObject>> GetListProduct()
        {
            return context.Products.ToListAsync();
        }

        public Task<ProductObject> GetProductById(int id)
        {
            return context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<int> DeleteProductById(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);

            context.Remove(product);
            
            return context.SaveChangesAsync();
        }

        public Task<int> InsertProduct(ProductObject productModel)
        {
            context.Add(new ProductObject { Id = productModel.Id, Name = productModel.Name, Price = productModel.Price });
            return context.SaveChangesAsync();
        }

        public Task<int> UpdateProduct(ProductObject productModel)
        {
            var updatedProduct = context.Products.FirstOrDefault(x => x.Id == productModel.Id);

            updatedProduct.Name = productModel.Name;
            updatedProduct.Price = productModel.Price;

            return context.SaveChangesAsync();
        }
    }
}
