using CqrsDemo.CQRS.Commands;
using CqrsDemo.Data;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CqrsDemo.CQRS.Handlers
{
    // public class UpdateStudentCommandHandler
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public void Handle(UpdateStudentCommand command) 
        //{
        //    var updated = _studentContext.Students.Find(command.Id);
        //    updated.Age = command.Age;
        //    updated.FirstName = command.FirstName;
        //    updated.LastName = command.LastName;
        //    _studentContext.SaveChanges();
        //}

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updated = _studentContext.Students.Find(request.Id);
            updated.Age = request.Age;
            updated.FirstName = request.FirstName;
            updated.LastName = request.LastName;
            await _studentContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
