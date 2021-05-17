/****************************************************
    文件：BaseFactory.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class BaseFactory : IBaseFactory
{
    //对象池字典
    public static Dictionary<string, Stack<GameObject>> ObjectPoolDict = new Dictionary<string, Stack<GameObject>>();
    public void PushItem(string itemName, GameObject item)
    {
        //压栈后隐藏物体
        item.SetActive(false);
        //放入GameManager中
        //查看字典中有没有这个池子，进行放入
        if (ObjectPoolDict.ContainsKey(itemName))
        {
            ObjectPoolDict[itemName].Push(item);
        }
        else
        {
            Debug.Log("当前字典没有" + itemName + "的栈");
        }
    }

    //取实例
    public GameObject GetItem(string itemName,Transform trans)
    {

        GameObject itemGo = null;
        //查看对象池里面是否存在这个物体
        if (ObjectPoolDict.ContainsKey(itemName))//包含此对象
        {
            //池子里面没有物体了
            if (ObjectPoolDict[itemName].Count == 0)
            {
                itemGo = Resources.Load<GameObject>(itemName);
                Object.Instantiate(itemGo);
                if (trans != null)
                {
                    itemGo.transform.position = trans.position;
                }
                itemGo.SetActive(true);
            }
            else
            {
                //池子里面还有东西，从里面取出来
                itemGo = ObjectPoolDict[itemName].Pop();
                if (trans != null)
                {
                    itemGo.transform.position = trans.position;
                }
                //取出来后进行显示
                itemGo.SetActive(true);
            }
        }
        else//不包含此对象池
        {
            //新建一个字典对象池
            ObjectPoolDict.Add(itemName, new Stack<GameObject>());
            //在预制体里面创建对象，这个不是池子
            itemGo = Resources.Load<GameObject>(itemName);
            
            Object.Instantiate(itemGo);
           
            if (trans != null)
            {
                itemGo.transform.position = trans.position;
            }
            
            //复制生成预制体
            itemGo.SetActive(true);
        }

        if (itemGo == null)
        {
            Debug.Log(itemName + "的实例获取失败");
        }
        return itemGo;
    }


    public GameObject GetItemInstan(string itemName, Transform trans)
    {

        GameObject itemGo = null;
        //查看对象池里面是否存在这个物体
        if (ObjectPoolDict.ContainsKey(itemName))//包含此对象
        {
            //池子里面没有物体了
            if (ObjectPoolDict[itemName].Count == 0)
            {
                itemGo = Resources.Load<GameObject>(itemName);
                Object.Instantiate(itemGo, trans.position, trans.rotation);
               
                itemGo.SetActive(true);
            }
            else
            {
                //池子里面还有东西，从里面取出来
                itemGo = ObjectPoolDict[itemName].Pop();
               
                //取出来后进行显示
                itemGo.SetActive(true);
            }
        }
        else//不包含此对象池
        {
            //新建一个字典对象池
            ObjectPoolDict.Add(itemName, new Stack<GameObject>());
            //在预制体里面创建对象，这个不是池子
            itemGo = Resources.Load<GameObject>(itemName);

            Object.Instantiate(itemGo,trans.position,trans.rotation);

           

            //复制生成预制体
            itemGo.SetActive(true);
        }

        if (itemGo == null)
        {
            Debug.Log(itemName + "的实例获取失败");
        }
        return itemGo;
    }

    public static void ClearDict()
    {
        ObjectPoolDict.Clear();
    }


}