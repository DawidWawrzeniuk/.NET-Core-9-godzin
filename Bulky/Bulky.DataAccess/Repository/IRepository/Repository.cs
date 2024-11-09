using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository.IRepository
{
	public  class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> dbSet;
		public Repository(ApplicationDbContext db)
		{
			_db = db;
			this.dbSet = _db.Set<T>();  //this.dbSet = _db.Set<T>();: Wywołanie metody Set<T>() kontekstu bazy danych, która zwraca obiekt DbSet<T> dla konkretnego typu T. Dzięki temu pole dbSet jest inicjowane i wskazuje na odpowiednią tabelę w bazie danych. Metoda Set<T>() zapewnia dostęp do operacji CRUD (Create, Read, Update, Delete) dla obiektów typu T.
										//Set<T>() to metoda w klasie DbContext w Entity Framework, która zwraca obiekt typu DbSet<T>, pozwalający na wykonywanie operacji CRUD dla obiektów typu T.
		}
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;                    //IQueryable<T> to sposób na tworzenie zapytań do bazy danych w Entity Framework, które są wykonywane później (kiedy je naprawdę potrzebujesz), a nie od razu.DbSet<T> to kolekcja obiektów, która reprezentuje tabelę w bazie danych(np.tabelę Person), ale jednocześnie jest typu IQueryable<T>.Oznacza to, że DbSet<T> pozwala na budowanie zapytań, które mogą być później przekształcone w zapytania SQL i wykonane w bazie danych.
			query = query.Where(filter);                    //zastosowanie filtra 
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			IQueryable<T> query = dbSet;
			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}
	}
}
