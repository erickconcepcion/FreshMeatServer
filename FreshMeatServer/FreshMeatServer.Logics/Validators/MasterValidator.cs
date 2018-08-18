﻿using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class MasterValidator : AbstractValidator<MasterVm>
    {
        public MasterValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty();
        }
        
    }
}
