using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.Repositories.Interface;

namespace RealEstate.Repositories
{
    // Student ID: 00013836
    public class Vendor_Repository : IRepository<Vendor>
    {
        private readonly RealEstate_DbContext _dbContext;

        // Constructor
        public Vendor_Repository(RealEstate_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Mian functions
        // Create
        public async Task CreateAsync(Vendor entity)
        {

            await _dbContext.Vendors.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteAsync(int id)
        {
            var address = await _dbContext.Vendors.FindAsync(id);
            if (address != null)
            {
                _dbContext.Vendors.Remove(address);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Get All
        public async Task<IEnumerable<Vendor>> GetAllAsync()
        {
            return await _dbContext.Vendors.ToArrayAsync();
        }

        // Get By Id
        public async Task<Vendor> GetByIdAsync(int id)
        {
            return _dbContext.Vendors.FirstOrDefault();
        }

        // Update
        public async Task UpdateAsync(Vendor entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
