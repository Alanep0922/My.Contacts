using System;
using Backend.Models;
using Backend.Repository;

namespace Backend.Services
{
	public class ContactService
	{
		private ContactRepository repository;
		public ContactService(ContactRepository repository)
		{
			this.repository = repository;
		}

		public void Create(Contact contact)
		{
			var phoneInUse = repository.GetDbSet()
				.Any(c => c.Phone == contact.Phone);

			if (phoneInUse)
			{
				throw new Exception("Phone in use");
			}

			repository.Create(contact);
		}

		public List<Contact> GetContacts()
		{
			return repository.GetDbSet().ToList();
		}

		public Contact GetById(int id)
		{
			return repository.GetById(id);
		}

		public void Update(Contact contact, int id)
		{
			repository.Update(contact, id);
		}

		public void DeleteById(int id)
		{
			repository.DeleteById(id);
		}
	}
}

