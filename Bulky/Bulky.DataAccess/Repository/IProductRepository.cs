using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
	public interface IProductRepository : IRepository<Product>    //IRepository<Category>: Zapewnia metody ogólnego repozytorium dla obiektów Category.
	{
		void Update(Product category);
	}
}
