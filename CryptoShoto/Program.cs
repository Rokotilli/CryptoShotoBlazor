using DAL.Contracts;
using DAL.Repositories;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using BLL.DTO;
using BLL.Contracts;
using BLL.Managers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<CSContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("MSSQLConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IFollowerRepository, FollowerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICoinManager, CoinManager>();
builder.Services.AddScoped<INewsManager, NewsManager>();
builder.Services.AddScoped<IPostManager, PostManager>();
builder.Services.AddScoped<IProfileManager, ProfileManager>();
builder.Services.AddScoped<IWalletManager, WalletManager>();

builder.Services.AddScoped<DTOService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHsts();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();