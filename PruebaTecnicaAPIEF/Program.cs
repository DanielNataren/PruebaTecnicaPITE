using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPIEF.Contexto;
using PruebaTecnicaAPIEF.Services;

internal class Program
{
    
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<IContextoDB, ContextoDB>();

        builder.Services.AddTransient<ITrabajadorService, TrabajadorService>();

        builder.Services.AddDbContext<ContextoDB>(options => 
            options.UseSqlServer("Data Source=.;Initial Catalog=DBPRUEBATECNICA;Integrated Security=True;TrustServerCertificate=true"));
        builder.Services.AddSwaggerGen();


        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins("*")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
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

        app.UseCors();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}