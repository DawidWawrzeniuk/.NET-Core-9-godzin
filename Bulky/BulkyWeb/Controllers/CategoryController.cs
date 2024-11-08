using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.DataAccess.Data;

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
				TempData["succes"] = "Category created succesfully";					//kiedy uda sie zachować zmiany przypisujemy do zmiennej temp data wiadomosc ktora sie pokaze po zarenderowaniu następnej strony (to bedzie view index)
				return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Category
			}
			return View();
		}










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
			//if (obj.Name == obj.DisplayOrder.ToString())  //nazwa kategorii i display order nie moga byc takie same
			//{
			//	ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name."); //dodajemy nową wiadomośc error aby wyswietlala sie pod polem Name w formularzu
			//}
			//if (obj.Name != null && obj.Name.ToLower() == "test")
			//{
			//	ModelState.AddModelError("", "Test is an incalid value."); //dodajemy nową wiadomośc error aby wyswietlala sie tylko w summary error
			//}
			if (ModelState.IsValid)     //sprawdza wszystkie validacje w modelu (np. maksymalna dlugosc znaków czy zakres liczb ktore mozna wpisac
			{
				_db.Categories.Update(obj);    //zaaktualizowanie kategorii do tabeli _db (nawet jak tworzymy nową to to działa)
				_db.SaveChanges();          //zapisanie zmian
				TempData["succes"] = "Category updated succesfully";                    //kiedy uda sie zachować zmiany przypisujemy do zmiennej temp data wiadomosc ktora sie pokaze po zarenderowaniu następnej strony (to bedzie view index)
				return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Category
			}
			return View();
		}









		public IActionResult Delete(int? id)          //tą zmienną otrzymujemy po przyciśnięciu przycisku edit na którymś z kategorii (mowi ktorą kategorie chcemy edytować)
		{
			if (id == null || id == 0)
			{
				return NotFound(); //wywala chyba error na stronie
			}
			Category? categoryFromDb = _db.Categories.Find(id);      //tworzy obiekt ktory na podstawie id wyszukuje elementy
																	 		
			if (categoryFromDb == null)
			{
				return NotFound(); //wywala chyba error na stronie
			}
			return View(categoryFromDb);        //przekazanie danych do widoku 			
		}


		[HttpPost, ActionName("Delete")]			//ustawienie nazwy dla tej akcji jako Delete mimo że ma inną nazwę 
		public IActionResult DeletePOST(int? id)   //kiedy uzywamy post w formularzu to otrzymujemy obiekt klasy Category (na samej gorze w create.cshtml tak zadeklarowaliśmy) o właściwościach Name i DisplayOrder
		{
			

			Category obj = _db.Categories.Find(id); //znajduje kategorie na podstawie id
			if (obj == null)
			{
				return NotFound(); //wywala chyba error na stronie
			}

			_db.Categories.Remove(obj);     //usuwa kategorie o danym id
			_db.SaveChanges();          //zapisanie zmian
			TempData["succes"] = "Category deleted succesfully";                    //kiedy uda sie zachować zmiany przypisujemy do zmiennej temp data wiadomosc ktora sie pokaze po zarenderowaniu następnej strony (to bedzie view index)
			return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Category
		}
	}
}
