using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class PlayerService : EntityBaseService<Player>, IPlayerService
    {
        public PlayerService(IValidator<Player> validator, IPlayerRepository repo) : base(validator, repo)
        {

        }
    }
}