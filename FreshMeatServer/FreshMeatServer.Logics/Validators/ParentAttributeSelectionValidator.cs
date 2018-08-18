using FluentValidation;
using FreshMeatServer.DataModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class ParentAttributeSelectionValidator : AbstractValidator<ParentAttributeSelectionVm>
    {
        public ParentAttributeSelectionValidator(ApplicationDbContext context)
        {
            RuleFor(p => p.Level)
                .NotNull();
            RuleFor(p => p.Level)
                .GreaterThanOrEqualTo((pas) => context.ParentAttributes.Where(pa => pa.Id == pas.ParentAttributeId).FirstOrDefault().MinValue);

            RuleFor(p => p.Level)
                .LessThanOrEqualTo((pas) => context.ParentAttributes.Where(pa => pa.Id == pas.ParentAttributeId).FirstOrDefault().MaxValue);

            RuleFor(p => p.CharacterId)
                .NotEmpty();
            RuleFor(p => p.ParentAttributeId)
                .NotEmpty();


        }
        
    }
}
