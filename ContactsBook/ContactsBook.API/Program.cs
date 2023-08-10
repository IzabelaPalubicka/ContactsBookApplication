using ContactsBook.API.application.CreatingContact;
using ContactsBook.API.application.Repository;
using ContactsBook.API.application.UpdatingContact;
using ContactsBook.API.domain.Entities;
using ContactsBook.API.infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});


builder.Services.AddScoped<IRepository<Contact>, ContactRepository>();
builder.Services.AddScoped<IValidator<CreateContact>, CreateContactValidator>();
builder.Services.AddScoped<IValidator<UpdateContact>, UpdateContactValidator>();

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseHttpLogging();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
