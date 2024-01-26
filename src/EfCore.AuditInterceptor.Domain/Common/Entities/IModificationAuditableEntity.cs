﻿namespace EfCore.AuditInterceptor.Domain.Common.Entities;

public interface IModificationAuditableEntity
{
    Guid? ModifiedByUserId { get; set; }
}