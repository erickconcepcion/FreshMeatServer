using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class ChildAttributeSelectionService : EntityBaseService<ChildAttributeSelection>, IChildAttributeSelectionService
    {
        public ChildAttributeSelectionService(IValidator<ChildAttributeSelection> validator, IChildAttributeSelectionRepository repo) : base(validator, repo)
        {

        }
    }
}
