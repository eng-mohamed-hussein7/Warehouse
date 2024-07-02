using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Repositories.ProductRepositories;
using BusinessLogicLayer.Services.ProductServices;
using DataAccessLayer.Repositories.CategoryService;
using BusinessLogicLayer.Services.CategoryServices;
using DataAccessLayer.Repositories.PurchaseInvoiceRepositories;
using BusinessLogicLayer.Services.PurchaseInvoiceServices;
using DataAccessLayer.Repositories.DismissalNoticeRepositories;
using BusinessLogicLayer.Services.DismissalNoticeServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Entity Framework and Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// Configure Dependency Injection for Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPurchaseInvoiceRepository, PurchaseInvoiceRepository>();
builder.Services.AddScoped<IDismissalNoticeRepository, DismissalNoticeRepository>();

// Configure Dependency Injection for Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPurchaseInvoiceService, PurchaseInvoiceService>();
builder.Services.AddScoped<IDismissalNoticeService, DismissalNoticeService>();

// Add AutoMapper configuration
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();