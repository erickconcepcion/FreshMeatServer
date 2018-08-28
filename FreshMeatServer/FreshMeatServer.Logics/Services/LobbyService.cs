using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FreshMeatServer.Common;
using FreshMeatServer.Core;
using FreshMeatServer.DataModel;

namespace FreshMeatServer.Logics.Services
{
    public class LobbyService: ILobbyService
    {
        private IPlayerService _playerService;
        private IMatchService _matchService;
        private IMatchRequestService _matchRequestService;
        private IMatcherService _matcherService;
        private IInventoryService _inventoryService;

        public LobbyService(IMatchService matchService, 
            IPlayerService playerService, IMatchRequestService matchRequestService,
            IMatcherService matcherService,
            IInventoryService inventoryService)
        {
            _playerService = playerService;
            _matchService = matchService;
            _matchRequestService = matchRequestService;
            _inventoryService = inventoryService;
        }

        public EntityActionResult AceptInvitation(Guid matchRequestId)
        {
            EntityActionResult result = new EntityActionResult();
            List<string> errors = new List<string>();
            var req =_matchRequestService.Find(matchRequestId, "PlayerId, PlayerId.Characters");
            req.MatchRequestStatus = MatchRequestStatus.Yes;
            if (req.MatchId!=null && req.PlayerId!=null && req.Player.Characters.Any())
            {
                Matcher matcher = new Matcher
                {
                    Status = MatcherStatus.Waitting,
                    CharacterId = req.Player.Characters.FirstOrDefault().Id,
                    MatchId = (Guid)req.MatchId
                };
                result = _matcherService.Add(matcher);
            }
            else
            {
                errors.Add("You must have a character to acept.");
            }
            if (!_matcherService.Save())
                errors.Add("Something wint wrong saving.");

            if (errors.Any())
            {

                result.ErrorCode = 500;
                result.Success = false;
                result.Messages = errors;
            }

            return result;
        }

        public EntityActionResult GetReady(Matcher matcher)
        {
            EntityActionResult result = new EntityActionResult();
            List<string> errors = new List<string>();
            matcher.Status = MatcherStatus.Ready;
            if (matcher.Inventories.Any())
            {
                var validInventory =_inventoryService.ValidateRange(matcher.Inventories);
                if (!validInventory.Where(vi=>!vi.Success).Any())
                    errors.Add("Invalid inventory.");
            }
            result = _matcherService.Update(matcher);
            if (!_matcherService.Save())
                errors.Add("Something wint wrong saving.");

            if (errors.Any())
            {
                result.ErrorCode = 500;
                result.Success = false;
                result.Messages = errors;
            }
            return result;

        }

        public EntityActionResult DismisInvitation(Guid matchRequestId)
        {
            EntityActionResult result = new EntityActionResult();
            List<string> errors = new List<string>();
            var req = _matchRequestService.Find(matchRequestId);
            if (req!=null)
            {
                req.MatchRequestStatus = MatchRequestStatus.No;
                result = _matchRequestService.Update(req);
            }
            else
            {
                errors.Add("This request does not exists");
            }
            if (!_matchRequestService.Save())
                errors.Add("Something wint wrong saving.");

            if (errors.Any())
            {
                result.ErrorCode = 500;
                result.Success = false;
                result.Messages = errors;
            }
            return result;
        }

        public EntityActionResult InvitePlayer(Guid playerId, Guid matchId)
        {
            EntityActionResult result = new EntityActionResult();
            List<string> errors = new List<string>();
            if (_playerService.FindBy(p=>p.Id==playerId).Any() && _matchService.FindBy(p => p.Id == matchId).Any())
            {
                result = _matchRequestService.Add(new MatchRequest
                {
                    MatchId = matchId,
                    PlayerId = playerId,
                    MatchRequestStatus = MatchRequestStatus.Pending,
                });
            }
            else
            {
                errors.Add("Player or Match invalid");
            }
            if (!_matchRequestService.Save())
                errors.Add("Something wint wrong saving.");

            if (errors.Any())
            {
                result.ErrorCode = 500;
                result.Success = false;
                result.Messages = errors;
            }
            return result;
        }

        public EntityActionResult QuitPlayer(Guid matcherId)
        {
            EntityActionResult result = new EntityActionResult();
            List<string> errors = new List<string>();
            var matcher = _matcherService.Find(matcherId);
            if (matcher!=null)
            {
                _matcherService.Delete(matcher);
                result.Success = true;
            }
            else
            {
                errors.Add("This player does not exists on this match");
            }
            if (!_matcherService.Save())
                errors.Add("Something wint wrong saving.");

            if (errors.Any())
            {
                result.ErrorCode = 500;
                result.Success = false;
                result.Messages = errors;
            }
            return result;
        }

        public EntityActionResult SelectCharacter(Guid characterId, Guid matcherId)
        {
            EntityActionResult result = new EntityActionResult();
            List<string> errors = new List<string>();
            
            throw new NotImplementedException();
        }

        public EntityActionResult StartMatch(Guid matchId)
        {
            EntityActionResult result = new EntityActionResult();
            List<string> errors = new List<string>();

            throw new NotImplementedException();
        }
    }
}
