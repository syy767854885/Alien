/****************************************************
    文件：Born.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;

public class Born : MonoBehaviour
{
    private Transform _born_1;
    private Transform _born_2;
    private Transform _born_3;
    public int _bordrandom;
    private int _enemyRandom;
    void Start()
    {
        StartCoroutine(EnmyShow());
    }

    IEnumerator EnmyShow()
    {
        while (true)
        {
            //GameManager.Single.GetGameObjectResource(FactoryType.Enemy, Paths.ENEMY_NUM + 1.ToString(), _born_1.transform);
            //Debug.Log(_born_1.position);
            _bordrandom = Random.Range(1, 4);
            StaticData.BorRan = _bordrandom;
            _enemyRandom = Random.Range(1, 2);
            
            switch (_bordrandom)
            {
                case 1:
                    GameManager.Single.GetGameObjectResource(FactoryType.Enemy, Paths.ENEMY_NUM + _enemyRandom, null);
                    break;
                case 2:
                    GameManager.Single.GetGameObjectResource(FactoryType.Enemy, Paths.ENEMY_NUM + +_enemyRandom, null);
                    break;
                case 3:
                    GameManager.Single.GetGameObjectResource(FactoryType.Enemy, Paths.ENEMY_NUM + +_enemyRandom, null);
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
        
    }


}