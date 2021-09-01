using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<IReadOnlyList<Category>> GetChildsByIdAsync(int id);
    }
}
