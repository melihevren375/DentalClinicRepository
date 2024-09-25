namespace Entities.Concretes;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
