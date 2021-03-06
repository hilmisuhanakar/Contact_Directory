// <auto-generated />
using Contact_Directory_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contact_Directory_API.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20220315061525_updateDb")]
    partial class updateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contact_Directory_API.Models.Person", b =>
                {
                    b.Property<int>("personId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("emaikl2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tel1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tel2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("personId");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
