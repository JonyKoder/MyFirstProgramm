using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string _sinchronText;
        public string SynchronText
        {
            get => _sinchronText;
            set
            {
                _sinchronText = value;
                OnPropertyChanged(nameof(SynchronText));
            }
        }
    }
}
