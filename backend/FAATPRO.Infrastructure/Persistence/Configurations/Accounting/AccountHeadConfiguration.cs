using FAATPRO.Domain.Entities.Accounting;
using FAATPRO.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FAATPRO.Infrastructure.Persistence.Configurations.Accounting;

public class AccountHeadConfiguration : IEntityTypeConfiguration<AccountHead>
{
    public void Configure(EntityTypeBuilder<AccountHead> builder)
    {
        builder.ToTable("AccountHeads");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Nature)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .HasDefaultValue(0);

        builder.Property(x => x.IsSystem)
            .HasDefaultValue(false);

        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);

        builder.Property(x => x.CreatedOn)
            .HasDefaultValueSql("NOW()");

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.HasIndex(x => x.Name);


        // Seed Data
        builder.HasData(
            new AccountHead
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Code = "AST",
                Name = "Assets",
                Nature = AccountNature.Debit,
                DisplayOrder = 1,
                IsSystem = true,
                IsActive = true,
                CreatedOn = new DateTime(2026, 7, 30, 0, 0, 0, DateTimeKind.Utc)
            },

            new AccountHead
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Code = "LIA",
                Name = "Liabilities",
                Nature = AccountNature.Credit,
                DisplayOrder = 2,
                IsSystem = true,
                IsActive = true,
                CreatedOn = new DateTime(2026, 7, 30, 0, 0, 0, DateTimeKind.Utc)
            },

            new AccountHead
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Code = "CAP",
                Name = "Capital",
                Nature = AccountNature.Credit,
                DisplayOrder = 3,
                IsSystem = true,
                IsActive = true,
                CreatedOn = new DateTime(2026, 7, 30, 0, 0, 0, DateTimeKind.Utc)
            },

            new AccountHead
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Code = "INC",
                Name = "Income",
                Nature = AccountNature.Credit,
                DisplayOrder = 4,
                IsSystem = true,
                IsActive = true,
                CreatedOn = new DateTime(2026, 7, 30, 0, 0, 0, DateTimeKind.Utc)
            },

            new AccountHead
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Code = "EXP",
                Name = "Expenses",
                Nature = AccountNature.Debit,
                DisplayOrder = 5,
                IsSystem = true,
                IsActive = true,
                CreatedOn = new DateTime(2026, 7, 30, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}