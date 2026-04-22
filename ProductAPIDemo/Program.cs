using Microsoft.EntityFrameworkCore;
using ProductAPIDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGISTER SERVICES ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// --- 2. CONFIGURE PIPELINE (Middleware) ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// --- 3. DATABASE AUTO-CREATE (The "Hack") ---
// We do this BEFORE the final app.Run()
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    // This creates the database and tables if they don't exist
    dbContext.Database.EnsureCreated();
}

// --- 4. START THE APP ---
app.Run();