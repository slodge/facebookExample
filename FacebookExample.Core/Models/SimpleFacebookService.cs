using System;
using System.Collections.Generic;
using System.Net;
using Facebook;

namespace FacebookExample.Core.Models
{
    public class SimpleFacebookService : ISimpleFacebookService
    {
        public const string FacebookAppId = "6543862477";
        public const string FacebookAppSecret = "6d61dbddd5d913c00ffa89667f316263";
        public const string FacebookAppRedirectUrl = "http://ignored.com/";
        public const string ExtendedPermissions = "user_photos,user_about_me";

        private string _accessToken;

        public SimpleFacebookService()
        {
        }

        private FacebookClient CreateFacebookClient()
        {
            if (string.IsNullOrEmpty(this._accessToken))
            {
                return new FacebookClient();
            }

            return new FacebookClient(this._accessToken);
        }

        public Uri GetFacebookLoginUrl(string appId = FacebookAppId, string extendedPermissions = ExtendedPermissions)
        {
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = appId;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            parameters["response_type"] = "token";
            parameters["display"] = "touch";

            // add the 'scope' only if we have extendedPermissions.
            if (!String.IsNullOrEmpty(extendedPermissions))
            {
                // A comma-delimited list of permissions
                parameters["scope"] = extendedPermissions;
            }

            return CreateFacebookClient().GetLoginUrl(parameters);
        }

        public bool TryParseOAuthCallbackUrl(Uri uri, out FacebookOAuthResult oAuthResult)
        {
            var result = CreateFacebookClient().TryParseOAuthCallbackUrl(uri, out oAuthResult);
            if (!result)
            {
                return false;
            }

            _accessToken = oAuthResult.AccessToken;
            FireConnectionChanged();
            return true;
        }

        private void FireConnectionChanged()
        {
            var handler = this.ConnectionChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public event EventHandler ConnectionChanged;

        public bool IsConnected
        {
            get { return !string.IsNullOrEmpty(_accessToken); }
        }

        public void GetNameAsync(Action<string, string, string> success, Action<Exception> error)
        {
            var fb = CreateFacebookClient();

            fb.GetCompleted += (o, e) =>
                                   {
                                       if (e.Error != null)
                                       {
                                           error(e.Error);
                                       }

                                       var result = (IDictionary<string, object>) e.GetResultData();

                                       success(
                                           (string)result["id"],
                                           (string)result["first_name"],
                                           (string) result["last_name"]);
                                   };

            fb.GetAsync("me");
        }
    }
}
