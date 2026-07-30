using FAATPRO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FAATPRO.Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompanyCode)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.CompanyCode)
            .IsUnique();

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.LegalName)
            .HasMaxLength(200);

        builder.Property(x => x.GSTNumber)
            .HasMaxLength(20);

        builder.Property(x => x.PANNumber)
            .HasMaxLength(20);

        builder.Property(x => x.CINNumber)
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasMaxLength(150);

        builder.Property(x => x.Phone)
            .HasMaxLength(20);

        builder.Property(x => x.Website)
            .HasMaxLength(200);

        builder.Property(x => x.AddressLine1)
            .HasMaxLength(300);

        builder.Property(x => x.AddressLine2)
            .HasMaxLength(300);

        builder.Property(x => x.City)
            .HasMaxLength(100);

        builder.Property(x => x.State)
            .HasMaxLength(100);

        builder.Property(x => x.Country)
            .HasMaxLength(100);

        builder.Property(x => x.PostalCode)
            .HasMaxLength(20);

        builder.Property(x => x.CurrencyCode)
            .HasMaxLength(10);

        builder.Property(x => x.FinancialYearStartMonth)
            .HasMaxLength(20);
    }
}