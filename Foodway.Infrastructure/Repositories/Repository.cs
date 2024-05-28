using System.Linq.Expressions;
using Foodway.Domain.Entities;
using Foodway.Infrastructure.Contexts;
using Foodway.Shared.Pagination;
using Foodway.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Foodway.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseAuditableEntity
{
    protected readonly AppDbContext Context;

    public Repository(AppDbContext context)
    {
        Context = context;
    }

    public DbSet<T> DbSet => Context.Set<T>();


    public int Count(Expression<Func<T, bool>>? where = null)
    {
        where ??= x => true;
        return Context.Set<T>().Count(where);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? where = null)
    {
        where ??= x => true;
        return await Context.Set<T>().CountAsync(where);
    }

    public bool Any(Expression<Func<T, bool>> where)
    {
        return Context.Set<T>().Any(where);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> where)
    {
        return await Context.Set<T>().AnyAsync(where);
    }

    public T? FindByKey(params object[] keyValues)
    {
        return Context.Set<T>().Find(keyValues);
    }

    public async Task<T?> FindByKeyAsync(params object[] keyValues)
    {
        return await Context.Set<T>().FindAsync(keyValues);
    }

    public IQueryable<T> Find(IEnumerable<string>? includes = null)
    {
        IQueryable<T> currentSet = Context.Set<T>();

        if (includes != null)
            currentSet = includes.Where(include => !string.IsNullOrEmpty(include))
                .Aggregate(currentSet, (current, include) => current.Include(include));

        return currentSet;
    }

    public IQueryable<T> Find(params Expression<Func<T, object>>[]? includes)
    {
        IQueryable<T> currentSet = Context.Set<T>();

        if (includes != null && includes.Any())
            currentSet = includes.Aggregate(currentSet, (current, include) => current.Include(include));

        return currentSet;
    }

    public T? Find(Expression<Func<T, bool>> where, IEnumerable<string>? includes = null)
    {
        var currentSet = Find(includes);

        var entity = currentSet.FirstOrDefault(where);

        return entity;
    }

    public T? FindAsNoTracking(Expression<Func<T, bool>> where, IEnumerable<string>? includes = null)
    {
        var currentSet = Find(includes).AsNoTracking();

        var entity = currentSet.FirstOrDefault(where);

        return entity;
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> where, IEnumerable<string>? includes = null)
    {
        var currentSet = Find(includes);

        var entity = await currentSet.FirstOrDefaultAsync(where);

        return entity;
    }

    public async Task<T?> FindAsyncAsNoTracking(Expression<Func<T, bool>> where, IEnumerable<string>? includes = null)
    {
        var currentSet = Find(includes).AsNoTracking();

        var entity = await currentSet.FirstOrDefaultAsync(where);

        return entity;
    }

    public T? Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
    {
        var currentSet = Find(includes);

        var entity = currentSet.FirstOrDefault(where);

        return entity;
    }

    public T? FindAsNoTracking(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
    {
        var currentSet = Find(includes).AsNoTracking();

        var entity = currentSet.FirstOrDefault(where);

        return entity;
    }

    public async Task<T?> FindAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
    {
        var currentSet = Find(includes);

        var entity = await currentSet.FirstOrDefaultAsync(where);

        return entity;
    }

    public async Task<T?> FindAsyncAsNoTracking(Expression<Func<T, bool>> where,
        params Expression<Func<T, object>>[] includes)
    {
        var currentSet = Find(includes).AsNoTracking();

        var entity = await currentSet.FirstOrDefaultAsync(where);

        return entity;
    }

    public IQueryable<T> List(Expression<Func<T, bool>>? where = null, int? page = null, int? pageSize = null,
        string? sortType = null, IEnumerable<string>? includes = null)
    {
        return CurrentSet(where, page, pageSize, sortType, includes);
    }

    public IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>>? where = null, int? page = null,
        int? pageSize = null,
        string? sortType = null, IEnumerable<string>? includes = null)
    {
        return List(where, page, pageSize, sortType, includes).AsNoTracking();
    }

    public async Task<IQueryable<T>> ListAsync(Expression<Func<T, bool>>? where = null, int? page = null,
        int? pageSize = null, string? sortType = null, IEnumerable<string>? includes = null)
    {
        return await Task.FromResult(CurrentSet(where, page, pageSize, sortType, includes));
    }

    public async Task<IQueryable<T>> ListAsNoTrackingAsync(Expression<Func<T, bool>>? where = null, int? page = null,
        int? pageSize = null, string? sortType = null, IEnumerable<string>? includes = null)
    {
        return await Task.FromResult(List(where, page, pageSize, sortType, includes).AsNoTracking());
    }

    public IQueryable<T> List(Expression<Func<T, bool>>? where = null, int? page = null, int? pageSize = null,
        string? sortType = null, params Expression<Func<T, object>>[] includes)
    {
        return CurrentSet(where, page, pageSize, sortType, includes);
    }

    public IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>>? where = null, int? page = null,
        int? pageSize = null,
        string? sortType = null, params Expression<Func<T, object>>[] includes)
    {
        return List(where, page, pageSize, sortType, includes).AsNoTracking();
    }

    public IQueryable<T> List(Expression<Func<T, bool>> where, IPagination pagination,
        IEnumerable<string>? includes = null)
    {
        return CurrentSet(where, pagination.PageIndex, pagination.PageSize,
            pagination.SortType, includes);
    }

    public IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where, IPagination pagination,
        IEnumerable<string>? includes = null)
    {
        return List(where, pagination, includes).AsNoTracking();
    }

    public IQueryable<T> List(Expression<Func<T, bool>> where, IPagination pagination,
        params Expression<Func<T, object>>[] includes)
    {
        return CurrentSet(where, pagination.PageIndex, pagination.PageSize,
            pagination.SortType, includes);
    }

    public IQueryable<T> ListAsNoTracking(Expression<Func<T, bool>> where, IPagination pagination,
        params Expression<Func<T, object>>[] includes)
    {
        return List(where, pagination, includes).AsNoTracking();
    }

    public PagedList<T> PagedList(Expression<Func<T, bool>> where, IPagination pagination,
        params Expression<Func<T, object>>[] includes)
    {
        var total = Count(where);

        var items = List(where, pagination, includes);

        return new PagedList<T>(items, total, pagination.PageSize);
    }

    public PagedList<T> PagedListAsNoTracking(Expression<Func<T, bool>> where, IPagination pagination,
        params Expression<Func<T, object>>[] includes)
    {
        var total = Count(where);

        var items = ListAsNoTracking(where, pagination, includes);

        return new PagedList<T>(items, total, pagination.PageSize);
    }

    public T Add(T entity)
    {
        return Context.Set<T>().Add(entity).Entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        return await Task.Run(() => Add(entity));
    }

    public void Modify(T entity)
    {
        Context.Set<T>().Update(entity);
    }

    public void Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await Context.Set<T>().AddRangeAsync(entities);
    }

    public async Task SaveChanges()
    {
        await Context.SaveChangesAsync();
    }

    private IQueryable<T> CurrentSet(Expression<Func<T, bool>>? where = null, int? page = null,
        int? pageSize = null, string? sortType = null, IEnumerable<string>? includes = null)
    {
        IQueryable<T> currentSet = Context.Set<T>();

        where ??= x => true;

        if (includes != null)
            currentSet = includes.Where(include => !string.IsNullOrEmpty(include))
                .Aggregate(currentSet, (current, include) => current.Include(include));

        currentSet = currentSet.Where(where);

        if (page != null && pageSize != null)
            currentSet = currentSet
                .Skip((page.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);

        return currentSet;
    }

    private IQueryable<T> CurrentSet(Expression<Func<T, bool>>? where = null, int? page = null,
        int? pageSize = null, string? sortType = null, params Expression<Func<T, object>>[]? includes)
    {
        IQueryable<T> currentSet = Context.Set<T>();

        where ??= x => true;

        if (includes != null && includes.Any())
            currentSet = includes.Aggregate(currentSet, (current, include) => current.Include(include));

        currentSet = currentSet.Where(where);

        if (page != null && pageSize != null)
            currentSet = currentSet
                .Skip((page.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);

        return currentSet;
    }


    public async Task AddAndSaveAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
    }
}