using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class StatusRepository : EntityBaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}