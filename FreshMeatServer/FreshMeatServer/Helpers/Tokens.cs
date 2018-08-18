using Newtonsoft.Json;
using FreshMeatServer.Auth;
using FreshMeatServer.Logics;
using FreshMeatServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FreshMeatServer.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings, ApplicationUserVm applicationUser)
        {
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
                expires_in = (int)jwtOptions.ValidFor.TotalSeconds,
                user = applicationUser
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}
