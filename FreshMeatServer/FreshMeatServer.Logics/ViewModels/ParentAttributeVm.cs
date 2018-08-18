using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class ParentAttributeVm : IViewModel
    {
        public Guid Id { get; set; }
        public string AttributeName { get; set; }
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public ICollection<ChildAttributeVm> ChildAttributes { get; set; }
    }
}
