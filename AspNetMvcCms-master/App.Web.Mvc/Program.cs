using App.Business.Abstract;
using App.Business.Concrete;
using App.Data.Abstract;
using App.Data.Concrete;
using App.Data.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(15);            
            options.LoginPath = new PathString("/Auth/Login");
            options.AccessDeniedPath = new PathString("/Error/ErrorCode401");
        });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IPostDal, EfPostDal>(); /// bunlarý ekledim bu ve altýnda ki
builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped<PostManager>();
builder.Services.AddScoped<IDepartmentDal, EfDepartmentDal>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IPageService, PageManager>();
builder.Services.AddScoped<IPageDal, EfPageDal>();
builder.Services.AddScoped<IPostCommentService, PostCommentManager>();
builder.Services.AddScoped<IPostCommentDal, EfPostCommentDal>();



builder.Services.AddScoped<AppDbContext>();
//builder.Services.AddDbContext<AppDbContext>(options =>
//		 options.UseSqlServer(builder.Configuration.GetConnectionString("DbConStr")));

AppDbContext _context = new AppDbContext();
_context.Database.EnsureCreated();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/ErrorCode404/");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
