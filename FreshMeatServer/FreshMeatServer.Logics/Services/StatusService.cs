using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class StatusService : EntityBaseService<Status>, IStatusService
    {
        public StatusService(IValidator<Status> validator, IStatusRepository repo) : base(validator, repo)
        {

        }
    }
}