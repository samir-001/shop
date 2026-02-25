using System;
using System.Linq.Expressions;

namespace Core.Interfaces;

public interface ISpecification<T>
{
  Expression<Func<T, bool>>? Criteria { get; }
  Expression<Func<T, object>>? orderBy { get; }
  Expression<Func<T, object>>? orderByDescending { get; }
  bool isDistinct { get; }
  int Skip { get; }
  int Take { get; }
  bool IsPagingEnabled { get; }






}
public interface ISpecification<T, TResult> : ISpecification<T>
{
  Expression<Func<T, TResult>>? Select { get; }

  void AddSelection(Expression<Func<T, TResult>> selectExpression);
}
