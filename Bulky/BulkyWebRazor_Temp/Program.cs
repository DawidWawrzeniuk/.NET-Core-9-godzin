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


//w razor pages cokolwiek jest w folderze pages to b�dzie routem 
//Razor Pages to bardziej zintegrowane podej�cie, kt�re jest szczeg�lnie przydatne w przypadku
//prostszych aplikacji lub stron, kt�re nie wymagaj� zaawansowanego zarz�dzania wieloma 
//kontrolerami.W Razor Pages ka�da strona ma swoj� w�asn� stron� Razor (widok), kt�ra zawiera 
//tak�e logik� dla tej strony (w pliku kodu, np. Category.cshtml.cs).W Razor Pages nie ma 
//potrzeby tworzenia osobnych kontroler�w. Logika obs�ugi strony jest zintegrowana bezpo�rednio
//w plikach Razor, dzi�ki czemu struktura jest prostsza i bardziej lokalna.

//Ka�da strona Razor jest traktowana jak pojedynczy zas�b, a ��danie HTTP jest obs�ugiwane przez 
//stron� (nie kontroler).Ka�da strona Razor (np. Index.cshtml) ma powi�zany plik kodu 
//(np. Index.cshtml.cs), kt�ry zawiera logik� dzia�ania tej strony (np. przetwarzanie formularzy, pobieranie danych z bazy).
//Obs�uga ��da� w Razor Pages jest bardziej bezpo�rednia i zintegrowana z widokiem.

//W Razor Pages routing jest o wiele prostszy, poniewa� ka�da strona Razor ma swoj� w�asn� �cie�k�
//URL opart� na nazwie pliku. Na przyk�ad, strona Category/Index.cshtml b�dzie dost�pna pod
//URL-em /Category/Index, a strona Category/Create.cshtml pod URL-em /Category/Create.

//Razor Pages:
//Jest bardziej zwarty i prostszy do zaimplementowania, szczeg�lnie w aplikacjach z mniejsz� ilo�ci� 
//stron i prostsz� logik�.Idealne do aplikacji, kt�re korzystaj� z jednej strony (single-page applications)
//lub maj� bardziej bezpo�redni i zintegrowany interfejs.