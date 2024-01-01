using Announcements.Core;
using Announcements.Middlewares;
using Announcements.Repository;
using Announcements.Service.Mapping;
using Announcements.Service.Services;
using Announcements.Service.Services.AnnouncementDetails;
using Announcements.Service.Services.Announcements;
using Announcements.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AnnouncementDtoValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IAnnouncementDetailService, AnnouncementDetailService>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<AnnouncementsDbContext>(d =>
{
    d.UseSqlServer(builder.Configuration.GetConnectionString("Default"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AnnouncementsDbContext)).GetName().Name);

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<CustomExceptionHandler>();
app.MapControllers();

app.Run();
