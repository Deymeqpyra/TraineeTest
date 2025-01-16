using Application.Common;
using Application.Common.Interfaces.Repositories;
using Application.Users.Exceptions;
using Domain;
using MediatR;

namespace Application.Users.Commands;

public class DeleteUserCommand : IRequest<Result<User, UserException>>
{
    public int UserId { get; init; }
}

public class DeleteUserCommandHandler(IUserRepository repository)
    : IRequestHandler<DeleteUserCommand, Result<User, UserException>>
{
    public async Task<Result<User, UserException>> Handle(DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        int userId = request.UserId;
        var entity = await repository.GetUserIdAsync(userId, cancellationToken);

        return await entity.Match(
            async u => await DeleteEntity(u, cancellationToken),
            () => Task.FromResult<Result<User, UserException>>(new UserNotFoundException(userId)));
    }

    private async Task<Result<User, UserException>> DeleteEntity(User user, CancellationToken cancellationToken)
    {
        try
        {
            return await repository.Delete(user, cancellationToken);
        }
        catch (Exception e)
        {
            return new UnknownException(e);
        }
    }
}