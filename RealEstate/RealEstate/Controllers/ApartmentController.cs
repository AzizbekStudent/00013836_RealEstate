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
    public class ApartmentController : ControllerBase
    {
        // Constructor
        private readonly IRepository<Apartment> _repository;

        public ApartmentController(IRepository<Apartment> repository)
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
        [ProducesResponseType(typeof(Apartment), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var apartmentBy_Id = await _repository.GetByIdAsync(id);
            return apartmentBy_Id == null ? NotFound() : Ok(apartmentBy_Id);
        }

        // Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Apartment apartment)
        {
            await _repository.CreateAsync(apartment);
            return CreatedAtAction(nameof(GetById), new { id = apartment.Id }, apartment);
        }

        // Update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Apartment apartment)
        {
            await _repository.UpdateAsync(apartment);
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
