﻿using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    public class MatcherRepository : EntityBaseRepository<Matcher>, IMatcherRepository
    {
        public MatcherRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}