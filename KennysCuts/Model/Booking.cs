namespace KennysCuts.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Services Services { get; set; }
        public Barber Barber { get; set; }
        public DateOnly Timeslot { get; set; }
        public string Email { get; set; }
    }
}
