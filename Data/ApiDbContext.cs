using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formular_one_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Formular_one_api.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
    }
}