using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class MasterRepository : EntityBaseRepository<Master>, IMasterRepository
    {
        public MasterRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}