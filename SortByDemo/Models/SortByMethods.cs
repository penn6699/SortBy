using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

/// <summary>
/// List<T> 函数
/// </summary>
public static class SortByMethodExtension
{
    /// <summary>
    /// 获取类公共字段/属性的值
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    private static object GetObjectValue<T>(T obj, string key) where T : class
    {
        Type type = obj.GetType();
        FieldInfo fieldInfo = type.GetField(key);
        if (fieldInfo != null)
        {
            return fieldInfo.GetValue(obj);
        }
        PropertyInfo propertyInfo = type.GetProperty(key);
        if (propertyInfo != null)
        {
            return propertyInfo.GetValue(obj);
        }
        return null;
    }
    /// <summary>
    /// 排序信息
    /// </summary>
    private class ListSortByInfo
    {
        public string sortName = null;
        public string sortOrder = null;
    }
    /// <summary>
    /// 排序
    /// </summary>
    /// <typeparam name="T">泛型类</typeparam>
    /// <param name="list">List</param>
    /// <param name="OrderBy">排序字符串。像SQL 的order by 后面的内容。如：“AA”,“AA asc”，“AA desc,BB”</param>
    /// <returns></returns>
    public static List<T> SortBy<T>(this List<T> list, string OrderBy) where T : class
    {
        //少于2个元素，不作排序
        if (list.Count < 2)
        {
            return list;
        }

        
        T row = list[0];
        Type type = row.GetType();

        //收集需要排序的公共字段或公共属性
        List<ListSortByInfo> OrderByInfoList = new List<ListSortByInfo>();
        if (!string.IsNullOrEmpty(OrderBy))
        {
            string[] OrderBys = OrderBy.Trim().Split(new char[] { ',' });
            for (int ind = 0; ind < OrderBys.Length; ind++)
            {
                string _OrderBy = OrderBys[ind].Trim();
                string sortName = _OrderBy.Split(new char[] { ' ' })[0].Trim();
                string sortOrder = _OrderBy.Replace(sortName + " ", "").Trim().ToLower();
                if (!string.IsNullOrEmpty(sortName) && (type.GetProperty(sortName) != null || type.GetField(sortName) != null))
                {
                    OrderByInfoList.Add(new ListSortByInfo
                    {
                        sortName = sortName,
                        sortOrder = sortOrder
                    });
                }
            }
        }

        //排序处理
        if (OrderByInfoList.Count > 0)
        {
            //处理第一个排序
            ListSortByInfo sort01 = OrderByInfoList[0];
            var sortData = sort01.sortOrder == "desc" ? list.OrderByDescending(row2 => GetObjectValue(row2, sort01.sortName))
                : list.OrderBy(row2 => GetObjectValue(row2, sort01.sortName));

            if (OrderByInfoList.Count > 1)
            {
                for (int ind = 1; ind < OrderByInfoList.Count; ind++)
                {
                    ListSortByInfo sort02 = OrderByInfoList[ind];
                    sortData = sort02.sortOrder == "desc" ? sortData.ThenByDescending(row2 => GetObjectValue(row2, sort02.sortName))
                        : sortData.ThenBy(row2 => GetObjectValue(row2, sort02.sortName));
                }
            }

            return sortData.ToList();

        }
        return list;
    }
}
