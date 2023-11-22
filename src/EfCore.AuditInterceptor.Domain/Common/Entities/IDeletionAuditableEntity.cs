namespace EfCore.AuditInterceptor.Domain.Common.Entities;

public interface IDeletionAuditableEntity
{
    Guid? DeletedByUserId { get; set; }
}