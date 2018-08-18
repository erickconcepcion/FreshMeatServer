using FreshMeatServer.Common;
using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class MatcherRefVm : IViewModel
    {
        public Guid Id { get; set; }
        public MatcherStatus Status { get; set; }
        public ICollection<InventoryVm> Inventories { get; set; }

        public ICollection<StatusVm> Statuses { get; set; }

        public Guid CharacterId { get; set; }
        public CharacterVm Character { get; set; }

        public Guid MatchId { get; set; }
        public MatchVm Match { get; set; }
    }
}
