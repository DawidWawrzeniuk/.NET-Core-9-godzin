using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class           //IEnumerable<T> – Interfejs, który oznacza kolekcję elementów typu T. Jest to rodzaj kolekcji, która pozwala na sekwencyjne przechodzenie przez elementy (iterację).GetAll() – Zwykle ta metoda jest używana do pobierania wszystkich dostępnych danych z repozytorium (np.wszystkie obiekty Person w bazie danych).
	{
		//T - Category
		IEnumerable<T> GetAll();
		T Get(Expression<Func<T, bool>> filter);        //Metoda Get zwraca pojedynczy obiekt typu T, który spełnia określony warunek filtrujący. Parametr filter to wyrażenie (ang. lambda expression) określające kryterium filtrowania.T – Zwracany typ.To obiekt typu T (np.Person, Product), który spełnia warunki podane w filtrze.Expression<Func<T, bool>> filter – To wyrażenie lambda, które służy do definiowania warunku, na podstawie którego filtrujemy dane.Wyrażenie typu Func<T, bool> przyjmuje obiekt typu T jako argument i zwraca wartość bool (prawda/fałsz), wskazując, czy obiekt spełnia określony warunek.
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity); //reprezentuje metodę, która służy do usuwania zbioru obiektów (lub rekordów) z repozytorium lub bazy danych.		//IEnumerable<T> jest interfejsem, który reprezentuje kolekcję, po której można iterować. Oznacza to, że metoda przyjmuje wiele elementów (obiektów typu T), które mają zostać usunięte.
	}
}
