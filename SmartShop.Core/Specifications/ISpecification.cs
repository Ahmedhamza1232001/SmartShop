using System.Linq.Expressions;

namespace SmartShop.Core;

public interface ISpecification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
