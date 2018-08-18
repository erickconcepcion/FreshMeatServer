using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class MasterVm : IViewModel
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUserVm User { get; set; }
        public ICollection<MatchVm> Matches { get; set; }

    }
}
