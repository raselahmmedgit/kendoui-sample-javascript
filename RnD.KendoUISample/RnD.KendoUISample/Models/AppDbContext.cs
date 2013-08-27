using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RnD.KendoUISample.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<DADModel> DADModels { get; set; }
        public DbSet<DADMaster> DADMasters { get; set; }
        public DbSet<DADDetail> DADDetails { get; set; }
        public DbSet<DADDetailItem> DADDetailItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }

    #region Initial data

    // Change the base class as follows if you want to drop and create the database during development:
    //public class DBInitializer : DropCreateDatabaseAlways<AppDbContext>
    //public class DBInitializer : CreateDatabaseIfNotExists<AppDbContext>
    public class DBInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            // Create default categories.
            var categories = new List<Category>
                            {
                                new Category { CategoryId=1, Name = "Fruit"},
                                new Category {CategoryId=2, Name = "Cloth"},
                                new Category {CategoryId=3, Name = "Car"},
                                new Category {CategoryId=4, Name = "Book"},
                                new Category {CategoryId=5, Name = "Shoe"},
                                new Category {CategoryId=6, Name = "Wiper"},
                                new Category {CategoryId=7, Name = "Laptop"},
                                new Category {CategoryId=8, Name = "Desktop"},
                                new Category {CategoryId=9, Name = "Notebook"},
                                new Category {CategoryId=10, Name = "AC"}

                            };

            categories.ForEach(c => context.Categories.Add(c));

            context.SaveChanges();

            // Create some products.
            var products = new List<Product> 
                        {
                            new Product {ProductId=1, Name="Apple", Price=15, CategoryId=1},
                            new Product {ProductId=2, Name="Mango", Price=20, CategoryId=1},
                            new Product {ProductId=3, Name="Orange", Price=15, CategoryId=1},
                            new Product {ProductId=4, Name="Banana", Price=20, CategoryId=1},
                            new Product {ProductId=5, Name="Licho", Price=15, CategoryId=1},
                            new Product {ProductId=6, Name="Jack Fruit", Price=20, CategoryId=1},

                            new Product {ProductId=7, Name="Toyota", Price=15000, CategoryId=2},
                            new Product {ProductId=8, Name="Nissan", Price=20000, CategoryId=2},
                            new Product {ProductId=9, Name="Tata", Price=50000, CategoryId=2},
                            new Product {ProductId=10, Name="Honda", Price=20000, CategoryId=2},
                            new Product {ProductId=11, Name="Kimi", Price=50000, CategoryId=2},
                            new Product {ProductId=12, Name="Suzuki", Price=20000, CategoryId=2},
                            new Product {ProductId=13, Name="Ferrari", Price=50000, CategoryId=2},

                            new Product {ProductId=14, Name="T Shirt", Price=20000, CategoryId=3},
                            new Product {ProductId=15, Name="Polo Shirt", Price=50000, CategoryId=3},
                            new Product {ProductId=16, Name="Shirt", Price=200, CategoryId=3},
                            new Product {ProductId=17, Name="Panjabi", Price=500, CategoryId=3},
                            new Product {ProductId=18, Name="Fotuya", Price=200, CategoryId=3},
                            new Product {ProductId=19, Name="Shari", Price=500, CategoryId=3},
                            new Product {ProductId=19, Name="Kamij", Price=400, CategoryId=3},

                            new Product {ProductId=20, Name="History", Price=20000, CategoryId=4},
                            new Product {ProductId=21, Name="Fire Out", Price=50000, CategoryId=4},
                            new Product {ProductId=22, Name="Apex", Price=200, CategoryId=5},
                            new Product {ProductId=23, Name="Bata", Price=500, CategoryId=5},
                            new Product {ProductId=24, Name="Acer", Price=200, CategoryId=8},
                            new Product {ProductId=25, Name="Dell", Price=500, CategoryId=8},
                            new Product {ProductId=26, Name="HP", Price=400, CategoryId=8}

                        };

            products.ForEach(p => context.Products.Add(p));

            context.SaveChanges();

            // Create default DADMasters.
            var DADMasters = new List<DADMaster>
                            {
                                new DADMaster { DADMasterId=1, FundSource = "A"},
                                new DADMaster { DADMasterId=2, FundSource = "B"},
                                new DADMaster { DADMasterId=3, FundSource = "C"},
                                new DADMaster { DADMasterId=4, FundSource = "D"},
                                
                            };

            DADMasters.ForEach(c => context.DADMasters.Add(c));

            context.SaveChanges();

            // Create some DADDetails.
            var DADDetails = new List<DADDetail> 
                        {
                            new DADDetail {DADDetailId=1, FundAgency="A1", DADMasterId=1},
                            new DADDetail {DADDetailId=2, FundAgency="A2", DADMasterId=1},
                            new DADDetail {DADDetailId=3, FundAgency="A3", DADMasterId=1},
                            new DADDetail {DADDetailId=4, FundAgency="A4", DADMasterId=1},
                            new DADDetail {DADDetailId=5, FundAgency="A5", DADMasterId=1},
                            new DADDetail {DADDetailId=6, FundAgency="A6", DADMasterId=1},
                                
                            new DADDetail {DADDetailId=7, FundAgency="B1", DADMasterId=2},
                            new DADDetail {DADDetailId=8, FundAgency="B2", DADMasterId=2},
                            new DADDetail {DADDetailId=9, FundAgency="B3", DADMasterId=2},
                            new DADDetail {DADDetailId=10, FundAgency="B4", DADMasterId=2},
                            new DADDetail {DADDetailId=11, FundAgency="B5", DADMasterId=2},
                            new DADDetail {DADDetailId=12, FundAgency="B6", DADMasterId=2},
                            new DADDetail {DADDetailId=13, FundAgency="B7", DADMasterId=2},
                                
                            new DADDetail {DADDetailId=14, FundAgency="C1", DADMasterId=3},
                            new DADDetail {DADDetailId=15, FundAgency="C2", DADMasterId=3},
                            new DADDetail {DADDetailId=16, FundAgency="C3", DADMasterId=3},
                            new DADDetail {DADDetailId=17, FundAgency="C4", DADMasterId=3},
                            new DADDetail {DADDetailId=18, FundAgency="C5", DADMasterId=3},
                            new DADDetail {DADDetailId=19, FundAgency="C6", DADMasterId=3},
                            new DADDetail {DADDetailId=19, FundAgency="C7", DADMasterId=3},

                            new DADDetail {DADDetailId=20, FundAgency="D1", DADMasterId=4},
                            new DADDetail {DADDetailId=21, FundAgency="D2", DADMasterId=4},
                            new DADDetail {DADDetailId=22, FundAgency="D3", DADMasterId=4},
                            new DADDetail {DADDetailId=23, FundAgency="D4", DADMasterId=4},

                        };

            DADDetails.ForEach(p => context.DADDetails.Add(p));

            context.SaveChanges();

            // Create some DADDetailItems.
            var DADDetailItems = new List<DADDetailItem> 
                        {
                            new DADDetailItem {DADDetailItemId=1, Project="Apple", CommittedAmount=10, DisbursedAmount= 5, DADDetailId=1},
                            new DADDetailItem {DADDetailItemId=2, Project="Mango", CommittedAmount=20, DisbursedAmount= 12, DADDetailId=1},
                            new DADDetailItem {DADDetailItemId=3, Project="Orange", CommittedAmount=32, DisbursedAmount= 12, DADDetailId=2},
                            new DADDetailItem {DADDetailItemId=4, Project="Banana", CommittedAmount=25, DisbursedAmount= 15, DADDetailId=2},
                            new DADDetailItem {DADDetailItemId=5, Project="Licho", CommittedAmount=50, DisbursedAmount= 40, DADDetailId=3},
                            new DADDetailItem {DADDetailItemId=6, Project="Jack Fruit", CommittedAmount=24, DisbursedAmount= 21,  DADDetailId=3},

                            new DADDetailItem {DADDetailItemId=7, Project="Toyota", CommittedAmount=85, DisbursedAmount= 45,  DADDetailId=4},
                            new DADDetailItem {DADDetailItemId=8, Project="Nissan", CommittedAmount=46, DisbursedAmount= 21, DADDetailId=4},
                            new DADDetailItem {DADDetailItemId=9, Project="Tata", CommittedAmount=56, DisbursedAmount= 31, DADDetailId=5},
                            new DADDetailItem {DADDetailItemId=10, Project="Honda", CommittedAmount=84, DisbursedAmount= 22, DADDetailId=5},
                            new DADDetailItem {DADDetailItemId=11, Project="Kimi", CommittedAmount=58,  DisbursedAmount= 12, DADDetailId=6},
                            new DADDetailItem {DADDetailItemId=12, Project="Suzuki", CommittedAmount=98, DisbursedAmount= 14, DADDetailId=6},
                            new DADDetailItem {DADDetailItemId=13, Project="Ferrari", CommittedAmount=47, DisbursedAmount= 17, DADDetailId=7},

                            new DADDetailItem {DADDetailItemId=14, Project="T Shirt", CommittedAmount=60, DisbursedAmount= 20, DADDetailId=7},
                            new DADDetailItem {DADDetailItemId=15, Project="Polo Shirt", CommittedAmount=38, DisbursedAmount= 12,  DADDetailId=8},
                            new DADDetailItem {DADDetailItemId=16, Project="Shirt", CommittedAmount=75, DisbursedAmount= 15, DADDetailId=8},
                            new DADDetailItem {DADDetailItemId=17, Project="Panjabi", CommittedAmount=22, DisbursedAmount= 10, DADDetailId=9},
                            new DADDetailItem {DADDetailItemId=18, Project="Fotuya", CommittedAmount=47, DisbursedAmount= 15, DADDetailId=9},
                            new DADDetailItem {DADDetailItemId=19, Project="Shari", CommittedAmount=85, DisbursedAmount= 45, DADDetailId=10},
                            new DADDetailItem {DADDetailItemId=19, Project="Kamij", CommittedAmount=47, DisbursedAmount= 12, DADDetailId=11},

                            new DADDetailItem {DADDetailItemId=20, Project="History", CommittedAmount=86, DisbursedAmount= 14, DADDetailId=12},
                            new DADDetailItem {DADDetailItemId=21, Project="Fire Out", CommittedAmount=57, DisbursedAmount= 17, DADDetailId=11},
                            new DADDetailItem {DADDetailItemId=22, Project="Apex", CommittedAmount=58, DisbursedAmount= 14, DADDetailId=12},
                            new DADDetailItem {DADDetailItemId=23, Project="Bata", CommittedAmount=75, DisbursedAmount= 42, DADDetailId=13},
                            new DADDetailItem {DADDetailItemId=24, Project="Acer", CommittedAmount=85, DisbursedAmount= 42, DADDetailId=13},
                            new DADDetailItem {DADDetailItemId=25, Project="Dell", CommittedAmount=47, DisbursedAmount= 21, DADDetailId=14},
                            new DADDetailItem {DADDetailItemId=26, Project="HP", CommittedAmount=85, DisbursedAmount= 53,  DADDetailId=14}

                        };

            DADDetailItems.ForEach(p => context.DADDetailItems.Add(p));

            context.SaveChanges();

            // Create some DADModels.
            var DADModels = new List<DADModel> 
                        {
                            new DADModel {Id=1, FundSourceId=1, FundAgencyId = 1,ProjectId = 1, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=1, FundAgencyId = 1,ProjectId = 2, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=1, FundAgencyId = 2,ProjectId = 3, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=2, FundAgencyId = 2,ProjectId = 4, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=2, FundAgencyId = 2,ProjectId = 5, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=2, FundAgencyId = 3,ProjectId = 6, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=3, FundAgencyId = 3,ProjectId = 7, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=4, FundAgencyId = 3,ProjectId = 8, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=4, FundAgencyId = 4,ProjectId = 9, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=3, FundAgencyId = 5,ProjectId = 10, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=5, FundAgencyId = 5,ProjectId = 11, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=5, FundAgencyId = 6,ProjectId = 12, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=6, FundAgencyId = 6,ProjectId = 13, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=7, FundAgencyId = 7,ProjectId = 14, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f},
                            new DADModel {Id=1, FundSourceId=8, FundAgencyId = 8,ProjectId = 15, CommittedAmount=10.20f, DisbursedAmount= 55.25f, ExpendedAmount=10.45f}

                        };

            DADModels.ForEach(p => context.DADModels.Add(p));

            context.SaveChanges();

        }
    }

    #endregion
}