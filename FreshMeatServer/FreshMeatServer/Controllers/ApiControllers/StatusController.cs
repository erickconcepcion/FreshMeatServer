using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using Microsoft.AspNetCore.Authorization;
using FreshMeatServer.Logics;
using AutoMapper;

namespace FreshMeatServer.Controllers
{
    [Authorize(Policy = "ApiUser")]
    public class StatusController : EntityBaseApiController<Status, StatusVm>
    {
        public StatusController(IStatusService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}