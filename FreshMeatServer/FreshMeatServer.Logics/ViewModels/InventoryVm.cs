using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class InventoryVm : IViewModel
    {
        public Guid Id { get; set; }
        public int ItemQuantity { get; set; }
        public Guid ItemId { get; set; }
        public ItemRefVm Item { get; set; }
        public Guid MatcherId { get; set; }
        public MatcherRefVm Matcher { get; set; }

    }
}
