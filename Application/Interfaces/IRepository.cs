namespace Application.Interfaces;

/// <summary>
/// интерфейс описывающий CRUD операции над класом TEntity
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IRepository <TEntity>
{
    /// <summary>
    /// добавление в базу данных объекта TEntity
    /// </summary>
    /// <param name="entity"></param>
    void Create(TEntity entity);
    
    /// <summary>
    /// извлекает все объекты из базы данных
    /// </summary>
    /// <returns></returns>
    List<TEntity> ReadAll();
    
    /// <summary>
    /// извлекает объект из базы данных по его id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity? ReadById(Guid id);
    
    /// <summary>
    /// обновляет объект в базе данных на объект entity
    /// </summary>
    /// <param name="entity"></param>
    void Update(TEntity entity);

    /// <summary>
    /// удаляет из базы данных объект по его id
    /// </summary>
    /// <param name="id"></param>
    void DeleteById(Guid id);
}