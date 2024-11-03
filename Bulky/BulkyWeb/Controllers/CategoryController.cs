using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)		//tu określamy na jakiej bazie danych chcemy pracowac 
        {
			_db = db;	//przypisanie do zmiennej lokalnej
        }
        public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.ToList();			//pobranie danych z tabeli Category (wierszy)
			return View(objCategoryList);										//przekazanie danych do widoku
		}
	}
}
