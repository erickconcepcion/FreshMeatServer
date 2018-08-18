using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class ItemVm : IViewModel
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public ICollection<InventoryVm> Inventories { get; set; }
    }
}
