using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CVBuilder.Repository;
using Microsoft.EntityFrameworkCore;
using CVBuilder.Repository.Repositories.Interfaces;
using CVBuilder.Repository.Repositories.Implementations;
using CVBuilder.Service.Interfaces;
using CVBuilder.Service.Implementations;
using CVBuilder.Service.DTOs;
using AutoMapper;

namespace CVBuilder.WebAPI
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

            services.AddDbContext<CVBuilderDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CVBuilderConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(15),
                            errorNumbersToAdd: null
                        ).MigrationsAssembly("CVBuilder.Repository");
                    });
            });

            services.AddScoped<IUnitOfWorkRepository,UnitOfWorkRepository>();
            services.AddTransient<ICurriculumService,CurriculumService>();
            services.AddTransient<IPersonalDetailService,PersonalDetailService>();
            services.AddTransient<IService<StudyDTO>,StudyService>();
            services.AddTransient<IService<WorkExperienceDTO>,WorkExperienceService>();
            services.AddTransient<IService<CertificateDTO>,CertificateService>();
            services.AddTransient<IService<LanguageDTO>,LanguageService>();
            services.AddTransient<IService<SkillDTO>,SkillService>();
            services.AddTransient<IService<InterestDTO>,InterestService>();
            services.AddTransient<IService<PersonalReferenceDTO>,PersonalReferenceService>();
            services.AddTransient<IService<CustomSectionDTO>,CustomSectionService>();
            services.AddTransient<ITemplateService,TemplateService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
