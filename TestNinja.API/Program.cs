using TestNinja.API.Data;

using Microsoft.EntityFrameworkCore;
using TestNinja.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = "Server=localhost,1433;Database=tests;User Id=sa;Password=Password123!;Encrypt=False;";
}

builder.Services.AddDbContext<DemoContext>((c, builder) =>
            builder.UseSqlServer(connectionString)
        );

builder.Services.AddScoped<ServicePersonas>();

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DemoContext>();
    dbContext.Database.Migrate();
}


app.MapRazorPages();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
