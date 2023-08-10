using ContactsBook.API.application.Repository;
using ContactsBook.API.domain.Entities;
using MediatR;

namespace ContactsBook.API.application.UpdatingContact
{
    public record UpdateContact(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Address,
        string City,
        string Zip
    ) : IRequest;

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContact>
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public async Task Handle(UpdateContact command, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetById(command.Id);

            contact!.FirstName = command.FirstName;
            contact.LastName = command.LastName;
            contact.Email = command.Email;
            contact.PhoneNumber = command.PhoneNumber;
            contact.Address = command.Address;
            contact.City = command.City;
            contact.Zip = command.Zip;

            await _repository.Persist(contact);
        }
    }
}
