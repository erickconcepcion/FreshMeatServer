﻿using FluentValidation;
using FreshMeatServer.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class ParentAttributeValidator : AbstractValidator<ParentAttribute>
    {
        public ParentAttributeValidator()
        {
            RuleFor(p => p.AttributeName)
                .NotEmpty();

            RuleFor(p => p.AttributeName)
                .MinimumLength(1)
                .MaximumLength(100);
        }        
    }
}
