using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.ExchangeThings.Web.Database;

namespace Wsei.ExchangeThings.Web.ViewComponents
{
	public class LatestItem : ViewComponent
	{
		private readonly ExchangesDbContext _dbContext;
		public LatestItem(ExchangesDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IViewComponentResult Invoke()
		{
			var latestItem = _dbContext.Items
			.OrderByDescending(x => x.Id).First();
			return View("Index", latestItem);
		}
	}
}
