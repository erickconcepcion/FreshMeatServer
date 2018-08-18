using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class ItemRefVm : IViewModel
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
    }
}
