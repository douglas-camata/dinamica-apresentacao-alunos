﻿// <auto-generated />
using App.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApresentaçãoAlunos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240116132542_Atualizacao01")]
    partial class Atualizacao01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("App.Models.Resposta", b =>
                {
                    b.Property<int>("RespostaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resp1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resp2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resp3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resp4")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resp5")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Resp6")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RespostaId");

                    b.ToTable("Respostas");
                });
#pragma warning restore 612, 618
        }
    }
}
