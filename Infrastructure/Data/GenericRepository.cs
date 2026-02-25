using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data;

public class GenericRepository<T>(ShopDbContext _context) : IGenericRepository<T> where T : BaseEntity
{
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {

        return await _context.Set<T>().ToListAsync();
    }


    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
    private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> spec)
    {
        return SpecificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }

    public async Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<T, TResult> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public bool Exists(int id)
    {
        return _context.Set<T>().Any(x => x.Id == id);
    }

    public Task<int> CountAsync(ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            return _context.Set<T>().Where(spec.Criteria).CountAsync();
        }
        return _context.Set<T>().CountAsync();
    }
}

    