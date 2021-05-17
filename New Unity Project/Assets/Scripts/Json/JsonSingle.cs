/****************************************************
    文件：JsonSingle.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSingle : NormalSingleton<JsonSingle>
{
    public Dictionary<string, Dictionary<string, int>> PlayerJsonData  = new Dictionary<string, Dictionary<string, int>>();
    
}