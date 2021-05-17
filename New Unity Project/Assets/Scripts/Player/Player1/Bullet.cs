/****************************************************
    文件：Bullet.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Bullet : MonoBehaviour 
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.GameFactory, Paths.PLAYER1_BULLET, gameObject);
        }
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * 15);
    }
}