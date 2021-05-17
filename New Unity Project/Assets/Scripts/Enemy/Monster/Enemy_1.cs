/****************************************************
    文件：Enemy_1.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Enemy_1 : IEnemy 
{
    private Rigidbody2D _righiBody2D;

    void Start()
    {
        
        _righiBody2D = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        RanPos();

        _icon = Random.Range(1, 8);

    }

    void Update()
    {
        if (StaticData.PlayerBool)
        {
            var directionTo = (StaticData.PlayerPos.transform.position - transform.position).normalized;
            transform.up = -directionTo;
            transform.Translate(-Vector3.up * 2 * Time.deltaTime);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Bullet_1")
        {
            StaticData.Enemy_1 = gameObject;
            GameManager.Single.PushGameObjectToFactory(FactoryType.GameFactory, Paths.PLAYER1_BULLET, coll.gameObject);
            GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy, Paths.ENEMY_NUM + 1.ToString(), this.gameObject);
            GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_EXPLOCAL, this.transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            IconScore();
            Invoke("WaitColor", 0.3f);
           
        }
        if (coll.tag == "Bullet_2")
        {
            StaticData.Enemy_1 = gameObject;
            GameManager.Single.PushGameObjectToFactory(FactoryType.Bullet_2, Paths.PLAYER2_BULLET, coll.gameObject);
            GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy, Paths.ENEMY_NUM + 1.ToString(), this.gameObject);
            GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_EXPLOCAL, this.transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            IconScore();
            Invoke("WaitColor", 0.3f);

        }
        if (coll.tag == "Bullet_3")
        {
            StaticData.Enemy_1 = gameObject;
            GameManager.Single.PushGameObjectToFactory(FactoryType.Bullet_3, Paths.PLAYER3_BULLET, coll.gameObject);
            GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy, Paths.ENEMY_NUM + 1.ToString(), this.gameObject);
            GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_EXPLOCAL, this.transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            IconScore();
            Invoke("WaitColor", 0.3f);

        }
        if (coll.tag == "Player")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy, Paths.ENEMY_NUM + 1.ToString(), this.gameObject);
            GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_EXPLOCAL, this.transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
        }
    }

    public void  WaitColor()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }

  
   
    


}