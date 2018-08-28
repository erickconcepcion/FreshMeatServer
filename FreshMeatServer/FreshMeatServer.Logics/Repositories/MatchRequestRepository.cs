using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Repositories
{
    public class MatchRequestRepository : EntityBaseRepository<MatchRequest>, IMatchRequestRepository
    {
        public MatchRequestRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}