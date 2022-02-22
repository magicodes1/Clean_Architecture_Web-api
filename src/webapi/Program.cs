using System.Reflection;
using Delicious.core;
using Delicious.infrastructure;
using Delicious.webapi;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DeliciousFoodDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

builder.Services
    .AddMvc()
    .AddFluentValidation(fv => {
        fv.RegisterValidatorsFromAssemblyContaining<ProductValidator>();
        fv.DisableDataAnnotationsValidation=true;
    })
    .AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);    

builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped<IServiceWrapping, ServiceWrapping>();




builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<ValidationFilterAttribute>();

var app = builder.Build();


// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     SeedData.Initialize(services);
// }

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();
app.Run();
