using Application.Common;
using Application.Common.Interfaces.Repositories;
using Application.Users.Exceptions;
using Domain;
using MediatR;

namespace Application.Users.Commands;

public class UpdateUserCommand : IRequest<Result<User, UserException>>
{
    public int UserId { get; init; }
    public string Name { get; init; }
    public DateTime DateOfBirth { get; init; }
    public bool Married { get; init; }
    public string Phone { get; init; }
    public decimal Salary { get; init; }
}

public class UpdateUserCommandHandler(IUserRepository repository)
    : IRequestHandler<UpdateUserCommand, Result<User, UserException>>
{
    public async Task<Result<User, UserException>> Handle(UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        int userId = request.UserId;
        var entity = await repository.GetUserIdAsync(userId, cancellationToken);

        string name = request.Name;
        string phone = request.Phone;
        bool married = request.Married;
        DateTime dateOfBirth = request.DateOfBirth;
        decimal salary = request.Salary;

        return await entity.Match(
            async u => await Update(u, name, dateOfBirth, married, phone, salary, cancellationToken),
            () => Task.FromResult<Result<User, UserException>>(new UserNotFoundException(userId)));
    }

    private async Task<Result<User, UserException>> Update(User user, string updateName, DateTime updatedDate,
        bool updateMarried, string updatedPhone, decimal updatedSalary, CancellationToken cancellationToken)
    {
        try
        {
            user.UpdateDetails(updateName, updatedDate, updateMarried, updatedPhone, updatedSalary);

            return await repository.Update(user, cancellationToken);
        }
        catch (Exception e)
        {
            return new UnknownException(e);
        }
    }
}