using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Services
{
    public interface ILobbyService
    {
        EntityActionResult InvitePlayer(Guid playerId, Guid matchId);
        EntityActionResult QuitPlayer(Guid matcherId);
        EntityActionResult SelectCharacter(Guid characterId, Guid matcherId);
        EntityActionResult StartMatch(Guid matchId);
        EntityActionResult AceptInvitation(Guid matchRequestId);
        EntityActionResult DismisInvitation(Guid matchRequestId);
        EntityActionResult GetReady(Matcher matcher);

    }
}
