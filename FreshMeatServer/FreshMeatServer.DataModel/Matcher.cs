using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class Matcher : IEntityBase
    {
        public Matcher()
        {
            Inventories = new HashSet<Inventory>();
            Statuses = new HashSet<Status>();
        }
        [Key]
        public Guid Id { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

        public ICollection<Status> Statuses { get; set; }

        [ForeignKey("Character")]
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }

        [ForeignKey("Match")]
        public Guid MatchId { get; set; }
        public Match Match { get; set; }
    }
}
