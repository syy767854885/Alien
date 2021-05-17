/****************************************************
    文件：PlayerJson.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJson 
{
    public string Name;
    public Dictionary<string, int> DataPlayer = new Dictionary<string, int>();
    
}


public class PlayerS
{
    public PlayerJson[] playerJsons = new PlayerJson[] { };
}