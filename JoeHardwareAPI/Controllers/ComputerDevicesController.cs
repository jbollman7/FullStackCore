using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JoeHardwareAPI.Models;

namespace JoeHardwareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerDevicesController : ControllerBase
    {
        private readonly DeviceContext _context;

        public ComputerDevicesController(DeviceContext context)
        {
            _context = context;
        }

        // GET: api/ComputerDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerDevice>>> GetComputerDevices()
        {
            return await _context.ComputerDevices.ToListAsync();
        }

        // GET: api/ComputerDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerDevice>> GetComputerDevice(int id)
        {
            var computerDevice = await _context.ComputerDevices.FindAsync(id);

            if (computerDevice == null)
            {
                return NotFound();
            }

            return computerDevice;
        }

        // PUT: api/ComputerDevices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputerDevice(int id, ComputerDevice computerDevice)
        {
            if (id != computerDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(computerDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerDeviceExists(id))
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

        // POST: api/ComputerDevices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ComputerDevice>> PostComputerDevice(ComputerDevice computerDevice)
        {
            _context.ComputerDevices.Add(computerDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComputerDevice), new { id = computerDevice.Id }, computerDevice);
        }

        // DELETE: api/ComputerDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComputerDevice>> DeleteComputerDevice(int id)
        {
            var computerDevice = await _context.ComputerDevices.FindAsync(id);
            if (computerDevice == null)
            {
                return NotFound();
            }

            _context.ComputerDevices.Remove(computerDevice);
            await _context.SaveChangesAsync();

            return computerDevice;
        }

        private bool ComputerDeviceExists(int id)
        {
            return _context.ComputerDevices.Any(e => e.Id == id);
        }
    }
}
