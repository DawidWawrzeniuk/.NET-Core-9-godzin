var builder = WebApplication.CreateBuilder(args);	//stworzenie budowniczego

// Add services to the container.					//dodanie uslug do strony
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())				//czy jest w trybie development
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();								//dodanie static files ktore sa w wwwroot

app.UseRouting();									//dodanie po³¹czenie do pipeline

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
