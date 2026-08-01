using System.Text;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;


using FAATPRO.Application.Common.Interfaces;
using FAATPRO.Application.Common.Models;


using FAATPRO.Application.Features.Auth.Interfaces;
using FAATPRO.Application.Features.Roles.Interfaces;
using FAATPRO.Application.Features.Permissions.Interfaces;
using FAATPRO.Application.Features.Users.Interfaces;
using FAATPRO.Application.Features.RolePermissions.Interfaces;
using FAATPRO.Application.Features.Customers.Interfaces;

using FAATPRO.Application.Features.Companies.Interfaces;
using FAATPRO.Application.Features.Branches.Interfaces;
using FAATPRO.Application.Features.FinancialYear.Interfaces;
using FAATPRO.Application.Features.Currencies.Interfaces;
using FAATPRO.Application.Features.Cities.Interfaces;


using FAATPRO.Application.Features.AccountHeads.Interfaces;
using FAATPRO.Application.Features.AccountGroups.Interfaces;
using FAATPRO.Application.Features.AccountSubGroups.Interfaces;

using FAATPRO.Application.Features.Dashboard.Interfaces;
using FAATPRO.Application.Features.Ledgers.Interfaces;

// JOURNAL ENTRY
using FAATPRO.Application.Features.JournalEntries.Interfaces;



using FAATPRO.Infrastructure.Authentication;

using FAATPRO.Infrastructure.Persistence;


using FAATPRO.Infrastructure.Services;
using FAATPRO.Infrastructure.Services.RolePermissions;

using FAATPRO.Infrastructure.Services.Company;
using FAATPRO.Infrastructure.Services.Branch;
using FAATPRO.Infrastructure.Services.FinancialYear;
using FAATPRO.Infrastructure.Services.Currency;
using FAATPRO.Infrastructure.Services.City;


using FAATPRO.Infrastructure.Services.AccountHead;
using FAATPRO.Infrastructure.Services.AccountGroup;
using FAATPRO.Infrastructure.Services.AccountSubGroup;


using FAATPRO.Infrastructure.Services.Customer;
using FAATPRO.Infrastructure.Services.Dashboard;
using FAATPRO.Infrastructure.Services.Ledger;

// JOURNAL ENTRY
using FAATPRO.Infrastructure.Services.JournalEntry;


using FAATPRO.Infrastructure.Authorization;



namespace FAATPRO.Infrastructure;


public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {


        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString(
                    "DefaultConnection"));
        });



        services.Configure<JwtSettings>(
            configuration.GetSection("JwtSettings"));



        var jwtSettings =
            configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>();



        if(jwtSettings == null)
        {
            throw new Exception(
                "JwtSettings configuration missing");
        }



        // ==========================
        // AUTH
        // ==========================

        services.AddScoped<
            IJwtTokenGenerator,
            JwtTokenGenerator>();


        services.AddScoped<
            IAuthService,
            AuthService>();





        // ==========================
        // USER
        // ==========================

        services.AddScoped<
            IUserService,
            UserService>();





        // ==========================
        // ROLE
        // ==========================

        services.AddScoped<
            IRoleService,
            RoleService>();





        // ==========================
        // PERMISSION
        // ==========================

        services.AddScoped<
            IPermissionService,
            PermissionService>();





        // ==========================
        // ROLE PERMISSION
        // ==========================

        services.AddScoped<
            IRolePermissionService,
            RolePermissionService>();





        // ==========================
        // COMPANY
        // ==========================

        services.AddScoped<
            ICompanyService,
            CompanyService>();





        // ==========================
        // BRANCH
        // ==========================

        services.AddScoped<
            IBranchService,
            BranchService>();





        // ==========================
        // FINANCIAL YEAR
        // ==========================

        services.AddScoped<
            IFinancialYearService,
            FinancialYearService>();





        // ==========================
        // CURRENCY
        // ==========================

        services.AddScoped<
            ICurrencyService,
            CurrencyService>();





        // ==========================
        // CITY
        // ==========================

        services.AddScoped<
            ICityService,
            CityService>();





        // ==========================
        // ACCOUNT HEAD
        // ==========================

        services.AddScoped<
            IAccountHeadService,
            AccountHeadService>();





        // ==========================
        // ACCOUNT GROUP
        // ==========================

        services.AddScoped<
            IAccountGroupService,
            AccountGroupService>();





        // ==========================
        // ACCOUNT SUB GROUP
        // ==========================

        services.AddScoped<
            IAccountSubGroupService,
            AccountSubGroupService>();





        // ==========================
        // CUSTOMER
        // ==========================

        services.AddScoped<
            ICustomerService,
            CustomerService>();





        // ==========================
        // DASHBOARD
        // ==========================

        services.AddScoped<
            IDashboardService,
            DashboardService>();





        // ==========================
        // LEDGER
        // ==========================

        services.AddScoped<
            ILedgerService,
            LedgerService>();





        // ==========================
        // JOURNAL ENTRY
        // ==========================

        services.AddScoped<
            IJournalEntryService,
            JournalEntryService>();







        // ==========================
        // JWT AUTHENTICATION
        // ==========================

        services.AddAuthentication(
            JwtBearerDefaults.AuthenticationScheme)

        .AddJwtBearer(options =>
        {

            options.RequireHttpsMetadata = false;

            options.SaveToken = true;


            options.TokenValidationParameters =
                new TokenValidationParameters
                {

                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,


                    ValidIssuer =
                        jwtSettings.Issuer,


                    ValidAudience =
                        jwtSettings.Audience,


                    IssuerSigningKey =
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                jwtSettings.SecretKey))

                };

        });





        services.AddAuthorization();





        // ==========================
        // RBAC PERMISSION
        // ==========================

        services.AddSingleton<
            IAuthorizationPolicyProvider,
            PermissionPolicyProvider>();


        services.AddScoped<
            IAuthorizationHandler,
            PermissionAuthorizationHandler>();





        return services;

    }

}