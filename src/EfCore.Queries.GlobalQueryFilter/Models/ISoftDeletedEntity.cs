namespace EfCore.Queries.GlobalQueryFilter.Models;

public interface ISoftDeletedEntity
{
    bool IsDeleted { get; set; }

    DateTimeOffset? DeletedTime { get; set; }
}