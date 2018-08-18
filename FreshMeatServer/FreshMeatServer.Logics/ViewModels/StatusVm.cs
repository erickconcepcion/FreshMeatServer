using FreshMeatServer.Common;
using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class StatusVm : IViewModel
    {
        public Guid Id { get; set; }
        public string StatusName { get; set; }
        public IconType IconType { get; set; }

    }
}
