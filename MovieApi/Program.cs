using MovieApi.Extensions;
using MovieApi.Options;
using MovieApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // подключение вьюшек


builder.Services.AddWebOptimizer(options => // подключить scss
{
    options.CompileScssFiles();
});

// Подгрузка параметров из конфига
//builder.Services.Configure<MovieApiOptions>(options =>
//{
//    options.BaseUrl = builder.Configuration["MovieApiKey:BaseUrl"];
//    options.ApiKey = builder.Configuration["MovieApiKey:ApiKey"];
//});

builder.Services.AddHttpClient(); // для выполнения запросов
builder.Services.AddMemoryCache(); //Подгрузка кеша для киелта в браузере
builder.Services.AddMovieApi(options =>
{
    options.BaseUrl = builder.Configuration["MovieApiKey:BaseUrl"];
    options.ApiKey = builder.Configuration["MovieApiKey:ApiKey"];
});

//Console.WriteLine(builder.Configuration.GetSection("MovieApiKey").GetValue<string>("BaseUrl"));
//Console.WriteLine(builder.Configuration.GetSection("MovieApiKey").GetValue<string>("ApiKey"));
//Console.WriteLine(builder.Configuration["MovieApiKey:BaseUrl"]);
//Console.WriteLine(builder.Configuration["MovieApiKey:ApiKey"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebOptimizer();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{title?}");

app.Run();
