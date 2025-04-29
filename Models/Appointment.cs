namespace schedule_mvc.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateTime { get; set; }
        //public DateTimeOffset DateTimeOffset { get; set; }

        public Guid ClientId { get; set; }
        //[ForeignKey("ClientId")]
        public Client? Client { get; set; }
        //[ForeignKey("DoctorId")]
        public Guid DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
