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


// LEDGER POSTING
using FAATPRO.Application.Features.LedgerPosting.Interfaces;



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


// LEDGER POSTING
using FAATPRO.Infrastructure.Services.LedgerPosting;


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
        // SERVICES
        // ==========================


        services.AddScoped<
            IJwtTokenGenerator,
            JwtTokenGenerator>();


        services.AddScoped<
            IAuthService,
            AuthService>();



        services.AddScoped<
            IUserService,
            UserService>();


        services.AddScoped<
            IRoleService,
            RoleService>();


        services.AddScoped<
            IPermissionService,
            PermissionService>();


        services.AddScoped<
            IRolePermissionService,
            RolePermissionService>();



        services.AddScoped<
            ICompanyService,
            CompanyService>();


        services.AddScoped<
            IBranchService,
            BranchService>();


        services.AddScoped<
            IFinancialYearService,
            FinancialYearService>();


        services.AddScoped<
            ICurrencyService,
            CurrencyService>();


        services.AddScoped<
            ICityService,
            CityService>();



        services.AddScoped<
            IAccountHeadService,
            AccountHeadService>();


        services.AddScoped<
            IAccountGroupService,
            AccountGroupService>();


        services.AddScoped<
            IAccountSubGroupService,
            AccountSubGroupService>();



        services.AddScoped<
            ICustomerService,
            CustomerService>();


        services.AddScoped<
            IDashboardService,
            DashboardService>();


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
        // LEDGER POSTING
        // ==========================

        services.AddScoped<
            ILedgerPostingService,
            LedgerPostingService>();






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