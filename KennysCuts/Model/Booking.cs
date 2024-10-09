namespace KennysCuts.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Services Services { get; set; }
        public Barber Barber { get; set; }
        public string Timeslot { get; set; }


    }
}
