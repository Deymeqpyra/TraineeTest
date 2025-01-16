using System.Data;
using FluentValidation;

namespace Application.Users.Commands;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(x=>x.Name).Length(0,100).NotEmpty();
        RuleFor(x=>x.Phone).Length(0,11).NotEmpty();
        RuleFor(x=>x.Salary).NotEmpty();
        RuleFor(x=>x.DateOfBirth).NotEmpty();
    }
}