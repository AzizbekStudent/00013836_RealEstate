using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Repositories.Interface;

namespace RealEstate.Repositories
{
    // Student ID: 00013836
    public class Apartment_Repository : IRepository<Apartment>
    {
        private readonly RealEstate_DbContext _dbContext;

        // Constructor
        public Apartment_Repository(RealEstate_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Main functions
        // Create
        public async Task CreateAsync(Apartment entity)
        {
            await _dbContext.Apartments.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteAsync(int id)
        {
            var property = await _dbContext.Apartments.FindAsync(id);
            if (property != null)
            {
                _dbContext.Apartments.Remove(property);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Get All
        public async Task<IEnumerable<Apartment>> GetAllAsync()
        {
            return await _dbContext.Apartments
                .Include(a => a.Location_)
                .Include(a => a.Vendor_)
                .ToArrayAsync();
        }

        // Get By ID
        public async Task<Apartment> GetByIdAsync(int id)
        {
            return await _dbContext.Apartments
                .Include(a => a.Location_)
                .Include(a => a.Vendor_)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        // Update
        public async Task UpdateAsync(Apartment entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
