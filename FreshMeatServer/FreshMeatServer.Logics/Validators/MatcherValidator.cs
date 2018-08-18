using FluentValidation;
using FreshMeatServer.Common;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class MatcherValidator : AbstractValidator<MatcherVm>
    {
        public MatcherValidator()
        {
            RuleFor(p => p.Status)
                .NotEmpty();

            RuleFor(p => (int)p.Status)
                .GreaterThanOrEqualTo((int)MatcherStatus.Waitting)
                .LessThanOrEqualTo((int)MatcherStatus.Left);

            RuleFor(p => p.CharacterId)
                .NotEmpty();
            RuleFor(p => p.MatchId)
                .NotEmpty();
        }
    }
}
