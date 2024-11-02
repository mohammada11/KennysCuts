namespace KennysCuts.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Services Services { get; set; }
        public Barber Barber { get; set; }
        public DateTime Timeslot { get; set; }
        public Barber SelectedBarber { get; set; } // Reference to the selected Barber
        public Services SelectedService { get; set; } // Reference to the selected Service
    }
}
