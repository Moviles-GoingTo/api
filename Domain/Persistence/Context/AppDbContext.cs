using GoingTo_API.Domain.Models;
using GoingTo_API.Domain.Models.Accounts;
using GoingTo_API.Domain.Models.Business;
using GoingTo_API.Domain.Models.Geographic;
using GoingTo_API.Domain.Models.Interactions;
using GoingTo_API.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace GoingTo_API.Domain.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Benefit> Benefits { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
        public DbSet<CountryLanguage> CountryLanguages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstateService> EstateServices { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Locatable> Locatables { get; set; }
        public DbSet<LocatableType> LocatableTypes { get; set; }
        public DbSet<LocatablePromo> LocatablePromos { get; set; } 
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerProfile> PartnerProfiles { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceCategory> PlaceCategories { get; set; } 
        public DbSet<Plan> Plans { get; set; } 
        public DbSet<PlanBenefit> PlanBenefits { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
        public DbSet<PlanUser> PlanUsers { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Achievement Entity

            builder.Entity<Achievement>().ToTable("Achievements");
            builder.Entity<Achievement>().HasKey(p => p.Id);
            builder.Entity<Achievement>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Achievement>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Achievement>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Achievement>().Property(p => p.Points).HasDefaultValue<int>(null);


            //Benefit Entity

            builder.Entity<Benefit>().ToTable("Benefits");
            builder.Entity<Benefit>().HasKey(p => p.Id);
            builder.Entity<Benefit>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Benefit>().Property(p => p.Name).IsRequired();
            builder.Entity<Benefit>().Property(p => p.Description).IsRequired();

            //Category Entity
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired();

            //City Entity

            builder.Entity<City>().ToTable("Cities");
            builder.Entity<City>().HasKey(p => p.Id);
            builder.Entity<City>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<City>().Property(p => p.CountryId).IsRequired();
            builder.Entity<City>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<City>()
                .HasMany(p => p.Places)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId);

            //Country Entity

            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Country>().Property(p => p.FullName).IsRequired().HasMaxLength(100);
            builder.Entity<Country>().Property(p => p.LocatableId).IsRequired();
            builder.Entity<Country>()
                .HasMany(p => p.Cities)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);
            builder.Entity<Country>()
                .HasMany(p => p.Profiles)
                .WithOne(p => p.Country)
                .HasForeignKey(p => p.CountryId);

            //CountryCurrencies Entity

            builder.Entity<CountryCurrency>().ToTable("CountryCurrencies");
            builder.Entity<CountryCurrency>().HasKey(p => new { p.CountryId, p.CurrencyId });
            builder.Entity<CountryCurrency>()
                .HasOne(p => p.Currency)
                .WithMany(p => p.CountryCurrencies)
                .HasForeignKey(p => p.CurrencyId);
            builder.Entity<CountryCurrency>()
               .HasOne(p => p.Country)
               .WithMany(p => p.CountryCurrencies)
               .HasForeignKey(p => p.CountryId);

            //CountryLanguages Entity

            builder.Entity<CountryLanguage>().ToTable("CountryLanguages");
            builder.Entity<CountryLanguage>().HasKey(p => new { p.LanguageId, p.CountryId });
            builder.Entity<CountryLanguage>().Property(p => p.LanguageId).IsRequired();
            builder.Entity<CountryLanguage>().Property(p => p.CountryId).IsRequired();
            builder.Entity<CountryLanguage>()
                .HasOne(p => p.Language)
                .WithMany(p => p.CountryLanguages)
                .HasForeignKey(p => p.LanguageId);
            builder.Entity<CountryLanguage>()
               .HasOne(p => p.Country)
               .WithMany(p => p.CountryLanguages)
               .HasForeignKey(p => p.CountryId);

            //Currency Entity

            builder.Entity<Currency>().ToTable("Currencies");
            builder.Entity<Currency>().HasKey(p => p.Id);
            builder.Entity<Currency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(p => p.ShortName).IsRequired().HasMaxLength(3);
            builder.Entity<Currency>().Property(p => p.Unit).IsRequired().HasMaxLength(45);


            //Estate Entity

            builder.Entity<Estate>().ToTable("Estates");
            builder.Entity<Estate>().HasKey(p => p.Id);
            builder.Entity<Estate>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Estate>().Property(p => p.Name).IsRequired();
            builder.Entity<Estate>().Property(p => p.Description).IsRequired();

            builder.Entity<Estate>()
                .HasMany(p => p.EstateServices)
                .WithOne(p => p.Estate)
                .HasForeignKey(p => p.EstateId);

            //EstateService Entity

            builder.Entity<EstateService>().ToTable("EstateServices");
            builder.Entity<EstateService>().HasKey(p => new { p.EstateId, p.ServiceId });
            builder.Entity<EstateService>().Property(p => p.Text);

            //Favourite Entity

            builder.Entity<Favourite>().ToTable("Favourites");
            builder.Entity<Favourite>().HasKey(pt => new { pt.UserId, pt.LocatableId });
            builder.Entity<Favourite>().Property(p => p.Description).HasMaxLength(45);
            builder.Entity<Favourite>().Property(p => p.UserId).IsRequired();
            builder.Entity<Favourite>().Property(p => p.LocatableId).IsRequired();

            builder.Entity<Favourite>()
                .HasOne(p => p.User)
                .WithMany(p => p.Favourites)
                .HasForeignKey(p => p.UserId);
            builder.Entity<Favourite>()
                .HasOne(p => p.Locatable)
                .WithMany(p => p.Favourites)
                .HasForeignKey(p => p.LocatableId);



            //Entity Language

            builder.Entity<Language>().ToTable("Languages");
            builder.Entity<Language>().HasKey(p => p.Id);
            builder.Entity<Language>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Language>().Property(p => p.ShortName).IsRequired().HasMaxLength(45);
            builder.Entity<Language>().Property(p => p.FullName).IsRequired().HasMaxLength(45);

            //Locatable Entity

            builder.Entity<Locatable>().ToTable("Locatables");
            builder.Entity<Locatable>().HasKey(p => p.Id);
            builder.Entity<Locatable>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Locatable>().Property(p => p.Address).IsRequired().HasMaxLength(45);
            builder.Entity<Locatable>().Property(p => p.Description).HasMaxLength(100);
            builder.Entity<Locatable>().Property(p => p.Latitude);
            builder.Entity<Locatable>().Property(p => p.Longitude);

            builder.Entity<Locatable>()
                .HasOne(p => p.City)
                .WithOne(p => p.Locatable)
                .HasForeignKey<City>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasOne(p => p.Country)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Country>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasOne(p => p.Place)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Place>(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasMany(p => p.Tips)
                .WithOne(p => p.Locatable)
                .HasForeignKey(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.Locatable)
                .HasForeignKey(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasMany(p => p.LocatablePromos)
                .WithOne(p => p.Locatable)
                .HasForeignKey(p => p.LocatableId);

            builder.Entity<Locatable>()
                .HasOne(p => p.Estate)
                .WithOne(p => p.Locatable)
                .HasForeignKey<Estate>(p => p.LocatableId);


            //LocatableType Entity

            builder.Entity<LocatableType>().ToTable("LocatableTypes");
            builder.Entity<LocatableType>().HasKey(p => p.Id);
            builder.Entity<LocatableType>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<LocatableType>().Property(p => p.Name);
            builder.Entity<LocatableType>()
                .HasOne(p => p.Locatable)
                .WithOne(p => p.LocatableType)
                .HasForeignKey<Locatable>(p => p.LocatableTypeId);


            //LocatablePromo Entity

            builder.Entity<LocatablePromo>().ToTable("LocatablePromos");
            builder.Entity<LocatablePromo>().HasKey(p => new { p.LocatableId, p.PromoId });


            //Partner Entity

            builder.Entity<Partner>().ToTable("Partners");
            builder.Entity<Partner>().HasKey(p => p.Id);
            builder.Entity<Partner>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            
            builder.Entity<Partner>()
                .HasMany(p => p.Promos)
                .WithOne(p => p.Partner)
                .HasForeignKey(p => p.PartnerId);

            builder.Entity<Partner>()
                .HasOne(p => p.PartnerProfile)
                .WithOne(p => p.Partner)
                .HasForeignKey<PartnerProfile>(p => p.PartnerId);
            builder.Entity<Partner>()
                .HasMany(p => p.Estates)
                .WithOne(p => p.Partner)
                .HasForeignKey(p => p.PartnerId);

            //PartnerProfile Entity

            builder.Entity<PartnerProfile>().ToTable("PartnerProfiles");
            builder.Entity<PartnerProfile>().HasKey(p => p.Id);
            builder.Entity<PartnerProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PartnerProfile>().Property(p => p.Telephone);
            builder.Entity<PartnerProfile>().Property(p => p.Email);
            builder.Entity<PartnerProfile>().Property(p => p.Address);

            
            //Place Entity

            builder.Entity<Place>().ToTable("Places");
            builder.Entity<Place>().HasKey(p => p.Id);
            builder.Entity<Place>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Place>().Property(p => p.CityId).IsRequired();
            builder.Entity<Place>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<Place>().Property(p => p.Stars);
            builder.Entity<Place>().Property(p => p.LocatableId).IsRequired();

            //PlaceCategories Entity

            builder.Entity<PlaceCategory>().ToTable("PlaceCategories");
            builder.Entity<PlaceCategory>()
            .HasKey(pt => new { pt.CategoryId, pt.PlaceId });

            builder.Entity<PlaceCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(p => p.PlaceCategories)
                .HasForeignKey(pt => pt.CategoryId);

            builder.Entity<PlaceCategory>()
                .HasOne(pt => pt.Place)
                .WithMany(t => t.PlaceCategories)
                .HasForeignKey(pt => pt.PlaceId);

            //Plans Entity

            builder.Entity<Plan>().ToTable("Plans");
            builder.Entity<Plan>().HasKey(p => p.Id);
            builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Plan>()
                .HasMany(p => p.PlanBenefits)
                .WithOne(p => p.Plan)
                .HasForeignKey(p => p.PlanId);

            builder.Entity<Plan>()
                .HasMany(p => p.PlanUsers)
                .WithOne(p => p.Plan)
                .HasForeignKey(p => p.PlanId);


            //PlanBenefits Entity

            builder.Entity<PlanBenefit>().ToTable("PlanBenefits");
            builder.Entity<PlanBenefit>().HasKey(p => new { p.BenefitId, p.PlanId });
            builder.Entity<PlanBenefit>().Property(p => p.StartDate);
            builder.Entity<PlanBenefit>().Property(p => p.EndDate);

            //PlanUsers Entity

            builder.Entity<PlanUser>().ToTable("PlanUsers");
            builder.Entity<PlanUser>().HasKey(p => new { p.UserId, p.PlanId });
            builder.Entity<PlanUser>().Property(p => p.StartDate);
            builder.Entity<PlanUser>().Property(p => p.EndDate);

            //Promo Entity

            builder.Entity<Promo>().ToTable("Promos");
            builder.Entity<Promo>().HasKey(p => p.Id);
            builder.Entity<Promo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Promo>().Property(p => p.Text).IsRequired();
            builder.Entity<Promo>().Property(p => p.Discount);

            builder.Entity<Promo>()
                .HasMany(p => p.LocatablePromos)
                .WithOne(p => p.Promo)
                .HasForeignKey(p => p.PromoId);
                

            //Review Entity

            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.LocatableId).IsRequired(); 
            builder.Entity<Review>().Property(p => p.UserProfileId).IsRequired();
            builder.Entity<Review>().Property(p => p.Comment).IsRequired();
            builder.Entity<Review>().Property(p => p.Stars).IsRequired();
            builder.Entity<Review>().Property(p => p.ReviewedAt);

            //Service Entity

            builder.Entity<Service>().ToTable("Services");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired();

            builder.Entity<Service>()
                .HasMany(p => p.EstateServices)
                .WithOne(p => p.Service)
                .HasForeignKey(p => p.ServiceId);


            //Tip Entity

            builder.Entity<Tip>().ToTable("Tips");
            builder.Entity<Tip>().HasKey(p => p.Id);
            builder.Entity<Tip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tip>().Property(p => p.Text).IsRequired().HasMaxLength(100);
            builder.Entity<Tip>().Property(p => p.LocatableId).IsRequired();
            
            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(45);
            builder.Entity<User>().Property(p => p.WalletId);
            builder.Entity<User>()
                .HasOne(p => p.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            builder.Entity<User>()
                .HasMany(p => p.Favourites)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            


            //UserAchievements Entity 

            builder.Entity<UserAchievement>().ToTable("UserAchievements");
            builder.Entity<UserAchievement>().HasKey(p => new { p.UserId, p.AchievementId});
            builder.Entity<UserAchievement>().Property(p => p.UserId).IsRequired();
            builder.Entity<UserAchievement>().Property(p => p.AchievementId).IsRequired();
            builder.Entity<UserAchievement>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.UserId);
            builder.Entity<UserAchievement>()
                .HasOne(p => p.Achievement)
                .WithMany(p => p.UserAchievements)
                .HasForeignKey(p => p.AchievementId);

            

            //UserProfile Entity

            builder.Entity<UserProfile>().ToTable("UserProfiles");
            builder.Entity<UserProfile>().HasKey(p => p.Id);
            builder.Entity<UserProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd().HasMaxLength(11);
            builder.Entity<UserProfile>().Property(p => p.UserId).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            builder.Entity<UserProfile>().Property(p => p.Surname).IsRequired().HasMaxLength(45);
            builder.Entity<UserProfile>().Property(p => p.BirthDate);
            builder.Entity<UserProfile>().Property(p => p.Gender).HasMaxLength(6);
            builder.Entity<UserProfile>().Property(p => p.CreatedAt);
            builder.Entity<UserProfile>().Property(p => p.CountryId).IsRequired();

            builder.Entity<UserProfile>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.UserProfile)
                .HasForeignKey(p => p.UserProfileId);

            builder.Entity<UserProfile>()
                .HasMany(p => p.Tips)
                .WithOne(p => p.UserProfile)
                .HasForeignKey(p => p.UserProfileId);

            //Wallet Entity

            builder.Entity<Wallet>().ToTable("Wallets");
            builder.Entity<Wallet>().HasKey(p => p.Id);
            builder.Entity<Wallet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Wallet>().Property(p => p.Points);
            builder.Entity<Wallet>()
                .HasOne(p => p.User)
                .WithOne(p => p.Wallet)
                .HasForeignKey<User>(p => p.WalletId);
            
           

            



            ApplySnakeCaseNamingConvention(builder);
        }
        private void ApplySnakeCaseNamingConvention(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }
    }
    
}
