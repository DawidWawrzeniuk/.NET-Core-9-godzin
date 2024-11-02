using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
	public class Category
	{
        [Key]
        public int CategoryId { get; set; }        //to klucz głowny naszej tabeli     //jesli nazwa zawiera"Id" to .net bedzie wiedzial ze to jest klucz glowny z automatu wiec [Key] nie jest wymagane w tym przypadku       //kazda wlasciwosc to oddzielna kolumna w bazie danych
        [Required]      //dana jest wymagana (nie moze byyc null)
        public string Name { get; set; }
        public int DisplayOrder { get; set; }        //określa ktory category ma byc wyswietlony pierwszy na stronie
    }
}
