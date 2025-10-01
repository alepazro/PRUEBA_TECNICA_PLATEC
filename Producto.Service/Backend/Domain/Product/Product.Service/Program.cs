using Microsoft.EntityFrameworkCore;
using Product.Service.Application.Extensions;
using Product.Service.Infrastructure.Extensions;
using Product.Service.Infrastructure.Http.Extensions;
using Product.Service.Infrastructure.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // Escuchar solo HTTP en el puerto 80
});


string connectionString = builder.Configuration.GetConnectionString("LibraryConnectionString");

builder.Services.AddApplication();
builder.Services.AddInfrastructure(opt => opt.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.Migrate();
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.RegisterEndpoints();
app.Run();
