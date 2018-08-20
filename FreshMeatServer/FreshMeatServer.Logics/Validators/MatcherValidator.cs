using FluentValidation;
using FreshMeatServer.Common;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class MatcherValidator : AbstractValidator<Matcher>
    {
        public MatcherValidator()
        {
            RuleFor(p => p.Status)
                .NotEmpty();

            RuleFor(p => (int)p.Status)
                .GreaterThanOrEqualTo((int)MatcherStatus.Waitting)
                .LessThanOrEqualTo((int)MatcherStatus.Complete);

            RuleFor(p => p.CharacterId)
                .NotEmpty();
            RuleFor(p => p.MatchId)
                .NotEmpty();
        }
    }
}
