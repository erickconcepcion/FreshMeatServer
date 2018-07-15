using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreshMeatServer.DataModel
{
    public class Character: IEntityBase
    {
        public Character()
        {
            ParentAttributeSelections = new HashSet<ParentAttributeSelection>();
            Matchers = new HashSet<Matcher>();
        }
        [Key]
        public Guid Id { get; set; }
        public string CharName { get; set; }

        public ICollection<ParentAttributeSelection> ParentAttributeSelections { get; set; }

        public ICollection<Matcher> Matchers { get; set; }

        [ForeignKey("Player")]
        public Guid PlayerId { get; set; }
        public Player Player { get; set; }

    }
}
