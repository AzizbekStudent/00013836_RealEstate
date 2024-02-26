using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Repositories.Interface;

namespace RealEstate.Repositories
{
    // Student ID: 00013836
    public class Location_Repository : IRepository<Location>
    {
        private readonly RealEstate_DbContext _dbContext;

        // Constructor
        public Location_Repository(RealEstate_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Mian functions
        // Create
        public async Task CreateAsync(Location entity)
        {
            await _dbContext.Locations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteAsync(int id)
        {
            var address = await _dbContext.Locations.FindAsync(id);
            if (address != null)
            {
                _dbContext.Locations.Remove(address);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Get All
        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _dbContext.Locations.ToArrayAsync();
        }

        // Get By Id
        public async Task<Location> GetByIdAsync(int id)
        {
            return _dbContext.Locations.FirstOrDefault();
        }

        // Update
        public async Task UpdateAsync(Location entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
