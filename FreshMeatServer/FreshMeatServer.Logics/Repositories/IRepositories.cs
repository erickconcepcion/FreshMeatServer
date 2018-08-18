using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    interface ICharacterRepository: IEntityBaseRepository<Character>
    {
    }
    interface IChildAttributeRepository : IEntityBaseRepository<ChildAttribute>
    {
    }
    interface IChildAttributeSelectionRepository : IEntityBaseRepository<ChildAttributeSelection>
    {
    }
    interface IInventoryRepository : IEntityBaseRepository<Inventory>
    {
    }
    interface IItemRepository : IEntityBaseRepository<Item>
    {
    }
    interface IMasterRepository : IEntityBaseRepository<Master>
    {
    }
    interface IMatchRepository : IEntityBaseRepository<Match>
    {
    }
    interface IMatcherRepository : IEntityBaseRepository<Matcher>
    {
    }
    interface IParentAttributeRepository : IEntityBaseRepository<ParentAttribute>
    {
    }
    interface IParentAttributeSelectionRepository : IEntityBaseRepository<ParentAttributeSelection>
    {
    }
    interface IPlayerRepository : IEntityBaseRepository<Player>
    {
    }
    interface IStatusRepository : IEntityBaseRepository<Status>
    {
    }
}
