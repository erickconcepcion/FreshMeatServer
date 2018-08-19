using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class ParentAttributeService : EntityBaseService<ParentAttribute>, IParentAttributeService
    {
        public ParentAttributeService(IValidator<ParentAttribute> validator, IParentAttributeRepository repo) : base(validator, repo)
        {

        }
    }
}