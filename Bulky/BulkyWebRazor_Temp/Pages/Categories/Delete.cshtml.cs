using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
	[BindProperties]
	public class DeleteModel : PageModel
	{
		private readonly ApplicationDbContext _db;
		[BindProperty]                          //umo¿liwia dostêp obiektu Category do akcji OnPost aby przekazaæ kategorie któr¹ chcemy utworzyæ (przekazuje name i displayorder)
		public Category Category { get; set; }          //pojedynczy obiekt Category który bedziemy edytowaæ
		public DeleteModel(ApplicationDbContext db)
		{
			_db = db;
		}
		public void OnGet(int? id)      //przekazanie id do akcji 
		{
			if (id != null && id != 0)
			{
				Category = _db.Categories.Find(id);     //znajduje kategorie na podstawie przekazanego id w linku
			}
		}

		//przekazujemy do funkcji obiekt obj
		public IActionResult OnPost()   //wartosc zwracana bedzie IActionResult poniewa¿ chcemy zrobic redirect do strony index
		{

			Category obj = _db.Categories.Find(Category.Id); //znajduje kategorie na podstawie Id przekazanego w linku 
			if (obj == null)
			{
				return NotFound(); //wywala chyba error na stronie
			}

			_db.Categories.Remove(obj);     //usuwa kategorie o danym id
			_db.SaveChanges();          //zapisanie zmian
            TempData["success"] = "Category deleted successfully.";
            return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Category
		}
	}
}
