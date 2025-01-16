using Domain;
using Optional;

namespace Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    Task<Option<User>> GetUserIdAsync(int id, CancellationToken cancellationToken);
    Task AddRange(IEnumerable<User> user, CancellationToken cancellationToken);
    Task<User> Delete(User user, CancellationToken cancellationToken);
    Task<User> Update(User user, CancellationToken cancellationToken);
}