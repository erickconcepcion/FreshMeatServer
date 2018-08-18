using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    interface ICharacterService: IEntityBaseService<Character>
    {
    }
    interface IChildAttributeService : IEntityBaseService<ChildAttribute>
    {
    }
    interface IChildAttributeSelectionService : IEntityBaseService<ChildAttributeSelection>
    {
    }
    interface IInventoryService : IEntityBaseService<Inventory>
    {
    }
    interface IItemService : IEntityBaseService<Item>
    {
    }
    interface IMasterService : IEntityBaseService<Master>
    {
    }
    interface IMatchService : IEntityBaseService<Match>
    {
    }
    interface IMatcherService : IEntityBaseService<Matcher>
    {
    }
    interface IParentAttributeService : IEntityBaseService<ParentAttribute>
    {
    }
    interface IParentAttributeSelectionService : IEntityBaseService<ParentAttributeSelection>
    {
    }
    interface IPlayerService : IEntityBaseService<Player>
    {
    }
    interface IStatusService : IEntityBaseService<Status>
    {
    }
}
