using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI.ViewModels
{
    internal class SearchViewModel : BaseViewModel
    {
        public const string NavTitle = "Search";
        public SearchViewModel()
        {
            Title = NavTitle;
        }
    }
}
