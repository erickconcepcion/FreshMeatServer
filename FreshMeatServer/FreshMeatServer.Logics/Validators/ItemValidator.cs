using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
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
