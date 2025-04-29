using schedule_mvc.Models;

namespace schedule_mvc.Views.Home
{
    public class IndexVM
    {
        public required IEnumerable<Appointment> Appointments { get; set; }
        //public int? TotalAppointments { get; set; }

        public string Text
        {
            get
            {
                int count = Appointments.Count();
                switch (count)
                {
                    case 1:
                        return "There is 1 upcoming appointment in the next month.";
                    case > 1:
                        return $"There are {count} upcoming appointments in the next month.";
                    default:
                        return "There are no upcoming appointments in the next month.";
                }
            }
        }
    }
}
