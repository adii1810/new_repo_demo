﻿// <auto-generated />
using System;
using Food_Delivery_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Food_Delivery_Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Order", b =>
                {
                    b.Property<int>("Order_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Order_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Order_Status_Id")
                        .HasColumnType("int");

                    b.Property<int>("User_DataId")
                        .HasColumnType("int");

                    b.Property<int>("ValetId")
                        .HasColumnType("int");

                    b.HasKey("Order_Id");

                    b.HasIndex("User_DataId");

                    b.HasIndex("ValetId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DataAccessLayer.Order_Detail", b =>
                {
                    b.Property<int>("Order_Detail_Id")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Order_Detail_Id", "OrderId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("Order_Detail");
                });

            modelBuilder.Entity("DataAccessLayer.Product", b =>
                {
                    b.Property<int>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodType")
                        .HasColumnType("int");

                    b.Property<string>("Product_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_Price")
                        .HasColumnType("int");

                    b.Property<bool>("Product_Status")
                        .HasColumnType("bit");

                    b.Property<int>("Restaurant_DetailId")
                        .HasColumnType("int");

                    b.Property<int>("Sub_CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Product_Id");

                    b.HasIndex("Restaurant_DetailId");

                    b.HasIndex("Sub_CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DataAccessLayer.ProductImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImgLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Restaurant_DetailId")
                        .HasColumnType("int");

                    b.Property<string>("imgName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("DataAccessLayer.Restaurant_Detail", b =>
                {
                    b.Property<int>("Restaurant_Detail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Restaurant_Detail_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_User_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restaurant_Detail_Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status_by_Admin")
                        .HasColumnType("bit");

                    b.HasKey("Restaurant_Detail_Id");

                    b.ToTable("Restaurant_Detail");
                });

            modelBuilder.Entity("DataAccessLayer.Sub_Category", b =>
                {
                    b.Property<int>("Sub_Category_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Main_Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Sub_Category_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Sub_Category_Id");

                    b.ToTable("Sub_Categorie");
                });

            modelBuilder.Entity("DataAccessLayer.User_Data", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("User_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_ZipCode")
                        .HasColumnType("int");

                    b.HasKey("User_Id");

                    b.ToTable("User_Data");

                    b.HasData(
                        new
                        {
                            User_Id = 1,
                            User_Address = "Surat",
                            User_City = "surat",
                            User_Email = "admin@admin.com",
                            User_FirstName = "aditya",
                            User_LastName = "neve",
                            User_Password = "admin123",
                            User_PhoneNo = "8469712459",
                            User_UserName = "Admin",
                            User_ZipCode = 0
                        });
                });

            modelBuilder.Entity("DataAccessLayer.User_Rating", b =>
                {
                    b.Property<int>("User_Rating_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("User_DataId")
                        .HasColumnType("int");

                    b.Property<int>("User_Rating_Star")
                        .HasColumnType("int");

                    b.HasKey("User_Rating_Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("User_DataId");

                    b.ToTable("User_Rating");
                });

            modelBuilder.Entity("DataAccessLayer.User_Review", b =>
                {
                    b.Property<int>("User_Review_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Product_Id")
                        .HasColumnType("int");

                    b.Property<int?>("User_DataUser_Id")
                        .HasColumnType("int");

                    b.Property<string>("User_Review_Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_Review_Id");

                    b.HasIndex("Product_Id");

                    b.HasIndex("User_DataUser_Id");

                    b.ToTable("User_Review");
                });

            modelBuilder.Entity("DataAccessLayer.Valet", b =>
                {
                    b.Property<int>("Valet_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Valet_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valet_Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Valet_Id");

                    b.ToTable("Valet");
                });

            modelBuilder.Entity("DataAccessLayer.Order", b =>
                {
                    b.HasOne("DataAccessLayer.User_Data", "User_Data")
                        .WithMany("Orders")
                        .HasForeignKey("User_DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Valet", "Valet")
                        .WithMany("Orders")
                        .HasForeignKey("ValetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Order_Detail", b =>
                {
                    b.HasOne("DataAccessLayer.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.Product", b =>
                {
                    b.HasOne("DataAccessLayer.Restaurant_Detail", "Restaurant_Detail")
                        .WithMany("Products")
                        .HasForeignKey("Restaurant_DetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Sub_Category", "Sub_Category")
                        .WithMany("Products")
                        .HasForeignKey("Sub_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.User_Rating", b =>
                {
                    b.HasOne("DataAccessLayer.Product", "Product")
                        .WithMany("User_Ratings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.User_Data", "User_Data")
                        .WithMany("User_Ratings")
                        .HasForeignKey("User_DataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.User_Review", b =>
                {
                    b.HasOne("DataAccessLayer.Product", "Product")
                        .WithMany("User_Reviews")
                        .HasForeignKey("Product_Id");

                    b.HasOne("DataAccessLayer.User_Data", "User_Data")
                        .WithMany("User_Reviews")
                        .HasForeignKey("User_DataUser_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
