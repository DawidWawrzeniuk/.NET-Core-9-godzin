using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyWeb.DataAccess.Data;


namespace Bulky.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository //Dziedziczy po klasie Repository<Category>: Oznacza to, że klasa CategoryRepository przejmuje funkcjonalność (metody i właściwości) z klasy Repository<T> (gdzie T w tym przypadku to Category).Implementuje interfejs ICategoryRepository: Oznacza to, że klasa CategoryRepository musi implementować wszystkie metody zdefiniowane w interfejsie ICategoryRepository.
	{
		private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
			_db = db;
        }


      

		public void Update(Product obj)
		{
			_db.Products.Update(obj);
		}
	}
}
