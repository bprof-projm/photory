using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhotoryData;
using PhotoryLogic.Classes;
using PhotoryModels;
using PhotoryRepository;
using PhotoryRepository.Classes;
using PhotoryRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

            services.AddDbContext<PhotoryDbContext>();

            services.AddTransient<UserLogic, UserLogic>();
            services.AddTransient<GroupAdminLogic, GroupAdminLogic>();
            services.AddTransient<AdminLogic, AdminLogic>();

            services.AddTransient<IUserRepository, UserRepository>(); // Irepo -> iuserrepository 
            services.AddTransient<IGroupAdminRepository, GroupAdminRepository>();
            services.AddTransient<IAdminRepository, AdminRepository>();
            services.AddTransient<ICommentOfPhotoRepository, CommentOfPhotoRepository>();
            services.AddTransient<IPhotoOfGroupRepository, PhotoOfGroupRepository>();
            services.AddTransient<IUserOfGroupRepository, UserOfGroupRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddSwaggerGen();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();

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