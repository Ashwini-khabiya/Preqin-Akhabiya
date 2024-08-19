using Investor.Repository.Interface;
using Investor.Repository;
using Investor.Service.Interface;
using Investor.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InvestorContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("InvestorsDb")));
builder.Services.AddScoped<IInvestorService, InvestorService>();
builder.Services.AddScoped<IInvestorRepository, InvestorRepository>();
builder.Services.AddScoped<ICommitmentsRepository, CommitmentsRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowOrigin");
if (app.Environment.IsDevelopment()) {
    app.UseHsts();
}


    
app.UseRouting();
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<InvestorContext>();
    DbInitializer.Initialize(context);
}

    app.MapFallbackToFile("/index.html");

app.Run();
