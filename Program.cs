using Microsoft.EntityFrameworkCore; 
using Microsoft.OpenApi.Models; 
using AgendaApi.Data;
 
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AgendaDatabase")));

builder.Services.AddControllers(); // o programa não estava fazendo o dotnet run Certifique sempre de verificar essa builder de que este método está incluído.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaApi", Version = "v1" });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendaApi v1"));
}

app.UseHttpsRedirection();

app.MapControllers(); // verifique sempre se a mapControllers foi add o app

app.Run();
