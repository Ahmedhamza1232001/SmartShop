using System.Linq.Expressions;
using static SmartShop.Core.ISpecification;

namespace SmartShop.Core;

public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification()
    {
        Criteria = _ => true; //need to test this line 
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Includes { get; } =
        new List<Expression<Func<T, object>>>();

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }
}
