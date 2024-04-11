
using LivrariaAT.Data;
using LivrariaAT.Repositorio.Interfaces;
using LivrariaAT.Repositorios;
using LivrariaAT.Repositorios.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;/////////
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;///////////
using Microsoft.OpenApi.Models;
using System.Text;

namespace LivrariaAT
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



            ////////////////////tokenswagger/////////////////////////builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                //c.OperationFilter<SwaggerDefaultValues>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
            /////////////////////////////////////////

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<LivrosDBContex>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                );
            builder.Services.AddScoped<IUsurarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
            builder.Services.AddScoped<ICapituloRepositorio, CapituloRepositorio>();


            ///////////////////////JWT/////////////////////////

            var key = Encoding.ASCII.GetBytes(LivrariaAT.Key.Secret);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            /////////////////////////////////////////////
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
