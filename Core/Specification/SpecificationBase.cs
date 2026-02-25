using System;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Infrastructure.Data;

public class SpecificationBase<T>(Expression<Func<T, bool>> criteria) : ISpecification<T>
{
    public SpecificationBase() : this(null!) { }
    public Expression<Func<T, bool>>? Criteria { get; } = criteria;

    public Expression<Func<T, object>>? orderBy {get; private set; } 

    public Expression<Func<T, object>>? orderByDescending {get; private set; }

    public bool isDistinct { get; private set; }

    public int Skip { get; private set; }

    public int Take { get; private set; }

    public bool IsPagingEnabled { get; private set; }


    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        orderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByExpression)
    {
        orderByDescending = orderByExpression;
    }
      public void ApplyDistinct()
    {
        isDistinct = true;
    }
    public void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
}
public class SpecificationBase<T, TResult>: SpecificationBase<T>, ISpecification<T, TResult>
{
    public SpecificationBase(Expression<Func<T, bool>> criteria) : base(criteria) { }
    
    public SpecificationBase() : base(null!) { }
    public Expression<Func<T, TResult>>? Select { get; private set; }

    public void AddSelection(Expression<Func<T, TResult>> selectExpression)
    {
        Select = selectExpression;
    }

 
}

