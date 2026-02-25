using Core.Interfaces;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Data;

public class SpecificationEvaluator
{
    public static IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // x => x.Brand == "React"
        }

        if (spec.orderBy != null)
        {
            query = query.OrderBy(spec.orderBy);
        }

        if (spec.orderByDescending != null)
        {
            query = query.OrderByDescending(spec.orderByDescending);
        }

        if (spec.isDistinct)
        {
            query = query.Distinct();
        }
        if (spec.IsPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        return query;
    }
    public static IQueryable<TResult> GetQuery<T, TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // x => x.Brand == "React"
        }

        if (spec.orderBy != null)
        {
            query = query.OrderBy(spec.orderBy);
        }

        if (spec.orderByDescending != null)
        {
            query = query.OrderByDescending(spec.orderByDescending);
        }

        var selectQuery = query as IQueryable<TResult>;

        if (spec.Select != null)
        {
            selectQuery = query.Select(spec.Select);
        }

        if (spec.isDistinct)
        {
            selectQuery = selectQuery?.Distinct();
        }

        return selectQuery ?? query.Cast<TResult>();
    }
    


}
