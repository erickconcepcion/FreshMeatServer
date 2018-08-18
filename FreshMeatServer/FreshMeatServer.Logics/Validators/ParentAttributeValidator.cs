using FluentValidation;
using FreshMeatServer.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class ParentAttributeValidator : AbstractValidator<ParentAttributeVm>
    {
        public ParentAttributeValidator()
        {
            RuleFor(p => p.AttributeName)
                .NotEmpty();

            RuleFor(p => p.AttributeName)
                .MaximumLength(1)
                .MaximumLength(100);
        }        
    }
}
