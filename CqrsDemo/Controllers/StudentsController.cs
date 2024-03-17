using CqrsDemo.CQRS.Commands;
using CqrsDemo.CQRS.Handlers;
using CqrsDemo.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        //private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;

        //public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //    _getStudentsQueryHandler = getStudentsQueryHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _removeStudentCommandHandler = removeStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //}

        // mediator pattern
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetStudent(int id)
        //{
        //    var result = _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id)); 

        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());

        //    return Ok(result);
        //}


        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Created("", command.FirstName);
        }

        //[HttpPost]
        //public IActionResult Create(CreateStudentCommand command)
        //{
        //    _createStudentCommandHandler.Handle(command);
        //    return Created("", command.FirstName);
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id) 
        //{
        //    _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));

        //    return NoContent();
        //}


        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //[HttpPut]
        //public IActionResult Update(UpdateStudentCommand command)
        //{
        //    _updateStudentCommandHandler.Handle(command);

        //    return NoContent();
        //}
    }
}
