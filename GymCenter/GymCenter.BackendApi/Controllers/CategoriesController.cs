using GymCenter.Data.EF;
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
    }
}
