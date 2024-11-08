using DI_Service_Lifetime.Models;
using DI_Service_Lifetime.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Text;
using static System.Net.WebRequestMethods;

namespace DI_Service_Lifetime.Controllers
{
	public class HomeController : Controller
	{
		private readonly IScopedGuidService _scoped1;               //Cykl �ycia obiekt�w w DI: Zale�no�ci mog� mie� r�ne cykle �ycia:

																		//Singleton: Tworzona raz i wsp�dzielona przez ca�y czas dzia�ania aplikacji.
																		//Scoped: Tworzona raz na ka�de ��danie HTTP.
																		//Transient: Tworzona za ka�dym razem, gdy jest potrzebna (np.ka�dorazowo przy wywo�aniu metody).
		private readonly IScopedGuidService _scoped2;

		private readonly ISingletonGuidService _singleton1;
		private readonly ISingletonGuidService _singleton2;

		private readonly ITransientGuidService _transient1;
		private readonly ITransientGuidService _transient2;


		
		public HomeController(IScopedGuidService scoped1,
			IScopedGuidService scoped2,
			ISingletonGuidService singleton1,
			ISingletonGuidService singleton2,
			ITransientGuidService transient1,
			ITransientGuidService transient2)
		{
			_singleton1 = singleton1;
			_singleton2 = singleton2;
			_transient1 = transient1;
			_transient2 = transient2;
			_scoped1=scoped1;
			_scoped2=scoped2;
		}

		public IActionResult Index()
		{
			StringBuilder messages = new StringBuilder();
			messages.Append($"Transient 1: { _transient1.GetGuid()}\n");
			messages.Append($"Transient 2: { _transient2.GetGuid()}\n\n");
			messages.Append($"Scoped 1: {_scoped1.GetGuid()}\n");
			messages.Append($"Scoped 2: {_scoped2.GetGuid()}\n\n");
			messages.Append($"Singleton 1: {_singleton1.GetGuid()}\n");
			messages.Append($"Singleton 2: {_singleton2.GetGuid()}\n\n");
			return Ok(messages.ToString());                                         //Ok() to metoda pomocnicza (helper method) w ASP.NET Core, kt�ra tworzy odpowied� HTTP o statusie 200 OK. Jest to standardowy kod statusu HTTP, kt�ry oznacza, �e ��danie zosta�o przetworzone pomy�lnie.
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
