using CqrsDemo.CQRS.Queries;
using CqrsDemo.CQRS.Results;
using CqrsDemo.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsDemo.CQRS.Handlers
{
    // public class GetStudentsQueryHandler
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _studentContext;

        public GetStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        //{
        //    return _studentContext.Students.Select(x => new GetStudentsQueryResult
        //    { Age = x.Age, FirstName = x.FirstName, LastName = x.LastName }).AsNoTracking().AsEnumerable();

        //}

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentContext.Students.Select(x => new GetStudentsQueryResult
                                                    { Age = x.Age, FirstName = x.FirstName, LastName = x.LastName }).AsNoTracking().ToListAsync();

        }
    }
}
