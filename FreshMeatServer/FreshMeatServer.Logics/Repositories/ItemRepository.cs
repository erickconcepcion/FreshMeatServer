using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class ItemRepository : EntityBaseRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}