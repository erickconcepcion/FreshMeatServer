using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using FreshMeatServer.Logics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreshMeatServer.Controllers
{
    [Authorize(Policy = "ApiUser")]
    public class CharacterController :EntityBaseApiController<Character, CharacterVm>
    {
        public CharacterController(ICharacterService service, IMapper mapper): base(service, mapper)
        {

        }
    }
}