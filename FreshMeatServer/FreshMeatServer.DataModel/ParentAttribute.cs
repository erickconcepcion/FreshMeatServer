using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.DataModel
{
    public class ParentAttribute : IEntityBase
    {
        public ParentAttribute()
        {

            ChildAttributes = new HashSet<ChildAttribute>();
        }
        [Key]
        public Guid Id { get; set; }
        public string AttributeName { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public ICollection<ChildAttribute> ChildAttributes { get; set; }
    }
}
