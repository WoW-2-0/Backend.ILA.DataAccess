using System.Linq.Expressions;
using EfCore.AuditInterceptor.Application.Common.Identity.Services;
using EfCore.AuditInterceptor.Domain.Entities;
using EfCore.AuditInterceptor.Persistence.Repositories.Interfaces;

namespace EfCore.AuditInterceptor.Infrastructure.Common.Identity.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(user.Id, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException();

        foundUser.FirstName = user.FirstName;

        return await userRepository.UpdateAsync(foundUser, saveChanges, cancellationToken);
    }

    public ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(userId, saveChanges, cancellationToken);
    }
}