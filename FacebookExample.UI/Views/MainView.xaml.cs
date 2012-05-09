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
    public partial class MainView : BaseMainView
    {
        public MainView()
        {
            InitializeComponent();
        }
    }

    public class BaseMainView : MvxPhonePage<MainViewModel>
    {
    }
}