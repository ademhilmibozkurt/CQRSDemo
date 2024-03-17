using CqrsDemo.CQRS.Commands;
using CqrsDemo.Data;
using MediatR;

namespace CqrsDemo.CQRS.Handlers
{
    // public class CreateStudentCommandHandler
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly StudentContext _studentContext;

        public CreateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public void Handle(CreateStudentCommand command)
        //{
        //    _studentContext.Students.Add(new Student{ Age = command.Age, FirstName = command.FirstName, LastName = command.LastName});
        //    _studentContext.SaveChanges();
        //}

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            _studentContext.Students.Add(new Student { Age = request.Age, FirstName = request.FirstName, LastName = request.LastName });
            await _studentContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
