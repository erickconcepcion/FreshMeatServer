using FreshMeatServer.Common;
using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class MatchRequest : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public MatchRequestStatus MatchRequestStatus { get; set; }

        [ForeignKey("Match")]
        public Guid? MatchId { get; set; }
        public Match Match { get; set; }

        [ForeignKey("Player")]
        public Guid? PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
