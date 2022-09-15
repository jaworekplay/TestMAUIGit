using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Base;

namespace UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Title = "Main View Model";
            BreadCrumbs = new ObservableCollection<BaseViewModel>();

            CounterCommand = new DelegateCommand<int>(CounterMethod);
            SelectBreadCrumbCommand = new DelegateCommand<BaseViewModel>(SelectViewModel);
        }

        private void SelectViewModel(BaseViewModel vm)
        {
            SelectedViewModel = vm;
        }

        private void CounterMethod(int obj)
        {
            Counter += obj;
            if (Counter % 2 == 0)
            {
                var v = new HomeViewModel();
                BreadCrumbs.Add(v);
                SelectedViewModel = v;
            }
            else
            {
                var v = new SearchViewModel();
                BreadCrumbs.Add(v);
                SelectedViewModel= v;
            }
        }

        public IDelegateCommand<int> CounterCommand { get; set; }
        public IDelegateCommand<BaseViewModel> SelectBreadCrumbCommand { get; set; }

        private int counter;

        public int Counter
        {
            get { return counter; }
            set { counter = value; OnPropertyChanged(); }
        }

        private ObservableCollection<BaseViewModel> breadCrumbs;

        public ObservableCollection<BaseViewModel> BreadCrumbs
        {
            get { return breadCrumbs; }
            set { breadCrumbs = value; OnPropertyChanged(); }
        }

        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged(); }
        }

    }
}
