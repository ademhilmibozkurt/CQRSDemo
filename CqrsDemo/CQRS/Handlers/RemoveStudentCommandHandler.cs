using CqrsDemo.CQRS.Commands;
using CqrsDemo.Data;
using MediatR;

namespace CqrsDemo.CQRS.Handlers
{
    // public class RemoveStudentCommandHandler
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _studentContext;
        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        //public void Handle(RemoveStudentCommand command)
        //{
        //    var deleted = _studentContext.Students.Find(command.Id);
        //    _studentContext.Students.Remove(deleted);
        //    _studentContext.SaveChanges();
        //}

        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deleted = _studentContext.Students.Find(request.Id);
            _studentContext.Students.Remove(deleted);
            await _studentContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
