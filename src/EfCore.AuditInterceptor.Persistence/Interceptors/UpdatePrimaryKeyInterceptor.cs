using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfCore.AuditInterceptor.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCore.AuditInterceptor.Persistence.Interceptors;

public class UpdatePrimaryKeyInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var auditableEntities = eventData.Context!.ChangeTracker.Entries<IEntity>().ToList();

        auditableEntities.ForEach(
            entry =>
            {
                if (entry.State == EntityState.Added)
                    entry.Property(nameof(IEntity.Id)).CurrentValue = Guid.NewGuid();
            }
        );

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
