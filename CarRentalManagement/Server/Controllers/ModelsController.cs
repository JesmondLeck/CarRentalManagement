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
    public class ModelsController : ControllerBase
    {   
        //Refactored 
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public ModelsController(ApplicationDbContext context)
        public ModelsController(IUnitOfWork unitOfWork)
        {   
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Models
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        {   
            //Refactored
            //return await _context.Models.ToListAsync();
            var models = await _unitOfWork.Models.GetAll();
            return Ok(models);
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Model>> GetModel(int id)
        public async Task<IActionResult> GetModel(int id)
        {
            //Refactored
            //var Model = await _context.Models.FindAsync(id);
            var model = await _unitOfWork.Models.Get(q => q.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(model);
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        { 
            if (id != model.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(model).State = EntityState.Modified;
            _unitOfWork.Models.Update(model);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!ModelExists(id))
                if (!await ModelExists(id))
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

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model model)
        {
            //Refactored
            //_context.Models.Add(model);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Insert(model);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetModel", new { id = model.Id }, model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            //Refactored
            //var model = await _context.Models.FindAsync(id);
            var model = await _unitOfWork.Models.Get(q => q.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Models.Remove(model);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Models.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool ModelExists(int id)
        private async Task<bool> ModelExists(int id)
        {
            //Refactored
            //return _context.Models.Any(e => e.Id == id);
            var model = await _unitOfWork.Models.Get(q => q.Id == id);
            return model != null;
        }
    }
}
