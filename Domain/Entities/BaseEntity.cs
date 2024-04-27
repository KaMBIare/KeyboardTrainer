namespace Domain.Entities;

/// <summary>
/// базовый класс дял всех сушностей
/// </summary>
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not BaseEntity entity)
            return false;
        
        return Id == entity.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}