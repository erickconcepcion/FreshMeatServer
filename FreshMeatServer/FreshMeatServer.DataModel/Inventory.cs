using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class Inventory: IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public int ItemQuantity { get; set; }
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        [ForeignKey("Matcher")]
        public Guid MatcherId { get; set; }
        public Matcher Matcher { get; set; }

    }
}
