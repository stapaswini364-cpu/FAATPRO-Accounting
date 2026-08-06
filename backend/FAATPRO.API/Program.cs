using FAATPRO.Application;
using FAATPRO.Infrastructure;

using FAATPRO.Infrastructure.Persistence;
using FAATPRO.Infrastructure.Persistence.Seed;

using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

IdentityModelEventSource.ShowPII = true;

Console.WriteLine("STEP 1 - Builder Created");

// =====================================
// CONTROLLERS
// =====================================

builder.Services.AddControllers();

// =====================================
// SWAGGER
// =====================================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter JWT token only. Do NOT type 'Bearer '."
        });

    options.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
});

Console.WriteLine("STEP 2 - Swagger Added");

// =====================================
// CORS
// =====================================

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

Console.WriteLine("STEP 3 - CORS Added");

// =====================================
// APPLICATION
// =====================================

builder.Services.AddApplication();

Console.WriteLine("STEP 4 - Application Added");

// =====================================
// INFRASTRUCTURE
// =====================================

builder.Services.AddInfrastructure(builder.Configuration);

Console.WriteLine("STEP 5 - Infrastructure Added");

var app = builder.Build();

Console.WriteLine("STEP 6 - App Built");

// =====================================
// SWAGGER
// =====================================

app.UseSwagger();
app.UseSwaggerUI();

// =====================================
// MIDDLEWARE
// =====================================

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// =====================================
// ROOT API
// =====================================

app.MapGet("/", () =>
{
    return Results.Ok("FAATPRO Accounting API Running Successfully");
});

// =====================================
// DATABASE SEED
// =====================================

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await DatabaseSeeder.SeedAsync(db);
}

Console.WriteLine("STEP 7 - API Running");

app.Run();