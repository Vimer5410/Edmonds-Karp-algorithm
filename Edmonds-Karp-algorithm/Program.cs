using Edmonds_Karp_algorithm.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

int[,] capacity = {
    { 0, 16, 13,  0,  0,  0 }, // узел 0 
    { 0,  0, 10, 12,  0,  0 }, // узел 1
    { 0,  0,  0,  0, 14,  0 }, // узел 2
    { 0,  0,  9,  0,  0, 20 }, // узел 3
    { 0,  0,  0,  7,  0,  4 }, // узел 4
    { 0,  0,  0,  0,  0,  0 }  // узел 5 
};


var solver = new EdmondsKarpCore(capacity);

int result = solver.Calculate(0, 5);



app.Run();