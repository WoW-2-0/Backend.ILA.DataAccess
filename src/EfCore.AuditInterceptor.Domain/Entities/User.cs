using EfCore.AuditInterceptor.Domain.Common.Entities;

namespace EfCore.AuditInterceptor.Domain.Entities;

public class User : AuditableEntity, IDeletionAuditableEntity, IModificationAuditableEntity
{
    public string FirstName { get; set; } = default!;

    public Guid? DeletedByUserId { get; set; }

    public Guid? ModifiedByUserId { get; set; }
}