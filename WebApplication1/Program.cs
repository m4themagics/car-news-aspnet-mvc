using WebApplication1.Context;
using WebApplication1.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var services = builder.Services;
services.AddControllers()
    // .AddJsonOptions(options =>
    // {
    //     options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
    // })
    ;


using (CarNewsDBContext db = new CarNewsDBContext())
{
    bool isCreated = db.Database.EnsureCreated();
    if (isCreated) Console.WriteLine("DB was created");
    else Console.WriteLine("DB already exists");
}
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
services
    .AddEntityFrameworkNpgsql().AddDbContext<CarNewsDBContext>()
    .AddTransient<IArticleRepository, ArticleRepository>();
    // .AddDalInfrastructure(builder.Configuration)
    // .AddDalRepositories();


// builder.Services.AddEntityFrameworkSqlite().AddDbContext<CarNewsDBContext>();

// builder.Services.AddTransient<IArticleRepository, ArticleRepository>();

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

// app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    // endpoints.MapDefaultControllerRoute();
    endpoints.MapControllerRoute("goods-page", "", new
    {
        Controller = "Home",
        Action = "Index"
    });
});

app.Run();