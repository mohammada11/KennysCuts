using Microsoft.EntityFrameworkCore;
using KennysCuts.Context;
using KennysCuts.Model;

namespace KennysCuts.Context
{
    public class ServicesProvider
    {
        private readonly DatabaseContext _context;

        public ServicesProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Services>> GetAllServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public Services? GetServices(int id)
        {
            return _context.Services.Find(id);
        }

    }
}