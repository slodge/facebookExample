using System;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;
using Facebook;

namespace FacebookExample.Core.ViewModels
{
    public class LoginViewModel
        : BaseViewModel
    {
        public Uri LoginUri { get { return Facebook.GetFacebookLoginUrl(); }}

        public IMvxCommand ProcessUriCommand
        {
            get
            {
                return new MvxRelayCommand<Uri>(uri =>
                                                    {
                                                        FacebookOAuthResult oAuthResult;
                                                        if (!Facebook.TryParseOAuthCallbackUrl(uri, out oAuthResult))
                                                        {
                                                            return;
                                                        }

                                                        // we have a login, so close this...
                                                        this.RequestClose(this);
                                                    });
            }
        }
    }
}