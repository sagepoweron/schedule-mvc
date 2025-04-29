using FluentValidation;
using schedule_mvc.Models;

namespace schedule_mvc.Data
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Name).NotEmpty().WithMessage("The name can't be blank");

        }
    }
}
