using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core;
using ToDoApp.Interfaces;
using ToDoApp.Module;
using System.Linq;

namespace ToDoApp.ViewModel
{
    public class ItemQueryViewModel : ItemDetailViewModel
    {
        private readonly IToDoService toDoService;
        public ItemQueryViewModel(SingleChecklist checklist) : base(checklist)
        {
            toDoService = ServiceProvider.Instance.Get<IToDoService>();
        }

        public async void Query(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                SingleChecklist.ChecklistDetails = new System.Collections.ObjectModel.ObservableCollection<ChecklistDetail>();
            }
            else
            {
                var cks = await toDoService.GetToDoListDetailByTextAsync(content);
                if (cks != null)
                {
                    SingleChecklist.ChecklistDetails = new System.Collections.ObjectModel.ObservableCollection<ChecklistDetail>();
                    cks.ForEach(arg =>
                    {
                        SingleChecklist.ChecklistDetails.Add(arg);
                    });
                }
            }
        }
    }
}
