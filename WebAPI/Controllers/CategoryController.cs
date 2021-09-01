using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) =>
            _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> GetTree()
        {
            var data = await _categoryService.GetTreeAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChildsById(int id)
        {
            var data = await _categoryService.GetChildsByIdAsync(id);
            if (data == null)
                return Ok(data);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            var data = await _categoryService.AddAsync(category);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            var data = await _categoryService.UpdateAsync(category);
            return Ok(data);
        }
    }
}
