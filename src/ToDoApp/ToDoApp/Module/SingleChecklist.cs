using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoApp.Module
{
    /// <summary>
    /// 自定义的接受结果
    /// </summary>
    public class SingleChecklist : ViewModelBase
    {
        public Checklist Checklist { get; set; }

        private ObservableCollection<ChecklistDetail> checklists;

        public ObservableCollection<ChecklistDetail> ChecklistDetails
        {
            get { return checklists; }
            set { checklists = value; RaisePropertyChanged(); }
        }
    }
}
