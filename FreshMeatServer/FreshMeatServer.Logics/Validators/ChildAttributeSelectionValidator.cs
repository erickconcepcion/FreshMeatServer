using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class ChildAttributeSelectionValidator : AbstractValidator<ChildAttributeSelectionVm>
    {
        public ChildAttributeSelectionValidator()
        {
            RuleFor(p => p.Level)
                .NotNull();

            RuleFor(p => p.ChildAttributeId)
                .NotEmpty();

            RuleFor(p => p.ParentAttributeSelectionId)
                .NotEmpty();
        }
        
    }
}
