using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class ChildAttributeSelectionRepository : EntityBaseRepository<ChildAttributeSelection>, IChildAttributeSelectionRepository
    {
        public ChildAttributeSelectionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
