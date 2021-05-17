/****************************************************
    文件：PrefabBind.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：用于获取脚本信息
*****************************************************/

using System;
using UnityEngine;
[AttributeUsage(AttributeTargets.Class)]
public class PrefabBind : Attribute
{
    public string Path { get; private set; }
    public int Priority { get; private set; }
    public PrefabBind(string path, int priority = 100)
    {
        Path = path;
        Priority = priority;
    }
}