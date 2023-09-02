
using BookWorm_C_.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using BookWorm_C_.Controllers;
using NuGet.Protocol.Core.Types;
using BookWorm_C_.Services;

namespace BookWorm_C_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            
            
            builder.Services.AddControllers();
            builder.Services.AddTransient<IAttributeMasterRepository, SQLAttributeMasterRepository>();
            builder.Services.AddTransient<ICustomerRepository, SQLCustomerRepository>();
            builder.Services.AddTransient<ICartRepository,SQLCartRepository>();
            builder.Services.AddTransient<IProductAttributeRepository, SQLProductAttributeRepository>();
            builder.Services.AddTransient<IProductTypeRepository, SQLProductTypeRepository>();
            builder.Services.AddTransient<IBeneficiaryRepository, SQLBeneficiaryRepository>();
            builder.Services.AddTransient<IRoyaltyCalculation,SQLRoyaltyCalculationRepository>();
            builder.Services.AddTransient<IInvoiceDetailRepository, SQLInvoiceDetailRepository>();
            var b = builder.Configuration.GetConnectionString("ProjectDatabase");
            builder.Services.AddDbContext<BookWormContext>((op) => op.UseSqlServer(b));
            var config = builder.Configuration;

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                option =>
                {
                    option.RequireHttpsMetadata = false;
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = config["Jwt:Audience"],
                        ValidIssuer = config["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))

                    };

                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}