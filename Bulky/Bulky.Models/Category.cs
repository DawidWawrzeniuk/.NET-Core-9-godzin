using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }        //to klucz głowny naszej tabeli     //jesli nazwa zawiera"Id" to .net bedzie wiedzial ze to jest klucz glowny z automatu wiec [Key] nie jest wymagane w tym przypadku       //kazda wlasciwosc to oddzielna kolumna w bazie danych
        [Required]      //dana jest wymagana (nie moze byyc null)
        [MaxLength(30)]                     //maksymalna długość ktora mozemy wpisac do formularza to 30 znaków
        [DisplayName("Category Name")] //wyswietla ten napis zamiast domyślnego Name jezeli korzystamy z asp-for w label 
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]                          //zakres danych ktore mogą być wpisane 
        public int DisplayOrder { get; set; }        //określa ktory category ma byc wyswietlony pierwszy na stronie
    }
}
