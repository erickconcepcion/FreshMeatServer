using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using FreshMeatServer.Core;

namespace FreshMeatServer.Logics.Services
{
    public interface IPlayService
    {
        EntityActionResult AddStatus(Status status);
        EntityActionResult RemoveStatus(Status status);
        EntityActionResult UpdateInventory(Inventory inventory);
        EntityActionResult LeavePlayer(Matcher matcher);
        EntityActionResult AbortMatch(Match match);
        EntityActionResult PauseMatch(Match match);
        EntityActionResult FinishMatch(Match match);
        EntityActionResult ContinueMatch(Match match);

    }
}
