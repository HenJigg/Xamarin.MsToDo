using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using ToDoApp.Module;

namespace ToDoApp.Core
{
    public class Constants
    {
        /// <summary>
        /// 本地数据库脚本路径
        /// </summary>
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ToDo.db");
            }
        }

        public static async void InitAsync(ToDoContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (!context.Checklists.Any())
                {
                    await context.Checklists.AddRangeAsync(new Checklist[]
                    {
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe635", Title = "我的一天", BackColor = "#218868", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe6b6", Title = "重要", BackColor = "#EE3B3B", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe6e1", Title = "已计划日程", BackColor = "#218868", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe614", Title = "已分配给我", BackColor = "#EE3B3B", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe755", Title = "任务", BackColor = "#218868", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe63b", Title = "购物清单", BackColor = "#009ACD", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe63b", Title = "杂货清单", BackColor = "#009ACD", },
                   new Checklist() { Id=Guid.NewGuid().ToString(), IconFont = "\xe63b", Title = "待办事项", BackColor = "#009ACD", },
                });
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
