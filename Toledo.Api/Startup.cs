using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Toledo.Aplication.Mappers;
using Toledo.Aplication.Model;
using Toledo.Aplication.Model.Dependent.Request;
using Toledo.Aplication.Model.Dependent.Response;
using Toledo.Aplication.UseCase;
using Toledo.Aplication.UseCase.Interface;
using Toledo.Domain.Repository;
using Toledo.Infra.Context;
using Toledo.Infra.Repository;

namespace Toledo.Api
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
            services.AddControllersWithViews();

            #region Repository
            services.AddTransient<IDependentRepository, DependentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            #endregion

            #region Employee UseCase
            services.AddTransient<IUseCase<InsertEmployeeRequest>, InsertEmployeeUseCase>();
            services.AddTransient<IUseCase<AlterEmployeeRequest>, AlterEmployeeUseCase>();
            services.AddTransient<IUseCase<GetEmployeeRequest, GetEmployeeResponse>, GetEmployeeUseCase>();
            services.AddTransient<IUseCase<ListEmployeeRequest, IEnumerable<ListEmployeeResponse>>, ListEmployeeUseCase>();
            services.AddTransient<IUseCase<RemoveEmployeeRequest>, RemoveEmployeeUseCase>();
            #endregion

            #region Dependet UseCase
            services.AddTransient<IUseCase<InsertDependetRequest>, InsertDependetUseCase>();
            services.AddTransient<IUseCase<AlterDependetRequest>, AlterDependetUseCase>();
            services.AddTransient<IUseCase<GetDependentRequest, GetDependentResponse>, GetDependentUseCase>();
            services.AddTransient<IUseCase<ListDependentRequest, IEnumerable<ListDependentResponse>>, ListDependentUseCase>();
            services.AddTransient<IUseCase<RemoveDependetRequest>, RemoveDependentUseCase>();
            #endregion

            #region Birthdays
            services.AddTransient<IUseCase<GetBirthdaysRequest, IEnumerable<GetBirthdaysResponse>>, GetBirthdaysUseCase>();
            #endregion

            #region Context
            services.AddDbContext<DependentContext>();
            services.AddDbContext<EmployeeContext>();
            #endregion

            #region AutoMapper
            var autoMapper = new MapperConfiguration(c => c.AddProfile<AutoMapProfiller>());
            services.AddSingleton(autoMapper.CreateMapper());
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(e => e.MapControllers());
        }
    }
}
