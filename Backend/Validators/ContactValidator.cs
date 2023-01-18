using System;
using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
	public class ContactValidator : AbstractValidator<Contact>
    {
		public ContactValidator()
		{
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid e-mail");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("The username cannot be null or empty");

            RuleFor(x => x.Phone)
                .NotNull()
                .NotEmpty()
                .WithMessage("The phone cannot be null/empty");
        }
    }
}

