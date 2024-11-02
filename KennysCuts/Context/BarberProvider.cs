using KennysCuts.Model;
using KennysCuts.Context;
using Microsoft.EntityFrameworkCore;

namespace KennysCuts.Context
{
    public class BarberProvider
    {
        private readonly DatabaseContext _context;

        public BarberProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Barber>> GetAllBarberAsync()
        {
            return await _context.Barber.ToListAsync();
        }

        public Barber? GetBarber(int id)
        {
            return _context.Barber.Find(id);
        }

    }
}