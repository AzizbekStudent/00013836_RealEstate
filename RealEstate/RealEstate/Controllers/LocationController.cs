using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Repositories.Interface;
using System.Collections;

namespace RealEstate.Controllers
{
    // Student ID: 00013836
    [Route("api/[controller]/[action]")]
    public class LocationController : ControllerBase
    {
        // Constructor
        private readonly IRepository<Location> _repository;

        public LocationController(IRepository<Location> repository)
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
        [ProducesResponseType(typeof(Location), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var addressBy_Id = await _repository.GetByIdAsync(id);
            return addressBy_Id == null ? NotFound() : Ok(addressBy_Id);
        }

        // Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Location location)
        {
            await _repository.CreateAsync(location);
            return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
        }

        // Update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Location location)
        {
            await _repository.UpdateAsync(location);
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
