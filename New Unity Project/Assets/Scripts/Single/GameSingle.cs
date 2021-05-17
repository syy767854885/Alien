/****************************************************
    文件：LoadSingleton.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class GameSingle<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _single;

    public static T Single
    {
        get
        {
            if (_single == null)
            {
                //_single = FindObjectOfType<T>();
                //if (_single == null)
                //{
                //    Debug.LogError(message: "场景中未找到类的对象，类名为:" + typeof(T).Name);
                //}
                //获取这个类的名字，并且创建为gameobject
                var go = new GameObject(typeof(T).Name);

                //不要删除这个对象
                DontDestroyOnLoad(go);
                //添加这个类的脚本
                go.AddComponent<AudioSource>();
                go.AddComponent<AudioSource>();
                _single = go.AddComponent<T>();


            }
            return _single;
        }
    }
}