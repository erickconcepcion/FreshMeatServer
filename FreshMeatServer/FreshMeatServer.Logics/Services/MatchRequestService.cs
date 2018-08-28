using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Services
{
    public class MatchRequestService : EntityBaseService<MatchRequest>, IMatchRequestService
    {
        public MatchRequestService(IValidator<MatchRequest> validator, IMatchRequestRepository repo) : base(validator, repo)
        {

        }
    }
}