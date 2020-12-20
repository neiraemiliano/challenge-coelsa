using System;
using System.Collections.Generic;
using System.Text;
using Coelsa.Domain.Dtos;
using FluentValidation;

namespace Coelsa.Infra.Data.Validators
{
    class ContactsValidator : AbstractValidator<ContactsDto>
    {
        public ContactsValidator()
        {
            RuleFor(Contacts => Contacts.FirstName)
                .NotNull()
                .WithMessage("Nombre no puede ser nulo");

            RuleFor(Contacts => Contacts.LastName)
                .NotNull()
                .WithMessage("Apellido no puede ser nulo");

            RuleFor(Contacts => Contacts.Email)
                .NotNull()
                .WithMessage("Email no puede ser nulo");

            RuleFor(Contacts => Contacts.PhoneNumber)
                .NotNull()
                .WithMessage("Celular no puede ser nulo");

        }
    }
}
