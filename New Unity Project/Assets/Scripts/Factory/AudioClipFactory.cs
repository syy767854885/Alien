/****************************************************
    文件：AudioClipFactory.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class AudioClipFactory 
{
    //创建音频字典
    protected Dictionary<string, AudioClip> factoryDict = new Dictionary<string, AudioClip>();
    public AudioClip GetSingleResources(string resourcePath)
    {
        AudioClip itemGo = null;
       

        if (factoryDict.ContainsKey(resourcePath))
        {
            //如果有这个值，就获得其音频
            itemGo = factoryDict[resourcePath];
        }
        else
        {
            //如果没有则去Resources加载
            itemGo = Resources.Load<AudioClip>(resourcePath);
            //添加入字典中
            factoryDict.Add(resourcePath, itemGo);
        }
        if (itemGo == null)
        {
            //
            Debug.Log(resourcePath + "的资源获取失败,失败路径为: " + resourcePath);
        }
        //返还音频资源
        return itemGo;
    }
}