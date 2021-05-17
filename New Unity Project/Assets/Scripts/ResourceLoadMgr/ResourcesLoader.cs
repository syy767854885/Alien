/****************************************************
    文件：ResourcesLoader.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class ResourcesLoader 
{
    public GameObject ResourceLoaderUIGameObject(string path,Transform trans)
    {
        GameObject obj = Resources.Load<GameObject>(path);
        GameObject go = Object.Instantiate(obj, trans);
        return go;
    }

    public T[] ResourceLoadAll<T>(string path) where T:Object
    {
        T[] sprites = Resources.LoadAll<T>(path);
        return sprites;
    }
}