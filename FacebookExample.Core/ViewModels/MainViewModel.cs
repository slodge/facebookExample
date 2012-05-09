using System;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Platform.Diagnostics;
using FacebookExample.Core.Models;

namespace FacebookExample.Core.ViewModels
{
    public class MainViewModel
        : BaseViewModel
    {
        public MainViewModel()
        {
            this.Facebook.ConnectionChanged += FacebookOnConnectionChanged;
        }

        private void FacebookOnConnectionChanged(object sender, EventArgs eventArgs)
        {
            var facebook = sender as ISimpleFacebookService;
            if (facebook == null)
            {
                throw new ArgumentException("sender");
            }

            this.ConnectionAvailable = facebook.IsConnected;
            if (facebook.IsConnected)
            {
                // TODO... something to message...
                facebook.GetNameAsync(this.NameAvailable, this.Error);
            }
        }

        private void NameAvailable(string id, string firstName, string lastName)
        {
            Message = string.Format("Hai {0} - I wantz to eatz sum {1} brainz", firstName, lastName);
            ImageUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}", id, "square");
        }

        private void Error(Exception exception)
        {
            MvxTrace.Trace("Nooooo: {0}", exception.ToLongString());
        }

        private bool _connectionAvailable;

        public bool ConnectionAvailable
        {
            get { return _connectionAvailable; }
            set { _connectionAvailable = value; FirePropertyChanged("ConnectionAvailable"); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; FirePropertyChanged("Message"); }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; FirePropertyChanged("ImageUrl"); }
        }

        public IMvxCommand ConnectCommand
        {
            get { return new MvxRelayCommand(() => this.RequestNavigate<LoginViewModel>()); }
        }
    }
}
