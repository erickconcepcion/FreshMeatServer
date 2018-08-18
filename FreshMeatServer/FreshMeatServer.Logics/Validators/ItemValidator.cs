﻿using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class ItemValidator : AbstractValidator<ItemVm>
    {
        public ItemValidator()
        {
            RuleFor(p => p.ItemName)
                .NotEmpty();
        }
        
    }
}
