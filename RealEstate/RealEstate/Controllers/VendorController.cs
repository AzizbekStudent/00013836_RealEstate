using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Repositories.Interface;
using System.Collections;

namespace RealEstate.Controllers
{
    // Student ID: 00013836
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        // Constructor
        private readonly IRepository<Vendor> _repository;

        public VendorController(IRepository<Vendor> repository)
        {
            _repository = repository;
        }

        // Actions
        // Get All
        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _repository.GetAllAsync();
        }

        // Get By Id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Vendor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var vendorBy_Id = await _repository.GetByIdAsync(id);
            return vendorBy_Id == null ? NotFound() : Ok(vendorBy_Id);
        }

        // Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Vendor vendor)
        {
            await _repository.CreateAsync(vendor);
            return CreatedAtAction(nameof(GetById), new { id = vendor.Id }, vendor);
        }

        // Update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Vendor vendor)
        {
            await _repository.UpdateAsync(vendor);
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
