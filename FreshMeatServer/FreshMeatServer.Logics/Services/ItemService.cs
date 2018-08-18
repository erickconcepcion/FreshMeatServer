using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class ItemService : EntityBaseService<Item>, IItemService
    {
        public ItemService(IValidator<Item> validator, IItemRepository repo) : base(validator, repo)
        {

        }
    }
}