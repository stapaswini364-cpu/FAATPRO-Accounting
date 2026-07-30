using FAATPRO.Application;
using FAATPRO.Infrastructure;
using FAATPRO.Infrastructure.Persistence;
using FAATPRO.Infrastructure.Persistence.Seed;


var builder = WebApplication.CreateBuilder(args);


Console.WriteLine("STEP 1 - Builder Created");


// ==============================
// CONTROLLERS
// ==============================

builder.Services.AddControllers();



// ==============================
// SWAGGER
// ==============================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



Console.WriteLine("STEP 2 - Controllers & Swagger Added");



// ==============================
// CORS
// ==============================

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:5173"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});



Console.WriteLine("STEP 3 - CORS Added");



// ==============================
// APPLICATION LAYER
// ==============================

builder.Services.AddApplication();


Console.WriteLine("STEP 4 - Application Added");



// ==============================
// INFRASTRUCTURE LAYER
// ==============================

builder.Services.AddInfrastructure(
    builder.Configuration
);


Console.WriteLine("STEP 5 - Infrastructure Added");



var app = builder.Build();



Console.WriteLine("STEP 6 - App Built");



// ==============================
// SWAGGER
// ==============================

app.UseSwagger();

app.UseSwaggerUI();



// ==============================
// CORS
// ==============================

app.UseCors(
    "AllowFrontend"
);



// ==============================
// AUTHENTICATION
// ==============================

app.UseAuthentication();



// ==============================
// AUTHORIZATION
// ==============================

app.UseAuthorization();



// ==============================
// CONTROLLERS
// ==============================

app.MapControllers();




// ==============================
// ROOT TEST API
// ==============================

app.MapGet(
    "/",
    () =>
    {
        return Results.Ok(
            "FAATPRO Accounting API Running Successfully"
        );
    });




// ==============================
// DATABASE SEED
// ==============================

using (var scope = app.Services.CreateScope())
{
    var db =
        scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();


    await DatabaseSeeder.SeedAsync(db);
}



Console.WriteLine("STEP 7 - Before Run");



app.Run();