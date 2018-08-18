using FreshMeatServer.Common;
using FreshMeatServer.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class MatchRefVm : IViewModel
    {
        public Guid Id { get; set; }
        public MatchStatus Status { get; set; }
        public Guid MasterId { get; set; }
        public MasterVm Master { get; set; }

    }
}
