using ContactsBook.API.application.Repository;
using ContactsBook.API.domain.Entities;
using MediatR;

namespace ContactsBook.API.application.CreatingContact
{
    public record CreateContact(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Address,
        string City,
        string Zip
    ) : IRequest;

    public class CreateContactCommandHandler : IRequestHandler<CreateContact>
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public async Task Handle(CreateContact command, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Address = command.Address,
                City = command.City,
                Zip = command.Zip
            };

            await _repository.Persist(contact);
        }
    }
}
