/****************************************************
    文件：ResourcesLoaderMgr.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class ResourcesLoaderMgr : NormalSingleton<ResourcesLoaderMgr>
{
    private ResourcesLoader _resourceload = new ResourcesLoader();
    public GameObject ResourceLoaderGameObject(string path, Transform trans)
    {
        return _resourceload.ResourceLoaderUIGameObject(path, trans);
    }

    public T[] ResourceLoadAll<T>(string path) where T : Object
    {
        return _resourceload.ResourceLoadAll<T>(path);
    }
}