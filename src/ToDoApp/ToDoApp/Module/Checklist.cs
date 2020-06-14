using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Module
{
    public class Checklist
    {
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 字体图标代码
        /// </summary>
        public string IconFont { get; set; }
      
        /// <summary>
        /// 颜色
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// 明细统计的数量
        /// </summary>
        public int Count { get; set; }
    }
}
