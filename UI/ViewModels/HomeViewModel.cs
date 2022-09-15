using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI.ViewModels
{
    internal class HomeViewModel : BaseViewModel
    {
        public const string NavTitle = "Home";
        public HomeViewModel()
        {
            Title = NavTitle;
        }
    }
}
