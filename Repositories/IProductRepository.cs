using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsApi.Models;
 
namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        Task<products> Get(int id);
        Task<IEnumerable<products>> GetAll();
        Task Add(products product);
        Task Delete(int id);
        Task Update(products product);
    }
}