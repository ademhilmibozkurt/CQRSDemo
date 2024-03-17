using CqrsDemo.CQRS.Results;
using MediatR;

namespace CqrsDemo.CQRS.Queries
{
    // public class GetStudentByIdQuery
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
