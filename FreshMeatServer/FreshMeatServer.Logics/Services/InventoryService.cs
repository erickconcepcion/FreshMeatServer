using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class InventoryService : EntityBaseService<Inventory>, IInventoryService
    {
        public InventoryService(IValidator<Inventory> validator, IInventoryRepository repo) : base(validator, repo)
        {

        }
    }
}
