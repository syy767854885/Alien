/****************************************************
    文件：ExPressTools.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.UI;

public static class ExPressTools 
{
    public static void ButtonAction(this Transform trans,string buttonPath, Action action)
    {
        var obj = trans.Find(buttonPath);
        Button button = obj.GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("没有找到Button组件");
        }
        else
        {
            button.onClick.AddListener(()=>action());
        }
    }
}