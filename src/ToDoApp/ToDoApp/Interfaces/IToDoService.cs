using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Module;

namespace ToDoApp.Interfaces
{
    public interface IToDoService
    {
        /// <summary>
        /// 获取首页数据列表
        /// </summary>
        /// <returns></returns>
        Task<List<Checklist>> GetToDoListAsync();

        /// <summary>
        /// 获取清单明细的数据列表
        /// </summary>
        /// <returns></returns>
        Task<SingleChecklist> GetToDoListDetailAsync(string id);

        /// <summary>
        /// 根据内容搜索结果
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        Task<List<ChecklistDetail>> GetToDoListDetailByTextAsync(string text);

        /// <summary>
        /// 首页添加新的清单
        /// </summary>
        /// <param name="checklist"></param>
        /// <returns></returns>
        Task<bool> AddToDoGroupAsync(Checklist checklist);

        /// <summary>
        /// 删除首页的清单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteToDoGroupByIdAsync(string id);

        /// <summary>
        /// 删除明细表当中的书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteToDoInfoByIdAsync(string id);

        /// <summary>
        /// 更新首页清单的名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> UpdateToDoGroupNameAsync(string id, string name);

        /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<bool> AddToDoDetailAsync(string id, ChecklistDetail detail);

        /// <summary>
        /// 是否删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<bool> UpdateDeleteStatus(string id, bool status);

        /// <summary>
        /// 是否收藏
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<bool> UpdateFavoriteStatus(string id, bool status);

    }
}
