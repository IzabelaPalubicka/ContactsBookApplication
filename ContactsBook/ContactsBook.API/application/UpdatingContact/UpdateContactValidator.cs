using ContactsBook.API.infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ContactsBook.API.application.UpdatingContact
{
    public class UpdateContactValidator : AbstractValidator<UpdateContact>
    {
        public UpdateContactValidator(DBContext context)
        {
            RuleFor(x => x.Id).MustAsync(async (id, cancelation) =>
            {
                var isExisting = await context.Contacts.Where(x => x.Id == id)
                    .AnyAsync();

                return isExisting;
            }).WithMessage("Not found Contact with id {PropertyValue}");

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
