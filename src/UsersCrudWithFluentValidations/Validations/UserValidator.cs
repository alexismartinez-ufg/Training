using FluentValidation;
using UsersCrudWithFluentValidations.Models;

namespace UsersCrudWithFluentValidations.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("The {PropertyName} field should not be empty.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("The {PropertyName} field should not be empty.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("The {PropertyName} field should not be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("The {PropertyName} field should not be empty.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("The {PropertyName} field is not a valid email address.");
            RuleFor(x => x.LastModifiedDate).Must((user, _) =>
            {
                return user.LastModifiedDate == null || user.CreationDate < user.LastModifiedDate;
            }).WithMessage("The {PropertyName} field should not to be less than CreationDate.");
        }
    }
}
