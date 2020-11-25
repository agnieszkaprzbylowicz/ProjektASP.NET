using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wsei.ExchangeThings.Web.Database;
using Wsei.ExchangeThings.Web.Entities;
using Wsei.ExchangeThings.Web.Models;

namespace Wsei.ExchangeThings.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ExchangesDbContext _dbContext;
        public ItemController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AddNewItemResponseModel Post(ItemModel item) {
            bool s = !string.IsNullOrEmpty(item.Description) && !string.IsNullOrEmpty(item.Name);

            if (s)
            {
                var entity = new ItemEntity
                {
                    Name = item.Name,
                    Description = item.Description,
                    IsVisible = item.IsVisible,
                };
                _dbContext.Items.Add(entity);
                _dbContext.SaveChanges();
            }

            var res = new AddNewItemResponseModel
            {
                success = s,
                ObjectJson = _dbContext.Items
            };
            return res;
        }
    }
}
