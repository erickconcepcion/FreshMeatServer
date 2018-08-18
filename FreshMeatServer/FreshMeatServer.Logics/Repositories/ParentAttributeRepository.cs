using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class ParentAttributeRepository : EntityBaseRepository<ParentAttribute>, IParentAttributeRepository
    {
        public ParentAttributeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}