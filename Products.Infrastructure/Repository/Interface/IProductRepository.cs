using Products.Infrastructure.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Infrastructure.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<ProductObject>> GetListProduct();
        Task<ProductObject> GetProductById(int id);
        Task<int> DeleteProductById(int id);
        Task<int> InsertProduct(ProductObject productModel);
        Task<int> UpdateProduct(ProductObject productModel);
    }
}
