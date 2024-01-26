using System.Linq.Expressions;
using EfCore.AuditInterceptor.Domain.Entities;
using EfCore.AuditInterceptor.Persistence.DataContexts;
using EfCore.AuditInterceptor.Persistence.Repositories.Interfaces;

namespace EfCore.AuditInterceptor.Persistence.Repositories;

public class UserRepository(IdentityDbContext dbContext) : EntityRepositoryBase<User, IdentityDbContext>(dbContext), IUserRepository
{
    public new IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(userId, asNoTracking, cancellationToken);

    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(user, saveChanges, cancellationToken);

    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default) {
        var test = DbContext.Entry(user).Entity
        
        base.UpdateAsync(user, saveChanges, cancellationToken);
        
    }

    public new ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.DeleteByIdAsync(userId, saveChanges, cancellationToken);
}