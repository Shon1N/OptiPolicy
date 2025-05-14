using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OptiPolicy.Api.Authorization.Services;
using OptiPolicy.Api.Authorization.Services.Interfaces;
using OptiPolicy.Api.Data;
using OptiPolicy.Api.Data.Interfaces;
using OptiPolicy.Api.Features.Auth;
using OptiPolicy.Api.Features.Group;
using OptiPolicy.Api.Features.GroupPermission;
using OptiPolicy.Api.Features.Permission;
using OptiPolicy.Api.Features.User;
using OptiPolicy.Api.Features.UserGroup;
using OptiPolicy.Api.Mappings;
using OptiPolicy.Api.Services;
using OptiPolicy.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace OptiPolicy.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("OptiPolicy")));

            //services.AddHttpClient();
            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
            services.AddAutoMapper(typeof(GeneralProfile).Assembly);

            //Group
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IGroupQry, GroupQry>();

            //Group Permission
            services.AddScoped<IGroupPermissionService, GroupPermissionService>();
            services.AddScoped<IGroupPermissionQry, GroupPermissionQry>();

            //Permission
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPermissionQry, PermissionQry>();

            //User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserCmd, UserCmd>();
            services.AddScoped<IUserQry, UserQry>();

            //User Group
            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<IUserGroupCmd, UserGroupCmd>();
            services.AddScoped<IUserGroupQry, UserGroupQry>();

            //Seed
            services.AddScoped<ISeed, Seed>();

            //Auth
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthQry, AuthQry>();
            services.AddScoped<IJWTTokenService, JWTTokenService>();

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["AppSettings:Issuer"],
                        ValidAudience = Configuration["AppSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AppSettings:Token"])),
                        RoleClaimType = "role"
                    };
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v" + typeof(Startup).Assembly.GetName().Version.ToString().Substring(0, 1), new OpenApiInfo
                {
                    Title = "OptiPolicy API",
                    Version = "v" + typeof(Startup).Assembly.GetName().Version.ToString().Substring(0, 1),
                    Description = "Version: " + typeof(Startup).Assembly.GetName().Version.ToString()
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (apiDesc.HttpMethod == null) return false;
                    return true;
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
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

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeed seeder)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OptiPolicy.Api v1"));

            seeder.SeedDatabase();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAllOrigins");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
