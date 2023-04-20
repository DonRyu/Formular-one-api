using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formular_one_api.Core;
using Formular_one_api.Core.Repositories;

namespace Formular_one_api.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;
        private readonly ILogger _logger;

        public IDriverRepository Drivers { get; private set; }

        public UnitOfWork(ApiDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;

            Drivers = new DriverRepository(_context, logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
