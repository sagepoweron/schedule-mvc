using System.ComponentModel.DataAnnotations;

namespace schedule_mvc.Models


{
    public abstract class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "Default";
        [Phone]
        public string? Phone { get; set; }
        //[RegularExpression()]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
