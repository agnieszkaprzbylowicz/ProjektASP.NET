using Microsoft.AspNetCore.Mvc;
using ProjetkASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ProjetkASP.NET.Controllers
{
	
	public class CompanyController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]

		public IActionResult Index(CompanyModel company)
		{
			var viewModel = new CompanyAddedViewModel
			{
				NumberOfCharsInName = company.Name.Length,
				NumberOfCharsInDescription = company.Description.Length,
				IsHidden = !company.IsVisible
			};

			return View("CompanyAdded", viewModel);
		}

	
	}
}
