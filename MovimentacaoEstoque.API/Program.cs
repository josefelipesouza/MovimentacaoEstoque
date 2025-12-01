
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovimentacaoEstoque.Application.Interfaces.Repositories;
using MovimentacaoEstoque.Infrastructure;
using MovimentacaoEstoque.Application.Handlers.Movimentacoes.Cadastrar;
using MovimentacaoEstoque.Application.Handlers.Movimentacoes.Listar;
using Microsoft.EntityFrameworkCore;
using MovimentacaoEstoque.Infrastructure.Data;
using MovimentacaoEstoque.Infrastructure.Seed; 


var builder = WebApplication.CreateBuilder(args);

// DbContext SQLite
builder.Services.AddDbContext<EstoqueDbContext>(options =>options.UseSqlite("Data Source=Database/movimentacao.db"));

// Serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI (Injeção de dependência)
builder.Services.AddScoped<IMovimentacaoRepository, SqliteMovimentacaoRepository>();
builder.Services.AddScoped<CadastrarMovimentacaoHandler>();
builder.Services.AddScoped<ListarMovimentacaoHandler>();

// Build app
var app = builder.Build();
app.UseDeveloperExceptionPage();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<EstoqueDbContext>();
    context.Database.Migrate();
    EstoqueSeeder.Seed(context);
}


// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovimentacaoEstoque API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();