using GymCenter.Application.Common;
using GymCenter.Data.EF;
using GymCenter.ViewModel.Catalogs.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GymCenter.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly GymCenterDbContext _context;
        private readonly IStorageService _storageService;

        public ServicesController(GymCenterDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        [HttpGet]
        //GET: api/services
        public async Task<IActionResult> GetAll()
        {
            var listService = await _context.Services.ToListAsync();
            return Ok(listService);
        }

        //GET: api/services/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _context.Services.FindAsync(id);
            return Ok(service);
        }

        //POST: api/services
        [HttpPost]
        public async Task<IActionResult> Update(ServiceCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newService = new Data.Entity.Service()
            {
                Name = request.Name,
                Description = request.Description,
                MaxMemberCount = request.MaxMemberCount,
                MemberCount = 0,
                NumberDaysUse = request.NumberDaysUse,
                Price = request.Price,
                NumberCheckInUse = request.CheckInUse,
                CategoryId = request.CategoryId,
                TimeOfDayEnd = request.TimeOfDayEnd,
                TimeOfDayStart = request.TimeOfDayStart,
            };
            _context.Services.Add(newService);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok(newService.Id);

            ModelState.AddModelError("", "Insert service failed.");
            return BadRequest(ModelState);
        }

        //DELETE: api/services
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = _context.Services.Find(id);
            if (service == null)
            {
                ModelState.AddModelError("", "This service not exist.");
                return BadRequest(ModelState);
            }

            _context.Services.Remove(service);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", "Delete service failed.");
            return BadRequest(ModelState);
        }

        //PUT: api/services/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServiceUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = _context.Services.Find(id);
            if (service == null)
            {
                ModelState.AddModelError("", "This service not exist.");
                return BadRequest(ModelState);
            }

            service.Name = request.Name;
            service.Price = request.Price;
            service.NumberCheckInUse = request.NumberCheckInUse;
            service.NumberDaysUse = request.NumberDaysUse;
            service.TimeOfDayStart = request.TimeOfDayStart;
            service.TimeOfDayEnd = request.TimeOfDayEnd;
            service.Description = request.Description;
            service.CategoryId = request.CategoryId;

            _context.Services.Update(service);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", $"Update service with id={id} failed.");
            return BadRequest(ModelState);
        }

        //POST: api/services/image
        [HttpPost("image")]
        public async Task<IActionResult> CreateImage(int serviceId, [FromForm] ServiceImageCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = _context.Services.Find(serviceId);
            if (service == null)
            {
                ModelState.AddModelError("", "This service not exist.");
                return BadRequest(ModelState);
            }

            service.ImagePath = await SaveFile(request.ImageFile);
            return Ok();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            //var fileName = $"{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
