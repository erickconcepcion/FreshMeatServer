using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics
{
    public interface ICharacterRepository : IEntityBaseRepository<Character>
    {
    }
    public interface IChildAttributeRepository : IEntityBaseRepository<ChildAttribute>
    {
    }
    public interface IChildAttributeSelectionRepository : IEntityBaseRepository<ChildAttributeSelection>
    {
    }
    public interface IInventoryRepository : IEntityBaseRepository<Inventory>
    {
    }
    public interface IItemRepository : IEntityBaseRepository<Item>
    {
    }
    public interface IMasterRepository : IEntityBaseRepository<Master>
    {
    }
    public interface IMatchRepository : IEntityBaseRepository<Match>
    {
    }
    public interface IMatcherRepository : IEntityBaseRepository<Matcher>
    {
    }
    public interface IParentAttributeRepository : IEntityBaseRepository<ParentAttribute>
    {
    }
    public interface IParentAttributeSelectionRepository : IEntityBaseRepository<ParentAttributeSelection>
    {
    }
    public interface IPlayerRepository : IEntityBaseRepository<Player>
    {
    }
    public interface IStatusRepository : IEntityBaseRepository<Status>
    {
    }
}
