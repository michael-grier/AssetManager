using System;
using CPRG214.AssetManager.Domain;
using Microsoft.EntityFrameworkCore;


namespace CPRG214.AssetManager.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext() : base() { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // change this connection string to work on your local machine
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;
                                          Database=AssetManager;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed data
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer" },
                new AssetType { Id = 2, Name = "Monitor" },
                new AssetType { Id = 3, Name = "Phone" }
                );

            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    TagNumber = "101",
                    AssetTypeId = 1,
                    Manufacturer = "Dell",
                    Model = "PowerEdge T340",
                    Description = "Desktop computer tower",
                    SerialNumber = "D12L34"
                },
                new Asset
                {
                    Id = 2,
                    TagNumber = "102",
                    AssetTypeId = 1,
                    Manufacturer = "HP",
                    Model = "Pavillion 27\" All-in-One",
                    Description = "All-in-one desktop computer",
                    SerialNumber = "H45P67"
                },
                new Asset
                {
                    Id = 3,
                    TagNumber = "103",
                    AssetTypeId = 1,
                    Manufacturer = "Acer",
                    Model = "Swift 7",
                    Description = "Laptop computer",
                    SerialNumber = "A89C01"
                },
                new Asset
                {
                    Id = 4,
                    TagNumber = "201",
                    AssetTypeId = 2,
                    Manufacturer = "Acer",
                    Model = "21.5\" B7 Professional",
                    Description = "Widescreen computer monitor",
                    SerialNumber = "A23C45"
                },
                new Asset
                {
                    Id = 5,
                    TagNumber = "202",
                    AssetTypeId = 2,
                    Manufacturer = "LG",
                    Model = "34\" UltraWide QHD",
                    Description = "Ultra-widescreen computer monitor",
                    SerialNumber = "L67G89"
                },
                new Asset
                {
                    Id = 6,
                    TagNumber = "203",
                    AssetTypeId = 2,
                    Manufacturer = "HP",
                    Model = "Envy 27",
                    Description = "4k computer monitor",
                    SerialNumber = "H01P23"
                },
                new Asset
                {
                    Id = 7,
                    TagNumber = "301",
                    AssetTypeId = 3,
                    Manufacturer = "Avaya",
                    Model = "T7316E",
                    Description = "Multiline deskphone",
                    SerialNumber = "A45V67"
                },
                new Asset
                {
                    Id = 8,
                    TagNumber = "302",
                    AssetTypeId = 3,
                    Manufacturer = "Polycom",
                    Model = "VVX 411 IP",
                    Description = "Multiline deskphone",
                    SerialNumber = "P89C01"
                },
                new Asset
                {
                    Id = 9,
                    TagNumber = "303",
                    AssetTypeId = 3,
                    Manufacturer = "Cisco",
                    Model = "8861 IP",
                    Description = "Multiline deskphone",
                    SerialNumber = "C23C45"
                }
                );
        }
    }
}
