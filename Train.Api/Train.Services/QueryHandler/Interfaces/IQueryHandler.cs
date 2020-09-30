using Train.Services.Queries.Interfaces;

namespace Train.Services.QueryProcessors.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
