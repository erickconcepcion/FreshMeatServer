using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class ChildAttributeRepository : EntityBaseRepository<ChildAttribute>, IChildAttributeRepository
    {
        public ChildAttributeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
