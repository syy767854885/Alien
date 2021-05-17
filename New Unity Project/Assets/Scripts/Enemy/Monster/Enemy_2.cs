/****************************************************
    文件：Enemy_1.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Enemy_2 : IEnemy 
{
    void OnEnable()
    {
        RanPos();

    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Bullet_1")
        {
            StaticData.Enemy_1 = gameObject;
            GameManager.Single.PushGameObjectToFactory(FactoryType.GameFactory, Paths.PLAYER1_BULLET, coll.gameObject);
            GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy, Paths.ENEMY_NUM + 2.ToString(), this.gameObject);
            GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_EXPLOCAL, this.transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            Invoke("WaitColor", 0.3f);

        }
    }
    public void WaitColor()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }

}