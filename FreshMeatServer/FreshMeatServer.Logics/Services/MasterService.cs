using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class MasterService : EntityBaseService<Master>, IMasterService
    {
        public MasterService(IValidator<Master> validator, IMasterRepository repo) : base(validator, repo)
        {

        }
    }
}