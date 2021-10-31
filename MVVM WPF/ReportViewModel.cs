using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBL;

namespace MVVM_WPF
{
    public class ReportViewModel : BindableObject
    {

        public ObservableCollection<ReportWrapper> Reports { get; set; } = new();

        private readonly IRepository<Report> repository;
        private readonly TestContext context;
        public ReportViewModel()
        {
            context = new();
            repository = new Repository<Report>(context);
            RefreshReports();
            
        }
        public ReportWrapper EditWrapper { get; set; }
        public void AddReport()
        {
            repository.AddItem(EditWrapper.GetReport);
            RefreshReports();
        }
        public void RefreshReports()
        {
            Reports.Clear();
            ResetSelectWrapper();
            var items = repository.GetItems();
            foreach (var item in items)
            {
                var wrapper = new ReportWrapper(item);
                wrapper.ItemSelected += ItemSelected_Click;
                Reports.Add(wrapper);
            }

        }
        public void UpdateReports()
        {
            repository.UpdateItem(EditWrapper.GetReport);
            RefreshReports();
        }
        public void ResetSelectWrapper()
        {
            EditWrapper = new ReportWrapper(new Report());
            OnPropertyChanged(nameof(EditWrapper));
        }
        public void ItemSelected_Click(object sender, object sendObject)
        {
            if (sendObject.ToString() == "Remove")
            {
                repository.DeleteItem((sender as ReportWrapper).GetReport.Id);
                RefreshReports();
            }
            else
                EditWrapper = (ReportWrapper)sender;
        }                                 
    }
}
