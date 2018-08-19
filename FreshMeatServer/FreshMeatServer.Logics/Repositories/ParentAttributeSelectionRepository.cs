using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class ParentAttributeSelectionRepository : EntityBaseRepository<ParentAttributeSelection>, IParentAttributeSelectionRepository
    {
        public ParentAttributeSelectionRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}