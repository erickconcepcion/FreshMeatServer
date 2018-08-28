using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public interface ICharacterService : IEntityBaseService<Character>
    {
    }
    public interface IChildAttributeService : IEntityBaseService<ChildAttribute>
    {
    }
    public interface IChildAttributeSelectionService : IEntityBaseService<ChildAttributeSelection>
    {
    }
    public interface IInventoryService : IEntityBaseService<Inventory>
    {
    }
    public interface IItemService : IEntityBaseService<Item>
    {
    }
    public interface IMasterService : IEntityBaseService<Master>
    {
    }
    public interface IMatchService : IEntityBaseService<Match>
    {
    }
    public interface IMatcherService : IEntityBaseService<Matcher>
    {
    }
    public interface IParentAttributeService : IEntityBaseService<ParentAttribute>
    {
    }
    public interface IParentAttributeSelectionService : IEntityBaseService<ParentAttributeSelection>
    {
    }
    public interface IPlayerService : IEntityBaseService<Player>
    {
    }
    public interface IStatusService : IEntityBaseService<Status>
    {
    }
    public interface IMatchRequestService : IEntityBaseService<MatchRequest>
    {
    }
}
