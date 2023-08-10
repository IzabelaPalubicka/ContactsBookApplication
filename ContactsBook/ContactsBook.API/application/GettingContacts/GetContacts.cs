using ContactsBook.API.application.GettingContacts;
using ContactsBook.API.infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactsBook.API.application.GettingContact
{
    public record GetContacts() : IRequest<PagedList<ContactInfo>>, IPageableQuery
    {
        /// <summary>
        /// The amount of data to return.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Requested page.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Field to search by email.
        /// </summary>
        public string? Search { get; set; }
    }

    public class GetAllContactsQueryHandler : IRequestHandler<GetContacts, PagedList<ContactInfo>>
    {
        private readonly DBContext _dbContext;

        public GetAllContactsQueryHandler(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PagedList<ContactInfo>> Handle(GetContacts query, CancellationToken cancellationToken)
        {
            var contacts = _dbContext.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(query.Search))
            {
                contacts = contacts.Where(x => x.Email.Contains(query.Search));
            }

            var items = await contacts.Select(x => new ContactInfo
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                City = x.City,
                Zip = x.Zip
            }).Paginate(query).ToListAsync();

            int totalItemsCount = await contacts.CountAsync(cancellationToken: cancellationToken);

            var result = new PagedList<ContactInfo> { Items = items, TotalCount = totalItemsCount };

            return result;
        }
    }
}
