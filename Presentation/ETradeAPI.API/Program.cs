using ETradeAPI.Application.Validators.Products;
using ETradeAPI.Infrastructure.Filters;
using ETradeAPI.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ETradeAPI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPersistenceServices();
            builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

            //builder.Services.AddControllers()
            //    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>());


            //builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

            builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
