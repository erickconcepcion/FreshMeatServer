using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class ParentAttributeSelection : IEntityBase
    {
        public ParentAttributeSelection()
        {
            ChildAttributeSelections = new HashSet<ChildAttributeSelection>();
        }
        [Key]
        public Guid Id { get; set; }
        public int Level { get; set; }

        public ICollection<ChildAttributeSelection> ChildAttributeSelections { get; set; }

        [ForeignKey("ParentAttribute")]
        public Guid ParentAttributeId { get; set; }
        public ParentAttribute ParentAttribute { get; set; }

        [ForeignKey("Character")]
        public Guid CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
