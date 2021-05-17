/****************************************************
    文件：Boom_3.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Boom_3 : MonoBehaviour 
{
    
    void OnEnable()
    {
        transform.position = StaticData.Enemy_3.transform.position;
        Invoke("BoomFalse", 0.5f);
    }

    public void BoomFalse()
    {
        GameManager.Single.PushGameObjectToFactory(FactoryType.BoomFactory, Paths.BOOM_3, this.gameObject);
    }

    
}