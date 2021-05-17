/****************************************************
    文件：Enemy_Air_3.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Enemy_Air_3 : MonoBehaviour 
{
    private int _randAir;

    private Transform _air1;
    private Transform _air2;
    private Transform _air3;

    void Start()
    {
        _air1 = transform.Find("Air_1");
        _air2 = transform.Find("Air_2");
        _air3= transform.Find("Air_3");
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        _randAir = Random.Range(1, 4);
        if (coll.tag == "Air")
        {
            switch (_randAir)
            {
                case 1:
                    GameManager.Single.GetGameObjectResource(FactoryType.Enemy_3, Paths.ENEMY_3, _air1);
                    break;
                case 2:
                    GameManager.Single.GetGameObjectResource(FactoryType.Enemy_3, Paths.ENEMY_3, _air1);
                    break;
                case 3:
                    GameManager.Single.GetGameObjectResource(FactoryType.Enemy_3, Paths.ENEMY_3, _air1);
                    break;
            }

        }
       
    }
}