using BLL.Contracts;
using BLL.Repositories;
using DAL.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddSwaggerGen();

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
//builder.Services.AddScoped<MapperService>();
//builder.Services.AddScoped<WalletValidation>();
//builder.Services.AddScoped<CoinValidation>();
//builder.Services.AddScoped<UserValidation>();
//builder.Services.AddScoped<MiddleValidation>();

var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseSwagger();

//    app.UseSwaggerUI(options =>
//    {
//        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//        options.RoutePrefix = string.Empty;
//    });

//    app.UseHsts();
//}

app.UseHttpsRedirection();

    app.UseRouting(); // ?????????? ??????? ?????????????

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.UseMvc(routes =>
//{
//    routes.MapRoute(
//        name: "default",
//        template: "{controller=Home}/{action=Index}/{id?}");
//});

app.Run();