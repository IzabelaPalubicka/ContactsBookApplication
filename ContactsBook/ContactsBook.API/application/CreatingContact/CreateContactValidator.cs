using FluentValidation;

namespace ContactsBook.API.application.CreatingContact
{
    public class CreateContactValidator : AbstractValidator<CreateContact>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.LastName).NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Email).NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.PhoneNumber).NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Address).NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.City).NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Zip).NotEmpty()
                .MaximumLength(10);
        }
    }
}
