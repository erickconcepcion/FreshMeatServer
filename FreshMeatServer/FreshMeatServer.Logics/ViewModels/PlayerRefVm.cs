using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class PlayerRefVm : IViewModel
    {
        
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUserVm User { get; set; }

    }
}
