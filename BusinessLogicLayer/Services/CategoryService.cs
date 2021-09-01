using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) =>
            _categoryRepository = categoryRepository;


        public async Task<int> AddAsync(Category entity) =>
              await _categoryRepository.AddAsync(entity);

        public async Task<IReadOnlyList<Category>> GetChildsByIdAsync(int id) =>
            await _categoryRepository.GetChildsByIdAsync(id);

        public async Task<IEnumerable<TreeNode<Category>>> GetTreeAsync()
        {
            var data = await _categoryRepository.GetAllAsync();
            var tree = data.GenerateTree(x => x.Id, x => x.ParentId); // Get the tree from list of categories

            return tree;
        }

        public async Task<int> UpdateAsync(Category entity) =>
            await _categoryRepository.UpdateAsync(entity);

    }
}
