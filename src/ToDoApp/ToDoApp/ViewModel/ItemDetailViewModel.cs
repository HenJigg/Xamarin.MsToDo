using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Interfaces;
using ToDoApp.Module;

namespace ToDoApp.ViewModel
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private readonly IToDoService toDoService;
        public ItemDetailViewModel(SingleChecklist checklist)
        {
            this.SingleChecklist = checklist;
            toDoService = ServiceProvider.Instance.Get<IToDoService>();
            ExcludeCommand = new RelayCommand<ChecklistDetail>(t => UpdateDeleteStatus(t));
            KeepCommand = new RelayCommand<ChecklistDetail>(t => UpdateFavoriteStatus(t));
            AddCommand = new RelayCommand(AddTask);
            DeleteCommand = new RelayCommand<ChecklistDetail>(t => DeleteTask(t));
        }

        private SingleChecklist singleChecklist;

        public SingleChecklist SingleChecklist
        {
            get { return singleChecklist; }
            set { singleChecklist = value; RaisePropertyChanged(); }
        }

        private string content = string.Empty;

        /// <summary>
        /// 编辑器的内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }

        public RelayCommand<ChecklistDetail> ExcludeCommand { get; private set; }
        public RelayCommand<ChecklistDetail> KeepCommand { get; private set; }

        //新增
        public RelayCommand AddCommand { get; private set; }
        //删除
        public RelayCommand<ChecklistDetail> DeleteCommand { get; private set; }


        public async void AddTask()
        {
            if (string.IsNullOrWhiteSpace(Content)) return;
            ChecklistDetail detail = new ChecklistDetail();
            detail.Id = Guid.NewGuid().ToString();
            detail.Content = Content;

            var r = await toDoService.AddToDoDetailAsync(SingleChecklist.Checklist.Id, detail);
            if (r)
            {
                SingleChecklist.ChecklistDetails.Add(new ChecklistDetail() { Content = Content });
                Content = string.Empty;
            }
        }

        public async void DeleteTask(ChecklistDetail t)
        {
            var r = await toDoService.DeleteToDoInfoByIdAsync(t.Id);
            if (r)
                SingleChecklist.ChecklistDetails.Remove(t);
        }

        public async void UpdateDeleteStatus(ChecklistDetail detail)
        {
            bool result = false;
            if (detail.IsDeleted)
                result = false;
            else
                result = true;

            var r = await toDoService.UpdateDeleteStatus(detail.Id, result);
            if (r)
                detail.IsDeleted = result;
        }

        public async void UpdateFavoriteStatus(ChecklistDetail detail)
        {
            bool result = false;
            if (detail.IsFavorite)
                result = false;
            else
                result = true;

            var r = await toDoService.UpdateFavoriteStatus(detail.Id, result);
            if (r)
                detail.IsFavorite = result;
        }

        public async Task<bool> UpdateName(string name)
        {
            var r = await toDoService.UpdateToDoGroupNameAsync(SingleChecklist.Checklist.Id, name);
            if (r)
                return true;
            return false;
        }

        public async Task<bool> DeleteCheckList()
        {
            var r = await toDoService.DeleteToDoGroupByIdAsync(SingleChecklist.Checklist.Id);
            if (r)
                return true;
            return false;
        }
    }
}
