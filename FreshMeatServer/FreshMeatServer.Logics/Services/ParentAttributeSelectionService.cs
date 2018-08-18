using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class ParentAttributeSelectionService : EntityBaseService<ParentAttributeSelection>, IParentAttributeSelectionService
    {
        public ParentAttributeSelectionService(IValidator<ParentAttributeSelection> validator, IParentAttributeSelectionRepository repo) : base(validator, repo)
        {

        }
    }
}