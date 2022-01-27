using System;
using System.Collections.Generic;
using UserLogin.Domain.Exceptions;
using UserLogin.Domain.Validators;

namespace UserLogin.Domain.Entities
{
    public class User : Base
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string RegisteredAt { get; }
        public string FullName { get;}
        public User(string firstName, string lastName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            RegisteredAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            FullName = $"{firstName} {lastName}";
            _errors = new List<string>();
            Validate();
        }

        //For Entity framework
        protected User() { }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
            Validate();
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public override void Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }


                throw new DomainException("Invalid Field(s)",_errors);
            }

        }
    }
}
