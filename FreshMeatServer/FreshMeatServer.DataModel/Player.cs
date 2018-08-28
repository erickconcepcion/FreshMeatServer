using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class Player : IEntityBase
    {
        public Player()
        {
            Characters = new HashSet<Character>();
            MatchRequests = new HashSet<MatchRequest>();
        }
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<MatchRequest> MatchRequests { get; set; }
    }
}
