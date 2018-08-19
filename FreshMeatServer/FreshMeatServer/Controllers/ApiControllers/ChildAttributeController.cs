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
    public class ChildAttributeController : EntityBaseApiController<ChildAttribute, ChildAttributeVm>
    {
        public ChildAttributeController(IChildAttributeService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}