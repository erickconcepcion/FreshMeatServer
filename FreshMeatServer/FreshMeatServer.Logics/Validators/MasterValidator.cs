using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Validators
{
    public class MasterValidator : AbstractValidator<Master>
    {
        public MasterValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty();
        }
        
    }
}
