using ContactsBook.API.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsBook.API.infrastructure.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();

            builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsRequired();

            builder.Property(x => x.Address).HasMaxLength(100).IsRequired();

            builder.Property(x => x.City).HasMaxLength(50).IsRequired();

            builder.Property(x => x.Zip).HasMaxLength(10).IsRequired();
        }
    }
}
