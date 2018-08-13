using FreshMeatServer.Common;
using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class Match : IEntityBase
    {
        public Match()
        {
            Matchers = new HashSet<Matcher>();
        }
        [Key]
        public Guid Id { get; set; }
        public MatchStatus Status { get; set; }
        [ForeignKey("Master")]
        public Guid MasterId { get; set; }
        public Master Master { get; set; }

        public ICollection<Matcher> Matchers { get; set; }
    }
}
