using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PhotoryData;
using PhotoryLogic.Classes;
using PhotoryModels;
using PhotoryRepository;
using PhotoryRepository.Classes;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

           

            services.AddTransient<UserLogic, UserLogic>();
            services.AddTransient<GroupAdminLogic, GroupAdminLogic>();
            services.AddTransient<AdminLogic, AdminLogic>();
            services.AddTransient<AuthLogic, AuthLogic>();

            services.AddTransient<IUserRepository, UserRepository>(); // Irepo -> iuserrepository 
            services.AddTransient<IGroupAdminRepository, GroupAdminRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<IUserOfGroupRepository, UserOfGroupRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddSwaggerGen();

            services.AddDbContext<PhotoryDbContext>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:3000/%22")
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //        });
            //});

            services.AddIdentity<IdentityUser, IdentityRole>(
                     option =>
                     {
                         option.Password.RequireDigit = false;
                         option.Password.RequiredLength = 6;
                         option.Password.RequireNonAlphanumeric = false;
                         option.Password.RequireUppercase = false;
                         option.Password.RequireLowercase = false;
                     }
                 ).AddEntityFrameworkStores<PhotoryDbContext>()
                 .AddDefaultTokenProviders();

            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "http://www.security.org",
                    ValidIssuer = "http://www.security.org",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Paris Berlin Cairo Sydney Tokyo Beijing Rome London Athens"))
                };
            });







        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            //app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseSwagger();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}