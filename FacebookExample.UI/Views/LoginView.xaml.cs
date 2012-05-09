using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Cirrious.MvvmCross.WindowsPhone.Views;
using FacebookExample.Core.ViewModels;
using Microsoft.Phone.Controls;

namespace FacebookExample.UI.Views
{
    public partial class LoginView : BaseLoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void WebBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            var browser = (WebBrowser) sender;
            browser.Navigate(ViewModel.LoginUri);
        }

        private void WebBrowser_Navigating(object sender, NavigatingEventArgs e)
        {
            ViewModel.ProcessUriCommand.Execute(e.Uri);
        }
    }

    public class BaseLoginView : MvxPhonePage<LoginViewModel>
    {

    }
}