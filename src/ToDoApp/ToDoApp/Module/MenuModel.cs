using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoApp.Module
{
    public class MenuGroup : List<MenuModel>
    {
        public MenuGroup(string name, List<MenuModel> models) : base(models)
        {
            this.name = name;
        }
        public string name { get; private set; }
    }

    //单项
    public class MenuModel : ViewModelBase
    {
        public string IconFont { get; set; }

        public string Title { get; set; }

        public string BackColor { get; set; }


        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }
    }

    public class TaskInfo : ViewModelBase
    {
        private bool isDeleted;
        private bool isFavorite;


        public string Content { get; set; }

        /// <summary>
        /// 收藏
        /// </summary>
        public bool IsFavorite
        {
            get { return isFavorite; }
            set { isFavorite = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; RaisePropertyChanged(); }
        }

    }
}
