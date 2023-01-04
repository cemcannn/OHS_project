using Business.Abstract;
using Business.Abstract.Definitions;
using Business.Abstract.OccupationalHealth;
using Business.Abstract.OccupationalSafety;
using Business.Abstract.Trainings;
using Business.Concrete;
using Business.Concrete.Definitions;
using Business.Concrete.OccupationalHealth;
using Business.Concrete.OccupationalSafety;
using Business.Concrete.Trainings;
using Business.Configuration.Auth;
using Business.Configuration.Cache;
using Business.Configuration.Mapper;
using DAL.Abstract;
using DAL.Concrete.EFCore;
using DAL.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace OHSProgramApi
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
            //Add DbContext and lifetime to container
            services.AddDbContext<OHSDbContext>(ServiceLifetime.Transient);

            //Redis for cache
            var redisConfigInfo = Configuration.GetSection("RedisEndpintInfo").Get<RedisEndpointInfo>();

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new StackExchange.Redis.ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { redisConfigInfo.Endpoint, redisConfigInfo.Port }
                    },
                    Password = redisConfigInfo.Password,
                    User = redisConfigInfo.Username
                };
            });

            //Implemented Cache Manager
            services.AddScoped<ICacheService, RedisCacheService>();

            //AutoMapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            //Repository Injections
            services.AddScoped<IAccidentRepository, EFAccidentRepository>();
            services.AddScoped<IActualWageAndPersonnelNumberRepository, EFActualWageAndPersonnelNumberRepository>();
            services.AddScoped<ICertificateRepository, EFCertificateRepository>();
            services.AddScoped<IHealthPersonnelRepository, EFHealthPersonnelRepository>();
            services.AddScoped<IHealthSurveillanceRepository, EFHealthSurveillanceRepository>();
            services.AddScoped<ILimbRepository, EFLimbRepository>();
            services.AddScoped<IOccupationalDiseaseRepository, EFOccupationalDiseaseRepository>();
            services.AddScoped<IOHSComitteeRepository, EFOHSComitteeRepository>();
            services.AddScoped<IPeriodicControlRepository, EFPeriodicControlRepository>();
            services.AddScoped<IPersonnelRepository, EFPersonnelRepository>();
            services.AddScoped<IProfessionRepository, EFProfessionRepository>();
            services.AddScoped<IReasonRepository, EFReasonRepository>();
            services.AddScoped<ISafetyEquipmentRepository, EFSafetyEquipmentRepository>();
            services.AddScoped<ISafetyExpertRepository, EFSafetyExpertRepository>();
            services.AddScoped<ISiteRepository, EFSiteRepository>();
            services.AddScoped<ITaskInstructionRepository, EFTaskInstructionRepository>();
            services.AddScoped<ITypeOfAccidentRepository, EFTypeOfAccidentRepository>();
            services.AddScoped<ITypeOfAnalysisRepository, EFTypeOfAnalysisRepository>();
            services.AddScoped<ITypeOfCertificateRepository, EFTypeOfCertificateRepository>();
            services.AddScoped<ITypeOfDiseaseRepository, EFTypeOfDiseaseRepository>();
            services.AddScoped<ITypeOfExaminationRepository, EFTypeOfExaminationRepository>();
            services.AddScoped<ITypeOfReportRepository, EFTypeOfReportRepository>();
            services.AddScoped<ITypeOfSafetyEquipmentRepository, EFTypeOfSafetyEquipmentRepository>();
            services.AddScoped<ITypeOfWorkEquipmentRepository, EFTypeOfWorkEquipmentRepository>();
            services.AddScoped<IUnitRepository, EFUnitRepository>();
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IWorkplaceTestAndAnalysisRepository, EFWorkplaceTestAndAnalysisRepository>();

            //Service Injections
            services.AddScoped<IAccidentService, AccidentService>();
            services.AddScoped<IActualWageAndPersonnelNumberService, ActualWageAndPersonnelNumberService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<IHealthPersonnelService, HealthPersonnelService>();
            services.AddScoped<IHealthSurveillanceService, HealthSurveillanceService>();
            services.AddScoped<ILimbService, LimbService>();
            services.AddScoped<IOccupationalDiseaseService, OccupationalDiseaseService>();
            services.AddScoped<IOHSComitteeService, OHSComitteeService>();
            services.AddScoped<IPeriodicControlService, PeriodicControlService>();
            services.AddScoped<IPersonnelService, PersonnelService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            services.AddScoped<IReasonService, ReasonService>();
            services.AddScoped<ISafetyEquipmentService, SafetyEquipmentService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<ITaskInstructionService, TaskInstructionService>();
            services.AddScoped<ITypeOfAccidentService, TypeOfAccidentService>();
            services.AddScoped<ITypeOfAnalysisService, TypeOfAnalysisService>();
            services.AddScoped<ITypeOfCertificateService, TypeOfCertificateService>();
            services.AddScoped<ITypeOfDiseaseService, TypeOfDiseaseService>();
            services.AddScoped<ITypeOfExaminationService, TypeOfExaminationService>();
            services.AddScoped<ITypeOfReportService, TypeOfReportService>();
            services.AddScoped<ITypeOfSafetyEquipmentService, TypeOfSafetyEquipmentService>();
            services.AddScoped<ITypeOfWorkEquipmentService, TypeOfWorkEquipmentService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkplaceTestAndAnalysisService, WorkplaceTestAndAnalysisService>();

            //Token
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOption>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)
                        )
                };
            });

            services.AddControllers();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OHSApi v1"));
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
