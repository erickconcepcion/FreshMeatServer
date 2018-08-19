using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class MatchService : EntityBaseService<Match>, IMatchService
    {
        public MatchService(IValidator<Match> validator, IMatchRepository repo) : base(validator, repo)
        {

        }
    }
}