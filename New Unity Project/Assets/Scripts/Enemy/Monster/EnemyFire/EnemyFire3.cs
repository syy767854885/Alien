/****************************************************
    文件：EnemyFire3.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class EnemyFire3 : MonoBehaviour 
{
    void OnEnable()
    {
       gameObject.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(-Vector2.up * 3);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DownWall")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.Fire_3, Paths.FIRE_3,this.gameObject);
        }
        if (other.tag == "Player")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.Fire_3, Paths.FIRE_3, this.gameObject);
            GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_EXPLOCAL, this.transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
        }
    }
}