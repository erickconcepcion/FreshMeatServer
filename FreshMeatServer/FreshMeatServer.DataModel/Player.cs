using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class Player : IEntityBase
    {
        public Player()
        {
            Characters = new HashSet<Character>();
        }
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
