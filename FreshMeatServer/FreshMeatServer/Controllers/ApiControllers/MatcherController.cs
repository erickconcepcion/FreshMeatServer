using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using FreshMeatServer.Logics;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace FreshMeatServer.Controllers
{
    [Authorize(Policy = "ApiUser")]
    public class MatcherController : EntityBaseApiController<Matcher, MatcherVm>
    {
        public MatcherController(IMatcherService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}