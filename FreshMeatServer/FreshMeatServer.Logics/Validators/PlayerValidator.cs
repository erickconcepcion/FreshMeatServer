using FluentValidation;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public class PlayerValidator : AbstractValidator<PlayerVm>
    {
        public PlayerValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty();
        }
    }
}
