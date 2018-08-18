using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class CharacterValidator: AbstractValidator<CharacterVm>
    {
        public CharacterValidator()
        {
            RuleFor(p => p.CharName)
                .NotEmpty();

            RuleFor(p => p.CharName)
                .MinimumLength(2)
                .MaximumLength(200);

            RuleFor(p => p.CharName)
                .NotEmpty();

            RuleFor(p => p.ParentAttributeSelections)
                .Must(pas=>pas.Count==0 || pas.Sum(at=>at.Level) == 0);
        }
        
    }
}
