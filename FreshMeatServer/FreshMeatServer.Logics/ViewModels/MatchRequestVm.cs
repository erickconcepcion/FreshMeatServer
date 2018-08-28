using FreshMeatServer.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class MatchRequestVm
    {
        public Guid Id { get; set; }
        public MatchRequestStatus MatchRequestStatus { get; set; }
        public Guid MatchId { get; set; }
        public MatchVm Match { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerVm Player { get; set; }
    }
}
