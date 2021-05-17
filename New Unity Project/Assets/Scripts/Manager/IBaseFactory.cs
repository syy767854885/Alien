/****************************************************
    文件：IBaseFactory.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public interface IBaseFactory
{
    GameObject GetItem(string itemName,Transform trans);

    void PushItem(string itemName, GameObject item);

    GameObject GetItemInstan(string itemName, Transform trans);
}