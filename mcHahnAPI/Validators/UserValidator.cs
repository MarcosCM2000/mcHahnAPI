using FluentValidation;
using mcHahn.Domain.Entities;

namespace mcHahnAPI.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() { 
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user =>user.Email).EmailAddress();
            RuleFor(user => user.Password).NotEmpty();
        }
    }
}
