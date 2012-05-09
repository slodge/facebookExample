
using Cirrious.Conference.Core.ApplicationObjects;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using FacebookExample.Core.Models;

namespace FacebookExample.Core
{
    public class FbApp
        : MvxApplication
        , IMvxServiceProducer<IMvxStartNavigation>
        , IMvxServiceProducer<ISimpleFacebookService>
    {
        public FbApp()
        {
            this.RegisterServiceInstance<ISimpleFacebookService>(new SimpleFacebookService());
            this.RegisterServiceInstance<IMvxStartNavigation>(new StartApplicationObject());
        }
    }
}
