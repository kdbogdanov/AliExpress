using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICategoryService
    {
        Task<int> AddAsync(Category entity);
        Task<int> UpdateAsync(Category entity);
        public Task<IReadOnlyList<Category>> GetChildsByIdAsync(int id);
        public Task<IEnumerable<TreeNode<Category>>> GetTreeAsync();
    }
}
