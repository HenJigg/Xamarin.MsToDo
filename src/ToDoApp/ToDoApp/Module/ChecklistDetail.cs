using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Module
{
    public partial class ChecklistDetail
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 关联的外键ID
        /// </summary>
        public string ChecklistId { get; set; }

        /// <summary>
        /// 明细内容
        /// </summary>
        public string Content { get; set; }

    }

    public partial class ChecklistDetail : ViewModelBase
    {
        private bool isDeleted;
        private bool isFavorite;

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
