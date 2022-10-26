using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {   
        //Refactored 
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public ColoursController(ApplicationDbContext context)
        public ColoursController(IUnitOfWork unitOfWork)
        {   
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Colours
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
        public async Task<ActionResult<IEnumerable<Colour>>> GetColours()
        {   
            //Refactored
            //return await _context.Colours.ToListAsync();
            var colours = await _unitOfWork.Colours.GetAll();
            return Ok(colours);
        }

        // GET: api/Colours/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Colour>> GetColour(int id)
        public async Task<IActionResult> GetColour(int id)
        {
            //Refactored
            //var colour = await _context.Colours.FindAsync(id);
            var colour = await _unitOfWork.Colours.Get(q => q.Id == id);

            if (colour == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(colour);
        }

        // PUT: api/Colours/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColour(int id, Colour colour)
        { 
            if (id != colour.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(colour).State = EntityState.Modified;
            _unitOfWork.Colours.Update(colour);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!ColourExists(id))
                if (!await ColourExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Colours
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colour>> PostColour(Colour colour)
        {
            //Refactored
            //_context.Colours.Add(colour);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Insert(colour);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetColour", new { id = colour.Id }, colour);
        }

        // DELETE: api/Colours/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColour(int id)
        {
            //Refactored
            //var colour = await _context.Colours.FindAsync(id);
            var colour = await _unitOfWork.Colours.Get(q => q.Id == id);
            if (colour == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Colours.Remove(colour);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Colours.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool ColourExists(int id)
        private async Task<bool> ColourExists(int id)
        {
            //Refactored
            //return _context.Colours.Any(e => e.Id == id);
            var colour = await _unitOfWork.Colours.Get(q => q.Id == id);
            return colour != null;
        }
    }
}
