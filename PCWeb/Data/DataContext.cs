﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCWeb.Models;
using PCWeb.Models.Account;
using PCWeb.Models.Name;
using PCWeb.Models.Root;
using PCWeb.Models.Source;

namespace PCWeb.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<PC> PCs { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<LaptopCategory> LaptopCategories { get; set; }
        public DbSet<PCCategory> PCCategories { get; set; }
        public DbSet<OrderCondition> OrderConditions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<Cooling> Coolings { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<Graphic> Graphics { get; set; }
        public DbSet<Mainboard> Mainboards { get; set; }
        public DbSet<Memory> Memories { get; set; }
        public DbSet<Power> Powers { get; set; }
        public DbSet<PCComponent> PCComponents { get; set; }
        public DbSet<ComponentCategory> ComponentCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Laptop"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "PC"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Linh kiện máy tính"
                });
            builder.Entity<LaptopCategory>().HasData(
                new LaptopCategory() {
                    LaptopCategoryId = 1,
                    LaptopCategoryName = "Laptop Phổ Thông"
                },
                new LaptopCategory()
                {
                    LaptopCategoryId = 2,
                    LaptopCategoryName = "Laptop Gaming"
                },
                new LaptopCategory()
                {
                    LaptopCategoryId = 3,
                    LaptopCategoryName = "Laptop Doanh Nhân"
                },
                new LaptopCategory()
                {
                    LaptopCategoryId = 4,
                    LaptopCategoryName = "Laptop Workstation"
                },
                new LaptopCategory()
                {
                    LaptopCategoryId = 5,
                    LaptopCategoryName = "Laptop Cũ"
                });
            builder.Entity<PCCategory>().HasData(
                new PCCategory()
                {
                    PCCategoryId = 1,
                    PCCategoryName = "PC Văn Phòng"
                },
                new PCCategory()
                {
                    PCCategoryId = 2,
                    PCCategoryName = "PC Gaming"
                },
                new PCCategory()
                {
                    PCCategoryId = 3,
                    PCCategoryName = "PC Workstation"
                },
                new PCCategory()
                {
                    PCCategoryId = 4,
                    PCCategoryName = "PC Đồng bộ"
                },
                new PCCategory()
                {
                    PCCategoryId = 5,
                    PCCategoryName = "PC Cũ"
                });
            builder.Entity<Brand>().HasData(
                new Brand()
                {
                    BrandId = 1,
                    BrandName = "PCBang"
                },
                new Brand()
                {
                    BrandId = 2,
                    BrandName = "PCWorld"
                });
            builder.Entity<OrderCondition>().HasData(
                new OrderCondition()
                {
                    OrderConditionId = 1,
                    OrderConditionName = "Đã nhận đơn hàng"
                },
                new OrderCondition()
                {
                    OrderConditionId = 2,
                    OrderConditionName = "Đã xem đơn hàng"
                },
                new OrderCondition()
                {
                    OrderConditionId = 3,
                    OrderConditionName = "Đang đóng gói"
                },
                new OrderCondition()
                {
                    OrderConditionId = 4,
                    OrderConditionName = "Đang vận chuyển"
                },
                new OrderCondition()
                {
                    OrderConditionId = 5,
                    OrderConditionName = "Giao hàng thành công"
                },
                new OrderCondition()
                {
                    OrderConditionId = 6,
                    OrderConditionName = "Đã hủy đơn"
                });
            builder.Entity<ComponentCategory>().HasData(
                new ComponentCategory
                {
                    ComponentCategoryId = 1,
                    ComponentCategoryName = "CPU"
                },
                new ComponentCategory
                {
                    ComponentCategoryId = 2,
                    ComponentCategoryName = "Card đồ họa"
                },
                new ComponentCategory
                {
                    ComponentCategoryId = 3,
                    ComponentCategoryName = "Lưu trữ"
                },
                new ComponentCategory
                {
                    ComponentCategoryId = 4,
                    ComponentCategoryName = "Mainboard"
                },
                new ComponentCategory
                {
                    ComponentCategoryId = 5,
                    ComponentCategoryName = "Tản nhiệt"
                },
                new ComponentCategory
                {
                    ComponentCategoryId = 6,
                    ComponentCategoryName = "RAM"
                },
                new ComponentCategory
                {
                    ComponentCategoryId = 7,
                    ComponentCategoryName = "Nguồn"
                },
                new ComponentCategory
                {
                    ComponentCategoryId = 8,
                    ComponentCategoryName = "Case Máy tính"
                });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Staff",
                    NormalizedName = "STAFF"
                }
            );
        }
    }
}