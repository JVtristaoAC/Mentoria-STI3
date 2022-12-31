﻿// <auto-generated />
using System;
using MentoriaSTI3.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MentoriaSTI3.Data.Migrations
{
    [DbContext(typeof(MentoriaDevSTI3Context))]
    [Migration("20221231004054_deletePagamentos")]
    partial class deletePagamentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MentoriaSTI3.Data.Entity.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("char(100)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("char(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MentoriaSTI3.Data.Entity.ItemPedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("PedidoId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdutoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("MentoriaSTI3.Data.Entity.Pedido", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("FormaPagamento")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MentoriaSTI3.Data.Entity.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MentoriaSTI3.Data.Entity.ItemPedido", b =>
                {
                    b.HasOne("MentoriaSTI3.Data.Entity.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MentoriaSTI3.Data.Entity.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MentoriaSTI3.Data.Entity.Pedido", b =>
                {
                    b.HasOne("MentoriaSTI3.Data.Entity.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("MentoriaSTI3.Data.Entity.Pedido", b =>
                {
                    b.Navigation("ItensPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
