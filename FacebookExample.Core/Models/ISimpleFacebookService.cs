using System;
using Facebook;

namespace FacebookExample.Core.Models
{
    public interface ISimpleFacebookService
    {
        Uri GetFacebookLoginUrl(string appId = SimpleFacebookService.FacebookAppId, string extendedPermissions = SimpleFacebookService.ExtendedPermissions);
        bool TryParseOAuthCallbackUrl(Uri uri, out FacebookOAuthResult oAuthResult);
        event EventHandler ConnectionChanged;
        bool IsConnected { get;  }
        void GetNameAsync(Action<string, string, string> success, Action<Exception> error);
    }
}