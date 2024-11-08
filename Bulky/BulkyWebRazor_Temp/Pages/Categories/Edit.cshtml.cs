using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
	[BindProperties]
	public class EditModel : PageModel
	{
		private readonly ApplicationDbContext _db;
		[BindProperty]                          //umo�liwia dost�p obiektu Category do akcji OnPost aby przekaza� kategorie kt�r� chcemy utworzy� (przekazuje name i displayorder)
		public Category Category { get; set; }          //pojedynczy obiekt Category kt�ry bedziemy edytowa�
		public EditModel(ApplicationDbContext db)
		{
			_db = db;
		}
		public void OnGet(int? id)		//przekazanie id do akcji 
		{
			if (id != null && id != 0)
			{
				Category = _db.Categories.Find(id);		//znajduje kategorie na podstawie przekazanego id w linku
			}
		}

		//przkazujemy do funkcji obiekt obj
		public IActionResult OnPost()   //wartosc zwracana bedzie IActionResult poniewa� chcemy zrobic redirect do strony index
		{

			if (ModelState.IsValid)     //sprawdza wszystkie validacje w modelu (np. maksymalna dlugosc znak�w czy zakres liczb ktore mozna wpisac
			{
				_db.Categories.Update(Category);    //zaaktualizowanie kategorii do tabeli _db (nawet jak tworzymy now� to to dzia�a)
				_db.SaveChanges();          //zapisanie zmian
                TempData["success"] = "Category updated successfully.";                    //kiedy uda sie zachowa� zmiany przypisujemy do zmiennej temp data wiadomosc ktora sie pokaze po zarenderowaniu nast�pnej strony (to bedzie view index)
                return RedirectToPage("Index");       //przekierowanie do akcji Index w kontrolerze Category
			}
			return Page();
		}
	}
}
