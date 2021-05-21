using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using RPGVideoGameAPI.MDBControllers;
using RPGVideoGameAPI.MDBServices;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
//using RPGVideoGameAPI.Data;
using RPGVideoGameLibrary.Models;
using RPGVideoGameAPI.Services;
using RPGVideoGameLibrary.Interfaces;
using RPGVideoGameLibrary.MDBModels;

namespace RPGVideoGameAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddDbContext<RPGVideoGameAPIContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("RPGVideoGameAPIContext")));

            services.Configure<RPGDatabaseSettings>
                (Configuration.GetSection(nameof(RPGDatabaseSettings)));

            services.AddSingleton<IRPGDatabaseSettings>
                (sp => sp.GetRequiredService<IOptions<RPGDatabaseSettings>>().Value);

            services.AddScoped<MDBUserService>();

            services.AddScoped<OnlineRPGContext>();
            services.AddScoped<UserAccountService>();
            services.AddScoped<AdminService>();
            services.AddScoped<AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        new SHA256Managed().ComputeHash(
                            Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_Secret")))),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });


            services.AddCors();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RPGGameServer", 
                    Version = "v1"
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with prefix Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });

            app.UseRouting();

            app.UseSwagger();

            //Use when Passwords in DB have been Encrypted
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "RPGGameServer v1");
                s.RoutePrefix = "api/help";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
