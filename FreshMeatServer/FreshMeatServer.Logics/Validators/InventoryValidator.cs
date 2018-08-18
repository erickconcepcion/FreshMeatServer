using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class InventoryValidator : AbstractValidator<InventoryVm>
    {
        public InventoryValidator()
        {
            RuleFor(p => p.ItemQuantity)
                .NotNull();

            RuleFor(p => p.ItemId)
                .NotEmpty();

            RuleFor(p => p.MatcherId)
                .NotEmpty();
        }
        
    }
}
