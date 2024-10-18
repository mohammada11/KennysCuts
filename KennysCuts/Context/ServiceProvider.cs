using Microsoft.EntityFrameworkCore;
using KennysCuts.Context;
using KennysCuts.Model;

namespace KennyCuts.Context
{
    public class ServiceProvider
    {
        private readonly DatabaseContext _context;

        public ServiceProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Services>> GetAllServicesAsync()
        {
            return await _context.Services.OrderBy(service => service.Id).ToListAsync();
        }

        public Services? GetServices(int id)
        {
            return _context.Services.Find(id);
        }

    }
}