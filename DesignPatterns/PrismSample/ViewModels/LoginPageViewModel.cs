using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using PrismSample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismSample.DesignTime
{

    class LoginPageDTViewModel : ILoginPage
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public DelegateCommand LoginCommand { get; set; }

        public LoginPageDTViewModel()
        {
            UserName = "TestUserName";
            Password = "TestPassword";

            LoginCommand = new DelegateCommand(() => { });            
        }
    }
}

namespace PrismSample.ViewModels
{
    public interface ILoginPage
    {
        string UserName { get; set; }
        string Password { get; set; }
        DelegateCommand LoginCommand { get;  set; }
    }
     

    class LoginPageViewModel: ViewModelBase, ILoginPage
    {
        INavigationService _navService;

        public DelegateCommand  LoginCommand{ get; set; }

        public LoginPageViewModel(INavigationService navService)
        {            
            _navService = navService;
            LoginCommand = new DelegateCommand(() =>
            {
                navService.Navigate("Main", this.UserName);
            });
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
