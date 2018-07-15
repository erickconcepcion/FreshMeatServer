using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class Item : IEntityBase
    {
        public Item()
        {
            Inventories = new HashSet<Inventory>();
        }
        [Key]
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
