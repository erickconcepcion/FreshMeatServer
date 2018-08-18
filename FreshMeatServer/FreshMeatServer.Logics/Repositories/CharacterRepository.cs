using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics
{
    class CharacterRepository: EntityBaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}
