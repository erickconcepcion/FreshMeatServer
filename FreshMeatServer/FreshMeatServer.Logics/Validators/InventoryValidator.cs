using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class InventoryValidator : AbstractValidator<Inventory>
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
