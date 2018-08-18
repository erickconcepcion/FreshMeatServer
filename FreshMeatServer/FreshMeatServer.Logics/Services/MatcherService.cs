using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class MatcherService : EntityBaseService<Matcher>, IMatcherService
    {
        public MatcherService(IValidator<Matcher> validator, IMatcherRepository repo) : base(validator, repo)
        {

        }
    }
}