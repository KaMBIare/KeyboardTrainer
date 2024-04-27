namespace Domain.Entities;

/// <summary>
/// класс хранящий информацию об сессиии
/// </summary>
public class Session : BaseEntity
{
    public Session()
    {
        
    }
    
    public Session(User user, List<bool> levelsCompleted, List<TimeOnly> passTime, List<double> passAccurasy)
    {
        User = user;
        LevelsCompleted = levelsCompleted;
        PassTime = passTime;
        PassAccurasy = passAccurasy;
    }   

    /// <summary>
    /// пользователь
    /// </summary>
    public User User { get; set; }
    /// <summary>
    /// список утверждений об выполненых уровнях, где индекс - номер уровня
    /// </summary>
    public List<bool> LevelsCompleted { get; set; }
    /// <summary>
    /// список рекордного времени прохожденяи уровня, где индекс - номер уровня
    /// </summary>
    public List<TimeOnly> PassTime { get; set; }
    /// <summary>
    /// список рекордной точности прохожденяи уровня, где индекс - номер уровня
    /// </summary>
    public List<double> PassAccurasy { get; set; }
}