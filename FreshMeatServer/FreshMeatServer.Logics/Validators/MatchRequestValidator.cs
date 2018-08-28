using FluentValidation;
using FreshMeatServer.Common.Enums;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class MatchRequestValidator: AbstractValidator<MatchRequest>
    {
        public MatchRequestValidator()
        {
            RuleFor(p => p.MatchRequestStatus)
                .NotEmpty();

            RuleFor(p => (int)p.MatchRequestStatus)
                .GreaterThanOrEqualTo((int)MatchRequestStatus.Pending)
                .LessThanOrEqualTo((int)MatchRequestStatus.No);

            RuleFor(p => p.PlayerId)
                .NotEmpty();
            RuleFor(p => p.MatchId)
                .NotEmpty();
        }
    }
}
