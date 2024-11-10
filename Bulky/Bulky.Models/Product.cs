using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }        //to klucz głowny naszej tabeli     //jesli nazwa zawiera"Id" to .net bedzie wiedzial ze to jest klucz glowny z automatu wiec [Key] nie jest wymagane w tym przypadku       //kazda wlasciwosc to oddzielna kolumna w bazie danych
		[Required]      //dana jest wymagana (nie moze byyc null)
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		public string ISBN { get; set; }
		[Required]
		public string Author { get; set; }
		[Required]
		[Display(Name = "List Price")]
		[Range(1,1000)]
		public double ListPrice { get; set; }


		[Required]
		[Display(Name = "Price for 1-50")]
		[Range(1, 1000)]
		public double Price { get; set; }


		[Required]
		[Display(Name = "Price for 50+")]
		[Range(1, 1000)]
		public double Price50 { get; set; }


		[Required]
		[Display(Name = "Price for 100+")]
		[Range(1, 1000)]
		public double Price100 { get; set; }

		public int CategoryId { get; set; }     //klucz do tabeli Category
		[ForeignKey("CategoryId")]
        public Category Category { get; set; }  //nawigacja do tabeli category w ktorej jest kolumna o nazwie Id
        public string ImageUrl { get; set; }
    }
}
