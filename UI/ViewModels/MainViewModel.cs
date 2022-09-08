using System;
using System.Collections.Generic;
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
            CounterCommand = new DelegateCommand<int>(CounterMethod);
        }

        private void CounterMethod(int obj)
        {
            Counter += obj;
        }

        public IDelegateCommand<int> CounterCommand { get; set; }

        private int counter;

        public int Counter
        {
            get { return counter; }
            set { counter = value; OnPropertyChanged(); }
        }

    }
}
