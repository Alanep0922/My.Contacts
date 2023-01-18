using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Repository.Map
{
	public class ContactMap : IEntityTypeConfiguration<Contact>
	{
		public ContactMap()
		{
		}

        public void Configure(EntityTypeBuilder<Contact> builder)
        {
			builder.ToTable("contacts");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Email)
				.HasColumnName("email")
				.HasMaxLength(100);

            builder.Property(x => x.Phone)
                .HasColumnName("phone")
                .HasMaxLength(100);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100);
        }
    }
}


