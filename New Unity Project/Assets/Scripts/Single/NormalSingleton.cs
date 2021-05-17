/****************************************************
    文件：NormalSingleton.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class NormalSingleton<T> where T : class,new()
{
    private static T _single;
    public static T Single
    {
        get
        {
            if (_single == null)
            {
                T t = new T();
                _single = t;
            }
            return _single;
        }
    }
}