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
    public class StorageDevices : ControllerBase
    {
        private readonly DeviceContext _context;

        public StorageDevices(DeviceContext context)
        {
            _context = context;
        }

        // GET: api/StorageDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageDevice>>> GetStorageDevices()
        {
            return await _context.StorageDevices.ToListAsync();
        }

        // GET: api/StorageDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageDevice>> GetStorageDevice(int id)
        {
            var storageDevice = await _context.StorageDevices.FindAsync(id);

            if (storageDevice == null)
            {
                return NotFound();
            }

            return storageDevice;
        }

        // PUT: api/StorageDevices/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageDevice(int id, StorageDevice storageDevice)
        {
            if (id != storageDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(storageDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageDeviceExists(id))
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

        // POST: api/StorageDevices
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StorageDevice>> PostStorageDevice(StorageDevice storageDevice)
        {
            _context.StorageDevices.Add(storageDevice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorageDevice", new { id = storageDevice.Id }, storageDevice);
        }

        // DELETE: api/StorageDevices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StorageDevice>> DeleteStorageDevice(int id)
        {
            var storageDevice = await _context.StorageDevices.FindAsync(id);
            if (storageDevice == null)
            {
                return NotFound();
            }

            _context.StorageDevices.Remove(storageDevice);
            await _context.SaveChangesAsync();

            return storageDevice;
        }

        private bool StorageDeviceExists(int id)
        {
            return _context.StorageDevices.Any(e => e.Id == id);
        }
    }
}
