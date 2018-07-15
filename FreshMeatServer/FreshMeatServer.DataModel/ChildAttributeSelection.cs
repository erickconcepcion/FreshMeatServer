using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class ChildAttributeSelection : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public int Level { get; set; }

        [ForeignKey("ChildAttribute")]
        public Guid ChildAttributeId { get; set; }
        public ChildAttribute ChildAttribute { get; set; }

        [ForeignKey("ParentAttributeSelection")]
        public Guid ParentAttributeSelectionId { get; set; }
        public ParentAttributeSelection ParentAttributeSelection { get; set; }
    }
}
