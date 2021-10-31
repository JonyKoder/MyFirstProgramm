using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestBL;

namespace MVVM_WPF
{
    public delegate void SelectedItemDelegate(object sender, object sendObject);
    public class ReportWrapper
    {
        private readonly Report _report;
        public ReportWrapper(Report report) => _report = report;
        public event SelectedItemDelegate ItemSelected;
        public Report GetReport
        {
            get => _report;
        }
        public ICommand Selected
        {
            get => new ActionCommand((obj) =>
            {
                ItemSelected?.Invoke(this, obj);
            });
        }
    }
}
