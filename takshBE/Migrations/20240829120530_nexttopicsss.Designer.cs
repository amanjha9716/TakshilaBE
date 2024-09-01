﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using takshBE.Model;

#nullable disable

namespace takshBE.Migrations
{
    [DbContext(typeof(studentDbcontext))]
    [Migration("20240829120530_nexttopicsss")]
    partial class nexttopicsss
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("takshBE.Model.ApiDataResult", b =>
                {
                    b.Property<string>("DataName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Request")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ApiDataResults");
                });

            modelBuilder.Entity("takshBE.Model.Assessment", b =>
                {
                    b.Property<Guid>("assesid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("assessename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("expirydate")
                        .HasColumnType("date");

                    b.Property<string>("questions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stan")
                        .HasColumnType("int");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("totalstud")
                        .HasColumnType("int");

                    b.HasKey("assesid");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("takshBE.Model.NextTopic", b =>
                {
                    b.Property<int>("topicid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("topicid"));

                    b.Property<DateOnly>("classdate")
                        .HasColumnType("date");

                    b.Property<int>("completion")
                        .HasColumnType("int");

                    b.Property<int>("stand")
                        .HasColumnType("int");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("topicname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("topicid");

                    b.ToTable("NextTopics");
                });

            modelBuilder.Entity("takshBE.Model.Notice", b =>
                {
                    b.Property<Guid>("noticeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("noticeid");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("takshBE.Model.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stan")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("takshBE.Model.Question", b =>
                {
                    b.Property<Guid>("quesid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("options")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("standard")
                        .HasColumnType("int");

                    b.Property<string>("statement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("quesid");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("takshBE.Model.Result", b =>
                {
                    b.Property<Guid>("resultid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("assesid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("marks")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("resultid");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("takshBE.Model.Student", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Doj")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stand")
                        .HasColumnType("int");

                    b.Property<string>("Studname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("takshBE.Model.studyMaterial", b =>
                {
                    b.Property<Guid>("pdfid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("pdfcontent")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("pdfname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("standard")
                        .HasColumnType("int");

                    b.Property<string>("subjectname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pdfid");

                    b.ToTable("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}
