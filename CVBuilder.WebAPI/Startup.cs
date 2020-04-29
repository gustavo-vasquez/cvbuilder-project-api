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
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CVBuilder.Service.Helpers;
using CVBuilder.Core;
using CVBuilder.Core.Services;
using CVBuilder.Service.Services;
using CVBuilder.Core.DTOs;
using System.Text;

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

            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            var secret = System.Text.Encoding.ASCII.GetBytes(token.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret))
                };
            });

            //services.AddScoped<IAuthenticate, TokenAuthentication>();
            //services.AddScoped<IUserManagement, UserManagement>();

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<ICurriculumService,CurriculumService>();
            services.AddTransient<IPersonalDetailService,PersonalDetailService>();
            services.AddTransient<ISectionService<StudyDTO>,StudyService>();
            services.AddTransient<ISectionService<WorkExperienceDTO>,WorkExperienceService>();
            services.AddTransient<ISectionService<CertificateDTO>,CertificateService>();
            services.AddTransient<ISectionService<LanguageDTO>,LanguageService>();
            services.AddTransient<ISectionService<SkillDTO>,SkillService>();
            services.AddTransient<ISectionService<InterestDTO>,InterestService>();
            services.AddTransient<ISectionService<PersonalReferenceDTO>,PersonalReferenceService>();
            services.AddTransient<ISectionService<CustomSectionDTO>,CustomSectionService>();
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
