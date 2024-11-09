using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;


namespace Bulky.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository //Dziedziczy po klasie Repository<Category>: Oznacza to, że klasa CategoryRepository przejmuje funkcjonalność (metody i właściwości) z klasy Repository<T> (gdzie T w tym przypadku to Category).Implementuje interfejs ICategoryRepository: Oznacza to, że klasa CategoryRepository musi implementować wszystkie metody zdefiniowane w interfejsie ICategoryRepository.
	{
		private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
			_db = db;
        }


      

		public void Update(Category obj)
		{
			_db.Categories.Update(obj);
		}
	}
}
