using GymCenter.Data.EF;
using GymCenter.ViewModel.Catalogs.Receipt;
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
    public class ReceiptsController : ControllerBase
    {
        private readonly GymCenterDbContext _context;

        public ReceiptsController(GymCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //GET: api/receipts
        public async Task<IActionResult> GetAll()
        {
            var listReceipt = await _context.Receipts.ToListAsync();
            return Ok(listReceipt);
        }

        //GET: api/receipts/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            return Ok(receipt);
        }

        //POST: api/receipts
        [HttpPost]
        public async Task<IActionResult> Create(ReceiptCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newReceipt = new Data.Entity.Receipt()
            {
                CashierName = request.CashierName,
                Date=request.Date,
                TotalCash = request.TotalCash,
                UserId = request.UserId,
            };

            _context.Receipts.Add(newReceipt);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok(newReceipt.Id);

            ModelState.AddModelError("", "Insert receipt failed.");
            return BadRequest(ModelState);
        }

        //DELETE: api/receipts
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receipt = _context.Receipts.Find(id);
            if (receipt == null)
            {
                ModelState.AddModelError("", "This receipt not exist.");
                return BadRequest(ModelState);
            }

            _context.Receipts.Remove(receipt);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", "Delete receipt failed.");
            return BadRequest(ModelState);
        }

        /*//PUT: api/receipts/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cate = _context.Receipts.Find(id);
            if (cate == null)
            {
                ModelState.AddModelError("", "This category not exist.");
                return BadRequest(ModelState);
            }

            cate.Name = request.Name;

            _context.Receipts.Update(cate);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", $"Update category with id={id} failed.");
            return BadRequest(ModelState);
        }*/
    }
}
