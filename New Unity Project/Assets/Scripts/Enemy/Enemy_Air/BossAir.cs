/****************************************************
    文件：BossAir.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class BossAir : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Air")
        {
            GameManager.Single.GetGameObjectResource(FactoryType.BossPrefab, Paths.Boss, transform);

        }

    }

}