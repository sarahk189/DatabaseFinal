using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity> 
    where TEntity : class 

{
    private readonly CustomerCatalogueContext _context;

    public BaseRepository(CustomerCatalogueContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
                       
            return entity;
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Error adding entity");
            Debug.WriteLine(ex.Message); 
        }

        return null!;
    }
    public virtual async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                return entity;
            }

            throw new InvalidOperationException("Entity not found.");
        }
        catch (Exception ex)
        {
           Console.WriteLine("Error adding entity");
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        Console.Clear();
        try
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            if (entities != null)
            {
                return entities;
            }

            throw new InvalidOperationException("Entity not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding entity");
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<TEntity>();
        }
    }

    public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            
            if (entityToUpdate == null)
            {
                throw new InvalidOperationException("Entity to update not found.");
            }

            _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return entityToUpdate;   
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error updating entity");
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
    { 
        try
        {
            var entityToDelete = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entityToDelete != null)
            {
                _context.Set<TEntity>().Remove(entityToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            throw new InvalidOperationException("Entity not found.");
        }
        catch
        {
            Console.WriteLine("Error deleting entity");
            return false;
    
        }
    }

}
