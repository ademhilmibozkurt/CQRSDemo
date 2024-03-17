using CqrsDemo.CQRS.Results;
using MediatR;

namespace CqrsDemo.CQRS.Queries
{
    // public class GetStudentsQuery
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {
    }
}
