using CqrsDemo.CQRS.Queries;
using CqrsDemo.CQRS.Results;
using CqrsDemo.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CqrsDemo.CQRS.Handlers
{
    // public class GetStudentByIdQueryHandler
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly StudentContext _studentContext;

        public GetStudentByIdQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        //{
        //    var student = _studentContext.Set<Student>().Find(query.Id);

        //    return new GetStudentByIdQueryResult()
        //    {
        //        Age = student.Age,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName
        //    };
        //}

        // with mediator design pattern
        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentContext.Set<Student>().FindAsync(request.Id);

            return new GetStudentByIdQueryResult()
            {
                Age = student.Age,
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }

    }
}
