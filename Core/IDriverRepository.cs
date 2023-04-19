using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Formular_one_api.Models;

namespace Formular_one_api.Core
{
    public interface IDriverRepository
    {
        Task<Driver?> GetByDriverNb(int driverNb);
    }
}