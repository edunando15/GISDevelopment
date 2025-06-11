using Microsoft.EntityFrameworkCore; 
namespace GISDevelopment.Abstractions;
 
public abstract class IGenericService<T, D> where T: class where D : IGenericDTO<T, D>
{
    protected readonly DbContext _context;


    /// <summary>
    /// Method used to add a new entity to the database.
    /// </summary>
    /// <param name="dto"> The entity to add. </param>
    public void Add(D dto)
    {
        var entity = dto.ToEntity();
        _context.Set<T>().Add(entity);
        Save();
    }
    
    public IGenericService(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method used to update an existing entity in the database.
    /// </summary>
    /// <param name="dto"> The already modified entity. </param>
    public void Update(D dto)
    {
        var entity = dto.ToEntity();
        _context.Set<T>().Update(entity);
        Save();
    }

    /// <summary>
    /// Method used to delete an entity from the database.
    /// </summary>
    /// <param name="id"> The id of the entity to delete. </param>
    /// <returns> True if the entity has been removed, false otherwise. </returns>
    public bool Delete(long id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity == null) return false;
        _context.Set<T>().Remove(entity);
        Save();
        return true;
    }

    /// <summary>
    /// Method used to retrieve an entity from the database.
    /// </summary>
    /// <param name="id"> The id of the entity to retrieve. </param>
    /// <returns> The requested entity if it exists, false otherwise. </returns>
    public D Get(long id)
    {
        var entity = _context.Set<T>().Find(id);
        return entity == null ? default : D.FromEntity(entity);
    }

    /// <summary>
    /// Method used to retrieve all entities from the database.
    /// </summary>
    /// <returns> A List containing all the entities.  </returns>
    public List<D> GetAll()
    {
        return _context.Set<T>().ToList()
            .Select(entity => D.FromEntity(entity))
            .ToList();;
    }

    /// <summary>
    /// Method used to retrieve all entities from the database with pagination.
    /// </summary>
    /// <param name="from"> Indicates the starting point of the results. </param>
    /// <param name="num"> Indicates the number of elements in the result. </param>
    /// <param name="totalCount"> Denotes the total count of entities. </param>
    /// <returns> A List of entities satisfying the given criteria. </returns>
    public List<D> GetAll(int from, int num, out int totalCount)
    {
        totalCount = _context.Set<T>().Count();
        return GetAll().Skip(from).Take(num).ToList();
    }
    
    public List<D> Search(string name, string rawQuery = "", int take = 100000, int skip = 0)
    {
        IEnumerable<T> entities;
        if (!string.IsNullOrEmpty(rawQuery))
        {
            entities = _context.Set<T>().FromSqlRaw(rawQuery).ToList();
            entities = entities.Where(e =>
            {
                var nameProperty = typeof(T).GetProperty("Name");
                var n = nameProperty?.GetValue(e) as string;
                return !string.IsNullOrEmpty(n) &&
                       n != "Unnamed" &&
                       (string.IsNullOrEmpty(name) || n.Contains(name));
            });
        }
        else
        {
            var result = _context.Set<T>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                result = result.Where(e => EF.Property<string>(e, "Name").Contains(name));
            }
            else
            {
                result = result.Where(e => EF.Property<string>(e, "Name") != null && EF.Property<string>(e, "Name") != string.Empty);
            }

            return result
                .Skip(skip)
                .Take(take)
                .ToList()
                .Select(e => D.FromEntity(e))
                .ToList();
        }
        return entities
            .Skip(skip)
            .Take(take)
            .ToList()
            .Select(e => D.FromEntity(e))
            .ToList();
    }

    /// <summary>
    /// Method used to save changes to the database.
    /// </summary>
    public void Save()
    {
        _context.SaveChanges();
    }
}