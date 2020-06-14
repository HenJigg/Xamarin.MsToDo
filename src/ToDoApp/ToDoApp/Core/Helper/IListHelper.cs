using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoApp.Core.Helper
{
    public static class IListHelper
    {

        /// <summary>
        /// 全局的List<T> 转换  ObservableCollection<T> 的扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> from)
        {
            ObservableCollection<T> to = new ObservableCollection<T>();
            foreach (var f in from)
            {
                to.Add(f);
            }
            return to;
        }
    }
}
