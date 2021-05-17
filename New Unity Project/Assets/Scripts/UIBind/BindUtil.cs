/****************************************************
    文件：BindUtil.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class BindUtil
{
   
    protected static Dictionary<string, List<Type>> _uiPrefabDic = new Dictionary<string, List<Type>>();
    protected static Dictionary<Type, int> _sizePriority = new Dictionary<Type, int>();
    public static void BindSave(PrefabBind data,Type prefabtype)
    {
        string path = data.Path;
        //若是第一次获取这个路径，则添加一个新元素
        if (!_uiPrefabDic.ContainsKey(path))
        {
            _uiPrefabDic.Add(path, new List<Type>());
        }
        //再将这个路径的元素添加入List中
        if (!_uiPrefabDic[path].Contains(prefabtype))
        {
            _uiPrefabDic[path].Add(prefabtype);
            //存储的是脚本与data.Priority的大小
            _sizePriority.Add(prefabtype, data.Priority);
            _uiPrefabDic[path].Sort(new BindPriorityComparer());
        }
        
        
    }

    public static List<Type> BindGet(string path)
    {
        if (_uiPrefabDic.ContainsKey(path))
        {
            return _uiPrefabDic[path];
        }
        else
        {
            Debug.LogError("没有这个预制体的路径: " + path);
            return null;
        }
    }



    //用于比较大小的类
    public class BindPriorityComparer : IComparer<Type>
    {
        public int Compare(Type x, Type y)
        {
            if (x == null)
            {
                return 1;
            }
            if (y == null)
            {
                return -1;
            }
            //若是负数则不交换，若是正数则交换
            //通过比对的另一个字典中的值来获取Priority从而达到交换这个字典中的List顺序，从而改变加载顺序
            return _sizePriority[x] - _sizePriority[y];
        }
    }

}

