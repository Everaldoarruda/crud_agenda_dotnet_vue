using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AgendaApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.
builder.Services.AddDbContext<AgendaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AgendaDatabase")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AgendaApi", Version = "v1" });
});

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173", "https://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Swagger disponível sempre (remova a verificação de ambiente se desejar)
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AgendaApi v1"));

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Remova o UseHttpsRedirection se estiver usando HTTP (porta 5225)
// app.UseHttpsRedirection();

app.UseCors("AllowVueApp");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
