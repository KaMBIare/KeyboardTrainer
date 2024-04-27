using Application.Interfaces;
using Domain.Entities;
using Infrastructure;

namespace Application.Services;

public class LevelService : IRepository<Level>
{
    public LevelService(KeyboardTrainerDBContext context)
    {
        _context = context;
        //Create(new Level("Осмысленный текст", 3, "Путешествие это не только перемещение из одной точки в другую, это погружение в новые культуры, знакомство с удивительными людьми и открытие удивительных историй. Мы находим себя в моментах, которые запомнятся навсегда: в общении с местными жителями на узких улочках старого города, во время восхождения на вершину горы, откуда открывается завораживающий вид, или в мгновениях, когда мы погружаемся в глубины местных рынков, полных разнообразия и ароматов.".ToLower()));
        //Create(new Level("Короткие слова", 1, "неправильно блять".ToLower()));
        //Create(new Level("Длинные слова", 2, "Эквивалентность Противопоставление Дезоксирибонуклеиновый Сверхспециализированный Трансцендентальность Автокатастрофический Деиндустриализация Гиперреалистичность Трансдисциплинарность Полихроматический Интерконтинентальный Самоопределенность Антропоморфизация Электроэнцефалография Контрагегемонический Гигрометеорологический Терморегуляторный Гиперпространственный".ToLower()));
        //Create(new Level("А О Я", 0, "о я о я а о о а я а а я о а о а о я а о о а а я о о о я а о а я о я а о о а а о я о а о а о а а о о а я а о а я о о я а о а а о я а а о а о о а я а а о а а о о о а я а а я о о о а я о а о а о а я а а о я о а о а о а а о о а о а а я о а а о я о а о я а а о о о а я о а а о я я о а а а о а о я о о о а о я а о а о я а о о о а я о а я о а о а о а о о о а я а о а о о а я о о я а а о о о а о о о а а я о я а а я а о а о о я а о я о о а а о а о а а о о а о а я а о я а а о а о о о а я а а а о я о я о а о о а я о а о о а а а о я я о а о я о о о а а о а о я о а а о а о а о я а о о а о о о а я о о а о а я о я а а о а а о я а а о а о а о я о а а о я о а о я а я о о о а о а а я о о а о я а о а а я о а а о а а я о я о о о а я а а я а о я а а а о я о а я о а а о о о а о а а а а о о я а я о а а о о а о я о а о а а я о о о".ToLower()));
    }
    
    private KeyboardTrainerDBContext _context = new KeyboardTrainerDBContext();
    
    //CRUD операции
    public void Create(Level entity)
    {
        _context.Levels.Add(entity);
        _context.SaveChanges();
    }

    public List<Level> ReadAll()
    {
        var levels = new List<Level>();
        foreach (var level in _context.Levels)
        {
            levels.Add(level);
        }

        return levels;
    }

    public Level ReadByName(string name)
    {
        var level = _context.Levels.ToList().FirstOrDefault(e => e.Name == name);
        if (level == null)
            throw new NullReferenceException();
        return level;
    }
    public Level? ReadById(Guid id)
    {
        
        return _context.Levels.Find(id);
    }

    public void Update(Level entity)
    {
        var updatingLevel = _context.Levels.FirstOrDefault(e => e.Equals(entity));
        if (updatingLevel != null)
            updatingLevel = entity;
        _context.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        var deletingLevel = _context.Levels.Find(id);
        if (deletingLevel != null)
        {
            _context.Levels.Remove(deletingLevel);
        }
    }
}