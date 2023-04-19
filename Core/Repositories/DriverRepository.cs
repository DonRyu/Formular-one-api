using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formular_one_api.Data;
using Formular_one_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Formular_one_api.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Driver>> All()
        {
            try
            {
                return await _context.Drivers.Where(x => x.Id < 100).ToListAsync();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<Driver?> GetByDriverNb(int driverNb)
        {
            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNb);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}