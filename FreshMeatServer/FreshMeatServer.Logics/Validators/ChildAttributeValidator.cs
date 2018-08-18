using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class ChildAttributeValidator : AbstractValidator<ChildAttributeVm>
    {
        public ChildAttributeValidator()
        {
            RuleFor(p => p.AttributeName)
                .NotEmpty();

            RuleFor(p => p.AttributeName)
                .MaximumLength(1)
                .MaximumLength(100);

            RuleFor(p => p.ParentAttributeId)
                .NotEmpty();
        }
        
    }
}
