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
    public class NetworkDevicesController : ControllerBase
    {
        private readonly DeviceContext _context;

        public NetworkDevicesController(DeviceContext context)
        {
            _context = context;
        }

        // GET: api/NetworkDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NetworkDevice>>> GetNetworkDevices()
        {
            return await _context.NetworkDevices.ToListAsync();
        }

        // GET: api/NetworkDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NetworkDevice>> GetNetworkDevice(int id)
        {
            var networkDevice = await _context.NetworkDevices.FindAsync(id);

            if (networkDevice == null)
            {
                return NotFound();
            }

            return networkDevice;
        }

        // PUT: api/NetworkDevices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNetworkDevice(int id, NetworkDevice networkDevice)
        {
            if (id != networkDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(networkDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NetworkDeviceExists(id))
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

        // POST: api/NetworkDevices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<NetworkDevice>> PostNetworkDevice(NetworkDevice networkDevice)
        {
            _context.NetworkDevices.Add(networkDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNetworkDevice", new { id = networkDevice.Id }, networkDevice);
        }

        // DELETE: api/NetworkDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NetworkDevice>> DeleteNetworkDevice(int id)
        {
            var networkDevice = await _context.NetworkDevices.FindAsync(id);
            if (networkDevice == null)
            {
                return NotFound();
            }

            _context.NetworkDevices.Remove(networkDevice);
            await _context.SaveChangesAsync();

            return networkDevice;
        }

        private bool NetworkDeviceExists(int id)
        {
            return _context.NetworkDevices.Any(e => e.Id == id);
        }
    }
}
