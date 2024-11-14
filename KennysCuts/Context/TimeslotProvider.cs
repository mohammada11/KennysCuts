using KennysCuts.Model;
using KennysCuts.Context;
using Microsoft.EntityFrameworkCore;

namespace KennysCuts.Context
{
    public class TimeslotProvider
    {
        private readonly DatabaseContext _context;

        public TimeslotProvider(DatabaseContext context)
        {
            _context = context;
        }

        

        public async Task AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }

}

