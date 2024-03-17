using MediatR;

namespace CqrsDemo.CQRS.Commands
{
    // public class CreateStudentCommand
    public class CreateStudentCommand : IRequest
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
