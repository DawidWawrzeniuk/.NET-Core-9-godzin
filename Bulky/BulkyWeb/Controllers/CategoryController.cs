using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;      //(_db to nasza tabela, taki obiekt)to klasa służąca do interakcji z bazą danych, zarządzająca połączeniem oraz operacjami na danych.
		public CategoryController(ApplicationDbContext db)      //to klasa kontrolera, która obsługuje logikę aplikacji związaną z kategoriami, zarządza żądaniami od użytkowników oraz współpracuje z modelami i widokami.
		{
			_db = db;   //przypisanie do zmiennej lokalnej
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.ToList();           //pobranie danych z tabeli Category (wierszy)
			return View(objCategoryList);                                       //przekazanie danych do widoku
		}

		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Create(Category obj)   //kiedy uzywamy post w formularzu to otrzymujemy obiekt klasy Category (na samej gorze w create.cshtml tak zadeklarowaliśmy) o właściwościach Name i DisplayOrder
		{
			if (obj.Name == obj.DisplayOrder.ToString())  //nazwa kategorii i display order nie moga byc takie same
			{
				ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name."); //dodajemy nową wiadomośc error aby wyswietlala sie pod polem Name w formularzu
			}
			if (obj.Name !=null && obj.Name.ToLower() == "test")  
			{
				ModelState.AddModelError("", "Test is an incalid value."); //dodajemy nową wiadomośc error aby wyswietlala sie tylko w summary error
			}
			if (ModelState.IsValid)     //sprawdza wszystkie validacje w modelu (np. maksymalna dlugosc znaków czy zakres liczb ktore mozna wpisac
			{
				_db.Categories.Add(obj);    //dodanie nowej kategorii do tabeli _db
				_db.SaveChanges();          //zapisanie zmian
				return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Category
			}
			return View();
		}
<<<<<<< HEAD









		public IActionResult Edit(int? id)			//tą zmienną otrzymujemy po przyciśnięciu przycisku edit na którymś z kategorii (mowi ktorą kategorie chcemy edytować)
		{
            if ( id==null || id ==0)
            {
				return NotFound(); //wywala chyba error na stronie
            }
			Category? categoryFromDb = _db.Categories.Find(id);      //tworzy obiekt ktory na podstawie id wyszukuje elementy
																	//

			//Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);      //tworzy obiekt ktory na podstawie id wyszukuje elementy (przyrownuje uzyskane id z obiektami w tabeli)
			//Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();      //tworzy obiekt ktory na podstawie id wyszukuje elementy (przed tym filtruje elementy)
			if (categoryFromDb == null)
			{
				return NotFound(); //wywala chyba error na stronie
			}
			return View(categoryFromDb);		//przekazanie danych do widoku 			
		}


		[HttpPost]
		public IActionResult Edit(Category obj)   //kiedy uzywamy post w formularzu to otrzymujemy obiekt klasy Category (na samej gorze w create.cshtml tak zadeklarowaliśmy) o właściwościach Name i DisplayOrder
		{
			if (obj.Name == obj.DisplayOrder.ToString())  //nazwa kategorii i display order nie moga byc takie same
			{
				ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name."); //dodajemy nową wiadomośc error aby wyswietlala sie pod polem Name w formularzu
			}
			if (obj.Name != null && obj.Name.ToLower() == "test")
			{
				ModelState.AddModelError("", "Test is an incalid value."); //dodajemy nową wiadomośc error aby wyswietlala sie tylko w summary error
			}
			if (ModelState.IsValid)     //sprawdza wszystkie validacje w modelu (np. maksymalna dlugosc znaków czy zakres liczb ktore mozna wpisac
			{
				_db.Categories.Add(obj);    //dodanie nowej kategorii do tabeli _db
				_db.SaveChanges();          //zapisanie zmian
				return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Category
			}
			return View();
		}
=======
>>>>>>> 852cbefe7256577b8881ae109015e4c1593d4a69
	}
}
