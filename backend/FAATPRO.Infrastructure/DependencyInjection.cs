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
using FAATPRO.Application.Features.FinancialYears.Interfaces;
using FAATPRO.Application.Features.Currencies.Interfaces;
using FAATPRO.Application.Features.Cities.Interfaces;
using FAATPRO.Application.Features.AccountHeads.Interfaces;
using FAATPRO.Application.Features.AccountGroups.Interfaces;
using FAATPRO.Application.Features.Dashboard.Interfaces;
using FAATPRO.Application.Features.Ledgers.Interfaces;


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
using FAATPRO.Infrastructure.Services.Customer;
using FAATPRO.Infrastructure.Services.Dashboard;
using FAATPRO.Infrastructure.Services.Ledger;


using FAATPRO.Infrastructure.Authorization;



namespace FAATPRO.Infrastructure;


public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {


        // ==============================
        // DATABASE
        // ==============================

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString(
                    "DefaultConnection"));
        });





        // ==============================
        // JWT SETTINGS
        // ==============================

        services.Configure<JwtSettings>(
            configuration.GetSection("JwtSettings"));



        var jwtSettings =
            configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>();



        if (jwtSettings == null)
        {
            throw new Exception(
                "JwtSettings configuration missing");
        }






        // ==============================
        // AUTH SERVICES
        // ==============================

        services.AddScoped<
            IJwtTokenGenerator,
            JwtTokenGenerator>();


        services.AddScoped<
            IAuthService,
            AuthService>();






        // ==============================
        // USER MODULE
        // ==============================

        services.AddScoped<
            IUserService,
            UserService>();






        // ==============================
        // ROLE MODULE
        // ==============================

        services.AddScoped<
            IRoleService,
            RoleService>();






        // ==============================
        // PERMISSION MODULE
        // ==============================

        services.AddScoped<
            IPermissionService,
            PermissionService>();






        // ==============================
        // ROLE PERMISSION MODULE
        // ==============================

        services.AddScoped<
            IRolePermissionService,
            RolePermissionService>();






        // ==============================
        // COMPANY MODULE
        // ==============================

        services.AddScoped<
            ICompanyService,
            CompanyService>();






        // ==============================
        // BRANCH MODULE
        // ==============================

        services.AddScoped<
            IBranchService,
            BranchService>();






        // ==============================
        // FINANCIAL YEAR MODULE
        // ==============================

        services.AddScoped<
            IFinancialYearService,
            FinancialYearService>();






        // ==============================
        // CURRENCY MODULE
        // ==============================

        services.AddScoped<
            ICurrencyService,
            CurrencyService>();






        // ==============================
        // CITY MODULE
        // ==============================

        services.AddScoped<
            ICityService,
            CityService>();






        // ==============================
        // ACCOUNT HEAD MODULE
        // ==============================

        services.AddScoped<
            IAccountHeadService,
            AccountHeadService>();






        // ==============================
        // ACCOUNT GROUP MODULE
        // ==============================

        services.AddScoped<
            IAccountGroupService,
            AccountGroupService>();






        // ==============================
        // CUSTOMER MODULE
        // ==============================

        services.AddScoped<
            ICustomerService,
            CustomerService>();






        // ==============================
        // DASHBOARD MODULE
        // ==============================

        services.AddScoped<
            IDashboardService,
            DashboardService>();






        // ==============================
        // LEDGER MODULE
        // ==============================

        services.AddScoped<
            ILedgerService,
            LedgerService>();








        // ==============================
        // JWT AUTHENTICATION
        // ==============================

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








        // ==============================
        // AUTHORIZATION + RBAC
        // ==============================

        services.AddAuthorization();



        services.AddSingleton<
            IAuthorizationPolicyProvider,
            PermissionPolicyProvider>();



        services.AddScoped<
            IAuthorizationHandler,
            PermissionAuthorizationHandler>();






        return services;

    }

}