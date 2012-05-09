using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.ViewModels;
using FacebookExample.Core.Models;

namespace FacebookExample.Core.ViewModels
{
    public class BaseViewModel
        : MvxViewModel
          , IMvxServiceConsumer<ISimpleFacebookService>
    {
        protected ISimpleFacebookService Facebook
        {
            get
            {
                return this.GetService<ISimpleFacebookService>();
            }
        }
    }
}