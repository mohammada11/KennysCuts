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


        public async Task CreateBooking(User user, string selectedBarber, string selectedService, string Timeslot, DateOnly Date, string contactEmail)
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
                Date = Date,
                Email = contactEmail,
            };

            // Add the booking to the database and save changes
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            
            var existingBooking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == booking.Id);


            if (existingBooking != null)
            {

                existingBooking.Services = booking.Services;
                existingBooking.Barber = booking.Barber;
                existingBooking.Timeslot = booking.Timeslot;
                existingBooking.Email = booking.Email;

                _context.Bookings.Update(booking);
                await _context.SaveChangesAsync();
            }
        }

        
        public async Task<Services> GetServiceByNameOrIdAsync(string serviceNameOrId)
        {
            if (int.TryParse(serviceNameOrId, out var serviceId))  
            {
                return await _context.Services.FirstOrDefaultAsync(s => s.Id == serviceId);
            }
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Name== serviceNameOrId);
            return service;
        }

       
        public async Task<Barber> GetBarberByNameOrIdAsync(string barberNameOrId)
        {
            if (int.TryParse(barberNameOrId, out var barberId))  // Try to parse the string to an ID
            {
                return await _context.Barber.FirstOrDefaultAsync(b => b.Id == barberId);
            }
            return await _context.Barber.FirstOrDefaultAsync(b => b.Name==barberNameOrId);
        }


    }
}


