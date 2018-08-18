using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class ChildAttributeService : EntityBaseService<ChildAttribute>, IChildAttributeService
    {
        public ChildAttributeService(IValidator<ChildAttribute> validator, IChildAttributeRepository repo) : base(validator, repo)
        {

        }
    }
}
