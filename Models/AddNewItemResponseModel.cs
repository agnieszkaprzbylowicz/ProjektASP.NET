using Microsoft.EntityFrameworkCore;
using Wsei.ExchangeThings.Web.Entities;

namespace Wsei.ExchangeThings.Web.Controllers
{
    public class AddNewItemResponseModel
    {
        public bool success { get; set; }
        public DbSet<ItemEntity> ObjectJson { get; set; }
    }
}