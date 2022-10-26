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
    public class VehiclesController : ControllerBase
    {   
        //Refactored 
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public VehiclesController(ApplicationDbContext context)
        public VehiclesController(IUnitOfWork unitOfWork)
        {   
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Vehicles
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            //Refactored
            //return await _context.Vehicles.ToListAsync();
            var vehicles = await _unitOfWork.Vehicles.GetAll(includes: q => q.Include(x => x.Make).Include(x => x.Model).Include(x => x.Colour));
            return Ok(vehicles);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        public async Task<IActionResult> GetVehicle(int id)
        {
            //Refactored
            //var vehicle = await _context.Vehicles.FindAsync(id);
            var vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(vehicle);
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        { 
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(vehicle).State = EntityState.Modified;
            _unitOfWork.Vehicles.Update(vehicle);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!VehicleExists(id))
                if (!await VehicleExists(id))
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

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {
            //Refactored
            //_context.Vehicles.Add(vehicle);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Vehicles.Insert(vehicle);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetVehicle", new { id = vehicle.Id }, vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            //Refactored
            //var vehicle = await _context.Vehicles.FindAsync(id);
            var vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Vehicles.Remove(vehicle);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Vehicles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool VehicleExists(int id)
        private async Task<bool> VehicleExists(int id)
        {
            //Refactored
            //return _context.Vehicles.Any(e => e.Id == id);
            var vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            return vehicle != null;
        }
    }
}
