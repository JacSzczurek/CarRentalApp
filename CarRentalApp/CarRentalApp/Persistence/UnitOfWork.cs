using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentalDbContext _context;

        public UnitOfWork(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
