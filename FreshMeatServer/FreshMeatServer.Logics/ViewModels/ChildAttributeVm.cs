using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class ChildAttributeVm : IViewModel
    {
        public Guid Id { get; set; }
        public string AttributeName { get; set; }
        public Guid ParentAttributeId { get; set; }
        public ParentAttributeRefVm ParentAttribute { get; set; }

    }
}
