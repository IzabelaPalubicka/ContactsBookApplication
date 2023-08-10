using ContactsBook.API.domain.Entities;
using ContactsBook.API.infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactsBook.API.application.Repository
{
    /// <summary>
    /// Base repository class.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public class ContactRepository : IRepository<Contact>
    {
        private readonly DBContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        public ContactRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact?> GetById(int id) => await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Id!.Equals(id));

        /// <inheritdoc/>
        public async Task Persist(Contact contact)
        {
            if (!_dbContext.Contacts.Local.Contains(contact))
            {
                _dbContext.Contacts.Add(contact);
            }
            else
            {
                _dbContext.Contacts.Update(contact);
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
