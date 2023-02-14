using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Delivery.Entity;


namespace Delivery.Data.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                    .HasMaxLength(100)
                    .HasColumnType("text")
                    .IsRequired();

            builder.Property(b => b.PhoneNumber)
                    .HasMaxLength(9)
                    .HasColumnType("text")
                    .HasColumnName("PhoneNumberCostumer")
                    .IsRequired();

            builder.Property(b => b.Email)
                    .HasMaxLength(120)
                    .HasColumnType("text")
                    .IsRequired();
            builder.Property(b => b.Address)
                    .HasMaxLength(120)
                    .HasColumnType("text")
                    .IsRequired();
            /* builder.HasData(
                 new Customer
                 {
                     Id = 1,
                     Name = "Albert Romero",
                     Email = "albertromero.edu.sv",
                     Address = "La Union",
                     PhoneNumber = "2345-2343",
                     Status = true
                 },
             new Customer
             {
                 Id = 2,
                 Name = "Alba Lopez",
                 Email = "albalopez.edu.sv",
                 Address = "San Miguel",
                 PhoneNumber = "2040-2040",
                 Status = true
             }

         );*/
        }
    }
}
