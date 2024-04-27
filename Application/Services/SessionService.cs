using Application.Interfaces;
using Domain.Entities;
using Infrastructure;

namespace Application.Services;

public class SessionService : IRepository<Session>
{
    public SessionService(KeyboardTrainerDBContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// контекст базы данных
    /// </summary>
    private KeyboardTrainerDBContext _context = new KeyboardTrainerDBContext();



    /// <summary>
    /// устанавливает и сохраняет в базу данных новые значения в боля сессии если они являются рекордынми
    /// </summary>
    /// <param name="session"></param>
    /// <param name="passAccurasy"></param>
    /// <param name="passTime"></param>
    /// <param name="index"></param>
    public void SetRecordValues (Session session, double passAccurasy, TimeOnly passTime, int index)
    {
        if (passAccurasy > session.PassAccurasy[index])
        {
            session.PassAccurasy[index] = passAccurasy;
        }
        if (passTime < session.PassTime[index] || session.PassTime[index].ToString("mm:ss") == "00:00")
        {
            session.PassTime[index] = passTime;
        }

        if (ReadByUserName == null)
        {
            Create(session);
        }
        else
        {
            Update(session);
        }
        _context.SaveChanges();
    }
    /// <summary>
    /// возвращает сесию из базы жанных если пользователь с таки логином и паролем существует, иначе создает нового пользователя
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"></exception>
    public Session Authorization(string login, string password)
    {
        var sessoin = _context.Sessions.FirstOrDefault(e => e.User.Login == login && e.User.Password == password);
        if (sessoin == null)
        {
            List<bool> levelsCompleted = new List<bool>();
            List<TimeOnly> passTime = new List<TimeOnly>();
            List<double> passAcurasy = new List<double>();

            for (var i = 0; i < _context.Levels.Count(); i++)
            {
                levelsCompleted.Add(false);
                passTime.Add(new TimeOnly());
                passAcurasy.Add(0);
            }
            var s = new Session(new User(login, password), levelsCompleted, passTime, passAcurasy);
            Create(s);
            return s;
        }

        return sessoin;
    }
    
    //CRUD операции
    public void Create(Session entity)
    {
        _context.Sessions.Add(entity);
        _context.SaveChanges();
    }

    public List<Session> ReadAll()
    {
        var sessions = new List<Session>();
        foreach (var session in _context.Sessions)
        {
            sessions.Add(session);
        }

        return sessions;
    }

    public Session? ReadByUserName(string userName)
    {
        return _context.Sessions.FirstOrDefault(e => e.User.Login == userName);
    }
    public Session? ReadById(Guid id)
    {
        return _context.Sessions.Find(id);
    }


    public void Update(Session entity)
    {
        var updatingSession = _context.Sessions.FirstOrDefault(e => e.Equals(entity));
        if (updatingSession != null)
            updatingSession = entity;
        _context.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        var deletingSession = _context.Sessions.Find(id);
        if (deletingSession != null)
        {
            _context.Sessions.Remove(deletingSession);
        }
    }
}