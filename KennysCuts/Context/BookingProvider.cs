using KennysCuts.Model;
using Microsoft.EntityFrameworkCore;

namespace KennysCuts.Context
{
    public class BookingProvider
    {
        private readonly DatabaseContext _context;

        // Constructor with dependency injection for database context
        public BookingProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>?> GetBookingsAsync(User? user)
        {
            if (user == null) return null;

            // Query database for bookings linked to the user
            return await _context.Bookings
                .Where(booking => booking.User.UserName == user.UserName)
                .Include(booking => booking.Barber)
                .Include(booking => booking.Services)
                .ToListAsync();
        }


        public async Task CreateBooking(User user, string selectedBarber, string selectedService, DateOnly Timeslot, string contactEmail)
        {
            // Fetch the selected barber and service from the database
            var barber = await _context.Barber.FirstOrDefaultAsync(b => b.Name == selectedBarber);
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Name == selectedService);

            if (barber == null || service == null)
            {
                throw new Exception("Invalid barber or service selected.");
            }

            // Create a new Booking object
            var booking = new Booking
            {
                User = user,
                Barber = barber,
                Services = service,
                Timeslot = Timeslot,
                Email = contactEmail,
            };

            // Add the booking to the database and save changes
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }
}


