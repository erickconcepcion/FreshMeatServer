using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class ChildAttribute : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string AttributeName { get; set; }
        [ForeignKey("ParentAttribute")]
        public Guid ParentAttributeId { get; set; }
        public ParentAttribute ParentAttribute { get; set; }

    }
}
