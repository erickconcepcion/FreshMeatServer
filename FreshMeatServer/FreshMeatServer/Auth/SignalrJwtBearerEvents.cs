using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshMeatServer.Auth
{
    public class SignalrJwtBearerEvents : JwtBearerEvents
    {
        public override Task MessageReceived(MessageReceivedContext context)
        {
            if (context.Request.Path.Value.StartsWith("/hubs") &&
                context.Token == null &&
                (context.Request.Headers.TryGetValue("Authorization", out StringValues token) ||
                context.Request.Query.TryGetValue("access_token", out StringValues token2)))
            {
                // pull token from header or querystring; websockets don't support headers so fallback to query is required
                var tokenValue = token.FirstOrDefault() ?? token2.FirstOrDefault();
                const string prefix = "Bearer ";
                // remove prefix of header value
                if (tokenValue?.StartsWith(prefix) ?? false)
                {
                    context.Token = tokenValue.Substring(prefix.Length);
                }
                else
                {
                    context.Token = tokenValue;
                }
            }

            return Task.CompletedTask;
        }
    }
}
