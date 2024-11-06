using BulkyWebRazor_Temp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();               //dodanie razor pages zamiast MVC


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));          //dodanie Entity framework do projektu (w klasie ApplicationDbContext jest implementacja)



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


//w razor pages cokolwiek jest w folderze pages to bêdzie routem 
//Razor Pages to bardziej zintegrowane podejœcie, które jest szczególnie przydatne w przypadku
//prostszych aplikacji lub stron, które nie wymagaj¹ zaawansowanego zarz¹dzania wieloma 
//kontrolerami.W Razor Pages ka¿da strona ma swoj¹ w³asn¹ stronê Razor (widok), która zawiera 
//tak¿e logikê dla tej strony (w pliku kodu, np. Category.cshtml.cs).W Razor Pages nie ma 
//potrzeby tworzenia osobnych kontrolerów. Logika obs³ugi strony jest zintegrowana bezpoœrednio
//w plikach Razor, dziêki czemu struktura jest prostsza i bardziej lokalna.

//Ka¿da strona Razor jest traktowana jak pojedynczy zasób, a ¿¹danie HTTP jest obs³ugiwane przez 
//stronê (nie kontroler).Ka¿da strona Razor (np. Index.cshtml) ma powi¹zany plik kodu 
//(np. Index.cshtml.cs), który zawiera logikê dzia³ania tej strony (np. przetwarzanie formularzy, pobieranie danych z bazy).
//Obs³uga ¿¹dañ w Razor Pages jest bardziej bezpoœrednia i zintegrowana z widokiem.

//W Razor Pages routing jest o wiele prostszy, poniewa¿ ka¿da strona Razor ma swoj¹ w³asn¹ œcie¿kê
//URL opart¹ na nazwie pliku. Na przyk³ad, strona Category/Index.cshtml bêdzie dostêpna pod
//URL-em /Category/Index, a strona Category/Create.cshtml pod URL-em /Category/Create.

//Razor Pages:
//Jest bardziej zwarty i prostszy do zaimplementowania, szczególnie w aplikacjach z mniejsz¹ iloœci¹ 
//stron i prostsz¹ logik¹.Idealne do aplikacji, które korzystaj¹ z jednej strony (single-page applications)
//lub maj¹ bardziej bezpoœredni i zintegrowany interfejs.