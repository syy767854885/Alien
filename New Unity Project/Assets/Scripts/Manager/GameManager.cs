/****************************************************
    文件：GameManager.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class GameManager : NormalSingleton<GameManager>
{
    
    public FactoryManager factoryManager = new FactoryManager();
    //获取audioClip资源
    public AudioClip GetAudioClip(string resourcePath)
    {
        return factoryManager.audioClipFactory.GetSingleResources(resourcePath);
    }
    public GameObject GetGameObjectResource(FactoryType factoryType, string resourcePath, Transform trans)
    {
        return factoryManager.factoryDict[factoryType].GetItem(resourcePath, trans);
    }
    //Boss
    public GameObject GetGameObjectResourceInstan(FactoryType factoryType, string resourcePath, Transform trans)
    {
        return factoryManager.factoryDict[factoryType].GetItemInstan(resourcePath, trans);
    }
    //将游戏物体放回对象池
    public void PushGameObjectToFactory(FactoryType factoryType, string resourcePath, GameObject itemGo)
    {
        factoryManager.factoryDict[factoryType].PushItem(resourcePath, itemGo);
    }
}