namespace EfCore.Queries.GlobalQueryFilter.Models;

public class SoftDeletedEntity : ISoftDeletedEntity
{
    public bool IsDeleted { get; set; }
    
    public DateTimeOffset? DeletedTime { get; set; }
}