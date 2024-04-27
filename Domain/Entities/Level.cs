namespace Domain.Entities;

/// <summary>
/// класс хранящий информацию об уровне
/// </summary>
public class Level : BaseEntity
{
    public Level()
    {
        
    }
    
    public Level(string name, int index, string levelText)
    {
        Name = name;
        Index = index;
        LevelText = levelText;
    }

    /// <summary>
    /// наименование уровня
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// индекс уровня уровня
    /// </summary>
    public int Index{ get; set; }
    /// <summary>
    /// текст уровня
    /// </summary>
    public string LevelText { get; set; }
}