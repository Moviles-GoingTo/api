using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GoingTo_API.Domain.Persistence.Context;
using GoingTo_API.Domain.Repositories;
using GoingTo_API.Persistence;
using GoingTo_API.Domain.Services;
using GoingTo_API.Services;
using GoingTo_API.Persistence.Repositories;
using Microsoft.OpenApi.Models;
using AutoMapper;
using System.IO;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;
using GoingTo_API.Domain.Repositories.Interactions;
using GoingTo_API.Domain.Services.Interactions;
using GoingTo_API.Domain.Repositories.Geographic;
using GoingTo_API.Domain.Services.Geographic;
using GoingTo_API.Domain.Repositories.Accounts;
using GoingTo_API.Domain.Services.Accounts;
using GoingTo_API.Domain.Repositories.Business;
using GoingTo_API.Domain.Services.Business;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Settings;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GoingTo_API
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
            services.AddMvc();

            services.AddCors();
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ILocatableRepository, LocatableRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, ProfileRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<ICountryRepository,CountryRepository>();
            services.AddScoped<ICountryLanguageRepository, CountryLanguageRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IFavouriteRepository, FavouriteRepository>();
            services.AddScoped<IUserAchievementRepository, UserAchievementRepository>();
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICountryCurrencyRepository, CountryCurrencyRepository>();
            services.AddScoped<ITipRepository, TipRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPlaceCategoryRepository, PlaceCategoryRepository>();
            services.AddScoped<IPlanRepository, PlanRepository>();
            services.AddScoped<IUserPlanRepository, UserPlanRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IBenefitRepository, BenefitRepository>();
            services.AddScoped<IPlanBenefitRepository, PlanBenefitRepository>();
            services.AddScoped<IPartnerProfileRepository, PartnerProfileRepository>();
            services.AddScoped<IPromoRepository, PromoRepository>();
            services.AddScoped<ILocatablePromoRepository, LocatablePromoRepository>();
            services.AddScoped<IEstateRepository, EstateRepository>();
            services.AddScoped<IEstateServiceRepository, EstateServiceRepository>();


            services.AddScoped<ILocatableService, LocatableService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserProfileService, ProfileService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IUserAchievementService, UserAchievementService>();
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddScoped<ICountryService,CountryService>();
            services.AddScoped<ICountryLanguageService, CountryLanguageService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddScoped<IFavouriteService, FavouriteService>();
            services.AddScoped<IUserAchievementService, UserAchievementService>();
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ICountryCurrencyService, CountryCurrencyService>();
            services.AddScoped<ITipService, TipService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPlaceCategoryService, PlaceCategoryService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IUserPlanService, UserPlanService>();
            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<IPlanBenefitService, PlanBenefitService>();
            services.AddScoped<IPartnerProfileService, PartnerProfileService>();
            services.AddScoped<IPromoService, PromoService>();
            services.AddScoped<ILocatablePromoService, LocatablePromoService>();
            services.AddScoped<IEstateService, EstateService>();
            services.AddScoped<IEstateServiceService, EstateServiceService>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(Startup));


            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoingTo API", Version = "v1" });
                c.ExampleFilters();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            //Secret reference
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            //Configure Authenticatoin System based on Bearer JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
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


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoingTo API V1");
                c.RoutePrefix = string.Empty;
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
