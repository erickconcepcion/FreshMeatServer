using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class ChildAttributeSelectionVm : IViewModel
    {
        public Guid Id { get; set; }
        public int Level { get; set; }

        public Guid ChildAttributeId { get; set; }
        public ChildAttributeVm ChildAttribute { get; set; }

        public Guid ParentAttributeSelectionId { get; set; }
        public ParentAttributeSelectionRefVm ParentAttributeSelection { get; set; }
    }
}
