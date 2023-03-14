using DAL.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CSContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString);
});

//builder.Services.AddScoped<IEFCoinRepository, EFCoinsRepository>();
//builder.Services.AddScoped<IEFMiddleRepository, EFMiddleRepository>();
//builder.Services.AddScoped<IEFWalletsRepository, EFWalletsRepository>();
//builder.Services.AddScoped<IEFUsersRepository, EFUsersRepository>();
//builder.Services.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

//builder.Services.AddScoped<ICoinManager, CoinManager>();
//builder.Services.AddScoped<IMiddleManager, MiddleManager>();
//builder.Services.AddScoped<IUserManager, UserManager>();
//builder.Services.AddScoped<IWalletManager, WalletManager>();
//builder.Services.AddScoped<IDataManager, DataManager>();
//builder.Services.AddScoped<MapperService>();
//builder.Services.AddScoped<WalletValidation>();
//builder.Services.AddScoped<CoinValidation>();
//builder.Services.AddScoped<UserValidation>();
//builder.Services.AddScoped<MiddleValidation>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();