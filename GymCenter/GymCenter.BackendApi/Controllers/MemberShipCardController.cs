using GymCenter.Data.EF;
using GymCenter.ViewModel.Catalogs.MemberShipCard;
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
    public class MemberShipCardController : ControllerBase
    {
        private readonly GymCenterDbContext _context;

        public MemberShipCardController(GymCenterDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //GET: api/memberShipCard
        public async Task<IActionResult> GetAll()
        {
            var listService = await _context.MembershipCards.ToListAsync();
            return Ok(listService);
        }

        //GET: api/memberShipCard/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var card = await _context.MembershipCards.FindAsync(id);
            return Ok(card);
        }

        //POST: api/memberShipCard
        [HttpPost]
        public async Task<IActionResult> Update(CardCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var card= new Data.Entity.MembershipCard()
            {
                UserId = request.UserId,
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                Status = Data.Enums.MemberShipCardStatus.Active,
            };
            _context.MembershipCards.Add(card);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok(card.Id);

            ModelState.AddModelError("", "Insert card failed.");
            return BadRequest(ModelState);
        }

        //DELETE: api/memberShipCard
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var card = _context.MembershipCards.Find(id);
            if (card == null)
            {
                ModelState.AddModelError("", "This card not exist.");
                return BadRequest(ModelState);
            }

            _context.MembershipCards.Remove(card);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", "Delete service failed.");
            return BadRequest(ModelState);
        }

        //PUT: api/memberShipCard/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CardUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var card = _context.MembershipCards.Find(id);
            if (card == null)
            {
                ModelState.AddModelError("", "This card not exist.");
                return BadRequest(ModelState);
            }

           //update informations

            _context.MembershipCards.Remove(card);

            int recordsAffected = await _context.SaveChangesAsync();
            if (recordsAffected > 0)
                return Ok();

            ModelState.AddModelError("", $"Delele card with id={id} failed.");
            return BadRequest(ModelState);
        }
    }
}