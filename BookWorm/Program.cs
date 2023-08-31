
using BookWorm.Models;
using Microsoft.EntityFrameworkCore;
using ProductTypeMasterWorm.Models;

namespace ProductTypeMasterWorm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          //  var b = builder.Configuration.GetConnectionString("mysql");
        //  builder.Services.AddDbContextPool<AppDbContext>((op) => op.UseSqlServer(b));

             builder.Services.AddDbContextPool<AppDbContext>((options, context) =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                context.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
          
            builder.Services.AddTransient<IProductTypeMaster,ProductTypeMasterRepository>();
            builder.Services.AddTransient<IPublisherMaster,PublisherMasterRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
