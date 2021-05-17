/****************************************************
    文件：InitBind.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using LitJson;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

public class InitBind
{
    public void Init()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(PrefabBind));
        Type[] types = assembly.GetExportedTypes();

        foreach (Type type in types)
        {
            //true用来表示是否可以继承
            foreach (Attribute attribute in Attribute.GetCustomAttributes(type, true))
            {
                if (attribute is PrefabBind)
                {
                    PrefabBind data = attribute as PrefabBind;
                    //存储脚本的信息与类型
                    BindUtil.BindSave(data, type);
                }
            }
        }
    }

    
    //private void SaveByJson()
    //{
    //    string filePath = Application.dataPath + "/Resources/Json" + "/InitPlaneJs.json";
    //    //利用JsonMapper将信息类转化为Json格式的字符串
    //    string saveJsonStr = JsonMapper.ToJson(initPlaneJs);
    //    //创建一个文件流去将字符串写入一个文件夹中
    //    StreamWriter sw = new StreamWriter(filePath);
    //    sw.WriteLine(saveJsonStr);
    //    sw.Close();
    //}
    //读取武器属性信息
    //private void LoadWeaponProperty()
    //{
    //    PlayerS playersLoad = new PlayerS();
    //    //weaponProperties = new List<WeaponProperties>();
    //    string filePath = Application.streamingAssetsPath + "/InitPlaneJs.json";
    //    //判断是否存在这个文件
    //    if (File.Exists(filePath))
    //    {
    //        //读取文件流
    //        StreamReader sr = new StreamReader(filePath);
    //        //读完
    //        string jsonStr = sr.ReadToEnd();
    //        //关闭文件流
    //        sr.Close();
    //        //给列表赋值
    //        playersLoad = JsonMapper.ToObject<PlayerS>(jsonStr);
    //       // Debug.Log(playersLoad.playerJsons[0].DataPlayer["攻击"]);
    //    }  
    //}
}