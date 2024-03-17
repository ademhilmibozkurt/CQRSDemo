using CqrsDemo.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentContext>(opt => 
{
    opt.UseSqlServer("server = (localdb)//mssqllocaldb; database = StudentDb; integrated security = true;");
});

// include mediator
builder.Services.AddMediatR(typeof(Program));

// cqrs without mediator pattern
//builder.Services.AddScoped<GetStudentByIdQueryHandler>();
//builder.Services.AddScoped<GetStudentsQueryHandler>();
//builder.Services.AddScoped<CreateStudentCommandHandler>();
//builder.Services.AddScoped<RemoveStudentCommandHandler>();
//builder.Services.AddScoped<UpdateStudentCommandHandler>();

builder.Services.AddControllers().AddNewtonsoftJson(opt => 
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var app = builder.Build();
app.MapControllers();

app.Run();
