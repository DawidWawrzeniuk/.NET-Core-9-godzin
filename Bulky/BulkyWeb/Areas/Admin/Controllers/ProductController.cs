using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bulky.Models.ViewModels;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")] //danie znać dla kontrolera,że jest w obszarze ktorym zarządza admin
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;      //(_db to nasza tabela, taki obiekt)to klasa służąca do interakcji z bazą danych, zarządzająca połączeniem oraz operacjami na danych.
        public ProductController(IUnitOfWork unitOfWork)      //to klasa kontrolera, która obsługuje logikę aplikacji związaną z kategoriami, zarządza żądaniami od użytkowników oraz współpracuje z modelami i widokami.
        {
            _unitOfWork = unitOfWork;   //przypisanie do zmiennej lokalnej
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();           //pobranie danych z tabeli Product (wierszy)
            return View(objProductList);                                       //przekazanie danych do widoku
        }

        public IActionResult Create()
        {
			IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category                 //ten kod pobiera wszystkie kategorie z repozytorium (_unitOfWork.Category.GetAll()), a następnie tworzy z nich listę elementów SelectListItem, którą można wykorzystać w formularzu HTML w aplikacji ASP.NET MVC lub Razor Pages, w celu stworzenia listy rozwijanej (<select>). Dla każdej kategorii Text to nazwa kategorii, a Value to jej unikalny identyfikator.
				.GetAll().Select(u => new SelectListItem
				{
					Text = u.Name,
					Value = u.Id.ToString()
				});

            //ViewBag.CategoryList = CategoryList;        //przypisanie pozyskanych danych z tabeli Category do plecaka 
            //ViewData["CategoryList"] = CategoryList;      //przypisanie pozyskanych danych z tabeli Category do viewdata
            ProductVM productVM = new()
            {
                CategoryList = CategoryList,
				Product = new Product()
			};
			

			return View(productVM);
        }


        [HttpPost]
        public IActionResult Create(Product obj)   //kiedy uzywamy post w formularzu to otrzymujemy obiekt klasy Product (na samej gorze w create.cshtml tak zadeklarowaliśmy) o właściwościach Name i DisplayOrder
        {
            
            if (ModelState.IsValid)     //sprawdza wszystkie validacje w modelu (np. maksymalna dlugosc znaków czy zakres liczb ktore mozna wpisac
            {
                _unitOfWork.Product.Add(obj);    //dodanie nowej kategorii do tabeli _db
                _unitOfWork.Save();          //zapisanie zmian
                TempData["succes"] = "Product created succesfully";                    //kiedy uda sie zachować zmiany przypisujemy do zmiennej temp data wiadomosc ktora sie pokaze po zarenderowaniu następnej strony (to bedzie view index)
                return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Product
            }
            return View();
        }




        public IActionResult Edit(int? id)          //tą zmienną otrzymujemy po przyciśnięciu przycisku edit na którymś z kategorii (mowi ktorą kategorie chcemy edytować)
        {
            if (id == null || id == 0)
            {
                return NotFound(); //wywala chyba error na stronie
            }
            Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);      //tworzy obiekt ktory na podstawie id wyszukuje elementy
                                                                                       //

            //Product? ProductFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);      //tworzy obiekt ktory na podstawie id wyszukuje elementy (przyrownuje uzyskane id z obiektami w tabeli)
            //Product? ProductFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();      //tworzy obiekt ktory na podstawie id wyszukuje elementy (przed tym filtruje elementy)
            if (ProductFromDb == null)
            {
                return NotFound(); //wywala chyba error na stronie
            }
            return View(ProductFromDb);        //przekazanie danych do widoku 			
        }


        [HttpPost]
        public IActionResult Edit(Product obj)   //kiedy uzywamy post w formularzu to otrzymujemy obiekt klasy Product (na samej gorze w create.cshtml tak zadeklarowaliśmy) o właściwościach Name i DisplayOrder
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
                _unitOfWork.Product.Update(obj);    //zaaktualizowanie kategorii do tabeli _db (nawet jak tworzymy nową to to działa)
                _unitOfWork.Save();          //zapisanie zmian
                TempData["succes"] = "Product updated succesfully";                    //kiedy uda sie zachować zmiany przypisujemy do zmiennej temp data wiadomosc ktora sie pokaze po zarenderowaniu następnej strony (to bedzie view index)
                return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Product
            }
            return View();
        }









        public IActionResult Delete(int? id)          //tą zmienną otrzymujemy po przyciśnięciu przycisku edit na którymś z kategorii (mowi ktorą kategorie chcemy edytować)
        {
            if (id == null || id == 0)
            {
                return NotFound(); //wywala chyba error na stronie
            }
            Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);      //tworzy obiekt ktory na podstawie id wyszukuje elementy

            if (ProductFromDb == null)
            {
                return NotFound(); //wywala chyba error na stronie
            }
            return View(ProductFromDb);        //przekazanie danych do widoku 			
        }


        [HttpPost, ActionName("Delete")]            //ustawienie nazwy dla tej akcji jako Delete mimo że ma inną nazwę 
        public IActionResult DeletePOST(int? id)   //kiedy uzywamy post w formularzu to otrzymujemy obiekt klasy Product (na samej gorze w create.cshtml tak zadeklarowaliśmy) o właściwościach Name i DisplayOrder
        {


            Product obj = _unitOfWork.Product.Get(u => u.Id == id); //znajduje kategorie na podstawie id
            if (obj == null)
            {
                return NotFound(); //wywala chyba error na stronie
            }

            _unitOfWork.Product.Remove(obj);     //usuwa kategorie o danym id
            _unitOfWork.Save();          //zapisanie zmian
            TempData["succes"] = "Product deleted succesfully";                    //kiedy uda sie zachować zmiany przypisujemy do zmiennej temp data wiadomosc ktora sie pokaze po zarenderowaniu następnej strony (to bedzie view index)
            return RedirectToAction("Index");       //przekierowanie do akcji Index w kontrolerze Product
        }
    }
}
