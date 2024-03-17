using MediatR;

namespace CqrsDemo.CQRS.Commands
{
    // public class UpdateStudentCommand
    public class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
