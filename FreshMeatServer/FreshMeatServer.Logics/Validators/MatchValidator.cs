using FluentValidation;
using FreshMeatServer.Common;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class MatchValidator : AbstractValidator<MatchVm>
    {
        public MatchValidator()
        {
            RuleFor(p => p.Status)
                .NotEmpty();

            RuleFor(p => (int)p.Status)
                .GreaterThanOrEqualTo((int)MatchStatus.Lobby)
                .LessThanOrEqualTo((int)MatchStatus.Finished);

            RuleFor(p => p.MasterId)
                .NotEmpty();
        }
    }
}
