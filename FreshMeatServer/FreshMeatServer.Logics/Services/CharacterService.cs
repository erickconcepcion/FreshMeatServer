using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class CharacterService: EntityBaseService<Character>, ICharacterService
    {
        public CharacterService(IValidator<Character> validator, ICharacterRepository repo): base(validator, repo)
        {

        }
    }
}
