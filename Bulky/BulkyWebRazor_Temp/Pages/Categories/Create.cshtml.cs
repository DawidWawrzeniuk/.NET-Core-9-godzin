using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace BulkyWebRazor_Temp.Pages.Categories
{ 
    //je�eli mamy wiecej w�a�ciwo�ci w modelu to mo�emy doda� [BindProperties] aby wiecej niz jedna w�a�ciwo�� byla dostepna w akcji 
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]                          //umo�liwia dost�p obiektu Category do akcji OnPost aby przekaza� kategorie kt�r� chcemy utworzy� (przekazuje name i displayorder)
        public Category Category { get; set; }          //pojedynczy obiekt Category kt�ry bedziemy edytowa�
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

                                                    //przkazujemy do funkcji obiekt obj
        public IActionResult OnPost()   //wartosc zwracana bedzie IActionResult poniewa� chcemy zrobic redirect do strony index
        {
            _db.Categories.Add(Category);   //przekazujemy obiekt category 
            _db.SaveChanges();
            return RedirectToPage("Index");         //przekierowanie do index
        }


    }
}
