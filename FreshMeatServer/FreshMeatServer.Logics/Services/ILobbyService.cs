using FreshMeatServer.Core;
using FreshMeatServer.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreshMeatServer.Logics.Services
{
    public interface ILobbyService
    {
        EntityActionResult InvitePlayer(string username);
        EntityActionResult QuitPlayer(string username);
        EntityActionResult SelectCharacter(Character character);
        EntityActionResult StartMatch(Guid matchId);
        EntityActionResult AceptInvitation(string username);
        EntityActionResult DismisInvitation(string username);

    }
}
