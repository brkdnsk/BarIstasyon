using System;
using Microsoft.EntityFrameworkCore;
using BarIstasyon.Entity.Entities;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BarIstasyon.DataAccess.Context
{
	public class CoffeeContext : DbContext
	{
		public CoffeeContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Banner> Banners { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Base> Bases { get; set; }

        public DbSet<Category> Catagories { get; set; }

        public DbSet<Coffee> Coffees { get; set; }

        public DbSet<CoffeeDescription> CoffeeDescriptions { get; set; }

        public DbSet<CoffeeFeature> CoffeeFeatures { get; set; }

        public DbSet<CoffeePricing> CoffeePricings { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<FooterAddress> FooterAddresses { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Pricing> Pricings { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<SocialMedia> SocialMedias { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>().ToCollection("Banners");
            modelBuilder.Entity<About>().ToCollection("Abouts");
            modelBuilder.Entity<Base>().ToCollection("Bases");
            modelBuilder.Entity<Category>().ToCollection("Categories");
            modelBuilder.Entity<Coffee>().ToCollection("Coffees");
            modelBuilder.Entity<CoffeeDescription>().ToCollection("CoffeeDescriptions");
            modelBuilder.Entity<CoffeeFeature>().ToCollection("CoffeeFeatures");
            modelBuilder.Entity<CoffeePricing>().ToCollection("CoffeePricings");
            modelBuilder.Entity<Contact>().ToCollection("Contacts");
            modelBuilder.Entity<Feature>().ToCollection("Features");
            modelBuilder.Entity<FooterAddress>().ToCollection("FooterAddresses");
            modelBuilder.Entity<Location>().ToCollection("Locations");
            modelBuilder.Entity<Pricing>().ToCollection("Pricings");
            modelBuilder.Entity<Service>().ToCollection("Services");
            modelBuilder.Entity<SocialMedia>().ToCollection("SocialMedias   ");














        }


    }
}

