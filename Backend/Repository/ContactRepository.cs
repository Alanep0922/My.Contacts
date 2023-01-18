using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
	public class ContactRepository
	{
		private DaoContext daoContext;

		public ContactRepository(DaoContext daoContext)
		{
			this.daoContext = daoContext;
		}

		public DbSet<Contact> GetDbSet() => daoContext.Set<Contact>();

		public void Create(Contact contact)
		{
			daoContext.Set<Contact>().Add(contact);
			daoContext.SaveChanges();
		}

		public Contact GetById(int id)
		{
			return GetDbSet().Single(c => c.Id == id);
		}

		public void Update(Contact contact, int id)
		{
			var databaseContact = GetById(id);
			databaseContact.Email = contact.Email;
			databaseContact.Name = contact.Name;
			databaseContact.Phone = contact.Phone;
			daoContext.Update(databaseContact);
			daoContext.SaveChanges();
		}

		public void DeleteById(int id)
		{
			var contact = GetById(id);
			daoContext.Remove(contact);
			daoContext.SaveChanges();
		}
	}
}
