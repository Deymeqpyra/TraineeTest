using Domain;
using Optional;

namespace Application.Common.Interfaces.Queries;

public interface IUserQueries
{
    Task<Option<User>> GetUserIdAsync(int id, CancellationToken cancellationToken);

    Task<IReadOnlyList<User>> GetAllUsersAsync(CancellationToken cancellationToken);
}