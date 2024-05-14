using Blog.Application.AutoMapper;
using Blog.Application.Services.AppUserService;
using Blog.Application.Services.KonuService;
using Blog.Application.Services.MakaleService;
using Blog.Domain.Entities;
using Blog.Domain.Repositories.Abstract;
using Blog.Infrastructure.Data;
using Blog.Infrastructure.Repositories.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(x => x.UseOracle());

builder.Services.AddIdentity<AppUser, AppRole>(x => x.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<BlogContext>()
    .AddRoles<AppRole>();



//AutoMapper Settings
builder.Services.AddAutoMapper(x => x.AddProfile(typeof(BlogMapper)));


//IoC
builder.Services.AddTransient<IAppUserService, AppUserService>();

builder.Services.AddTransient<IMakaleRepository, MakaleRepository>();
builder.Services.AddTransient<IMakaleService, MakaleService>();

builder.Services.AddTransient<IKonuRepository, KonuRepository>();
builder.Services.AddTransient<IKonuService, KonuService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
