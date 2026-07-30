using FAATPRO.Domain.Entities;
using FAATPRO.Domain.Entities.Accounting;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Persistence;


public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }



    // ==========================================
    // Company Module
    // ==========================================

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Branch> Branches => Set<Branch>();

    public DbSet<FinancialYear> FinancialYears => Set<FinancialYear>();

    public DbSet<Currency> Currencies => Set<Currency>();

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<State> States => Set<State>();

    public DbSet<City> Cities => Set<City>();





    // ==========================================
    // Identity Module
    // ==========================================

    public DbSet<User> Users => Set<User>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Permission> Permissions => Set<Permission>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();





    // ==========================================
    // Accounting Module
    // ==========================================

    public DbSet<AccountHead> AccountHeads => Set<AccountHead>();

    public DbSet<AccountGroup> AccountGroups => Set<AccountGroup>();

    public DbSet<AccountSubGroup> AccountSubGroups => Set<AccountSubGroup>();

    public DbSet<Ledger> Ledgers => Set<Ledger>();

    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();

    public DbSet<JournalEntryDetail> JournalEntryDetails => Set<JournalEntryDetail>();





    // ==========================================
    // CRM Module
    // ==========================================

    public DbSet<Customer> Customers => Set<Customer>();






    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);



        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);






        // ==========================================
        // User Role Mapping
        // ==========================================

        modelBuilder.Entity<UserRole>()
            .HasKey(x => new
            {
                x.UserId,
                x.RoleId
            });


        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId);


        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId);






        // ==========================================
        // Role Permission Mapping
        // ==========================================

        modelBuilder.Entity<RolePermission>()
            .HasKey(x => new
            {
                x.RoleId,
                x.PermissionId
            });


        modelBuilder.Entity<RolePermission>()
            .HasOne(x => x.Role)
            .WithMany(x => x.RolePermissions)
            .HasForeignKey(x => x.RoleId);


        modelBuilder.Entity<RolePermission>()
            .HasOne(x => x.Permission)
            .WithMany(x => x.RolePermissions)
            .HasForeignKey(x => x.PermissionId);






        // ==========================================
        // Refresh Token
        // ==========================================

        modelBuilder.Entity<RefreshToken>()
            .HasOne(x => x.User)
            .WithMany(x => x.RefreshTokens)
            .HasForeignKey(x => x.UserId);






        // ==========================================
        // Country State City
        // ==========================================

        modelBuilder.Entity<Country>()
            .HasIndex(x => x.Code)
            .IsUnique();


        modelBuilder.Entity<Country>()
            .HasMany(x => x.States)
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);


        modelBuilder.Entity<State>()
            .HasMany<City>()
            .WithOne(x => x.State)
            .HasForeignKey(x => x.StateId);






        // ==========================================
        // Account Head
        // ==========================================

        modelBuilder.Entity<AccountHead>()
            .HasIndex(x => x.Code)
            .IsUnique();






        // ==========================================
        // Account Group
        // ==========================================

        modelBuilder.Entity<AccountGroup>()
            .HasIndex(x => x.Code)
            .IsUnique();


        modelBuilder.Entity<AccountGroup>()
            .HasOne(x => x.AccountHead)
            .WithMany(x => x.AccountGroups)
            .HasForeignKey(x => x.AccountHeadId)
            .OnDelete(DeleteBehavior.Restrict);






        // ==========================================
        // Account Sub Group
        // ==========================================

        modelBuilder.Entity<AccountSubGroup>()
            .HasIndex(x => x.Code)
            .IsUnique();


        modelBuilder.Entity<AccountSubGroup>()
            .HasOne(x => x.AccountGroup)
            .WithMany()
            .HasForeignKey(x => x.AccountGroupId)
            .OnDelete(DeleteBehavior.Restrict);






        // ==========================================
        // Ledger
        // ==========================================

        modelBuilder.Entity<Ledger>()
            .HasIndex(x => x.Code)
            .IsUnique();


        modelBuilder.Entity<Ledger>()
            .HasOne(x => x.AccountHead)
            .WithMany()
            .HasForeignKey(x => x.AccountHeadId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Ledger>()
            .HasOne(x => x.AccountGroup)
            .WithMany()
            .HasForeignKey(x => x.AccountGroupId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Ledger>()
            .HasOne(x => x.AccountSubGroup)
            .WithMany()
            .HasForeignKey(x => x.AccountSubGroupId)
            .OnDelete(DeleteBehavior.Restrict);







        // ==========================================
        // Journal Entry
        // ==========================================

        modelBuilder.Entity<JournalEntry>()
            .HasIndex(x => x.VoucherNo)
            .IsUnique();



        modelBuilder.Entity<JournalEntry>()
            .HasMany(x => x.Details)
            .WithOne(x => x.JournalEntry)
            .HasForeignKey(x => x.JournalEntryId)
            .OnDelete(DeleteBehavior.Cascade);




        modelBuilder.Entity<JournalEntryDetail>()
            .HasOne(x => x.Ledger)
            .WithMany()
            .HasForeignKey(x => x.LedgerId)
            .OnDelete(DeleteBehavior.Restrict);







        // ==========================================
        // Unique Index
        // ==========================================

        modelBuilder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();


        modelBuilder.Entity<Permission>()
            .HasIndex(x => x.Name)
            .IsUnique();

    }

}