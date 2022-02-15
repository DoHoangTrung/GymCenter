using GymCenter.Data.EF;
using GymCenter.ViewModel.Catalogs.Category;
using GymCenter.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymCenter.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GymCenterDbContext _context;

        public CategoriesController(GymCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //GET: api/categories
        public async Task<IActionResult> GetAll()
        {
            var listCate = await _context.Categories.ToListAsync();
            return Ok(listCate);
        }

        //GET: api/categories/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return Ok(category);
        }

        //POST: api/categories
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newCategory = new Data.Entity.Category()
            {
                Name = request.Name
            };
            _context.Categories.Add(newCategory);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok(newCategory.Id);

            ModelState.AddModelError("", "Insert category failed.");
            return BadRequest(ModelState);
        }

        //DELETE: api/categories
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cate = _context.Categories.Find(id);
            if( cate == null) {
                ModelState.AddModelError("", "This category not exist.");
                return BadRequest(ModelState);
            }

            _context.Categories.Remove(cate);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", "Delete category failed.");
            return BadRequest(ModelState);
        }

        //PUT: api/categories/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cate = _context.Categories.Find(id);
            if (cate == null)
            {
                ModelState.AddModelError("", "This category not exist.");
                return BadRequest(ModelState);
            }

            cate.Name = request.Name;

            _context.Categories.Update(cate);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", $"Update category with id={id} failed.");
            return BadRequest(ModelState);
        }
    }
}
