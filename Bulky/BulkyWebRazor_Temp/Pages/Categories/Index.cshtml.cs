using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()         //co sie dzieje gdy nacisniemy przycisk Categories na pasku nawigacji 
        {
            CategoryList = _db.Categories.ToList();     //pobranie wszystkich kategorii z tabeli Categories i przypisanie do obiektu CategoryList

		}
    }
}
