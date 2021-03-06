﻿using FluentValidation;
using FreshMeatServer.Common;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class StatusValidator : AbstractValidator<Status>
    {
        public StatusValidator()
        {
            RuleFor(p => p.StatusName)
               .NotEmpty();

            RuleFor(p => (int)p.IconType)
                .GreaterThanOrEqualTo((int)IconType.Death)
                .LessThanOrEqualTo((int)IconType.Breathing);
        }
    }
}
