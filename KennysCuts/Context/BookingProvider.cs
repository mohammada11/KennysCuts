using KennysCuts.Model;
using Microsoft.EntityFrameworkCore;

namespace KennysCuts.Context
{
    public class BookingProvider
    {
        private readonly DatabaseContext _databaseContext;

        public BookingProvider(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Method to save the booking to the database
        public async Task<bool> SaveBookingAsync(string email, DateOnly timeslot, string selectedBarber, string selectedService)
        {
            try
            {
                // Create a new booking object
                var newBooking = new Booking
                {
                    
                    Timeslot = timeslot,
                };

                // Find the Barber by the name
                var barber = await _databaseContext.Barber
                    .FirstOrDefaultAsync(b => b.Name == selectedBarber);

                if (barber == null)
                {
                    // Barber not found
                    return false;
                }

                // Find the Service by the name
                var service = await _databaseContext.Services
                    .FirstOrDefaultAsync(s => s.Name == selectedService);

                if (service == null)
                {
                    // Service not found
                    return false;
                }

                // Set the foreign key properties
                newBooking.Barber = barber;
                newBooking.Services = service;

                // Save the booking to the database
                _databaseContext.Bookings.Add(newBooking);
                await _databaseContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving booking: {ex.Message}");
                return false;
            }
        }
    }

}
