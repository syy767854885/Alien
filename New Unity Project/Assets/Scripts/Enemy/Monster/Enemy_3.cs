/****************************************************
    文件：Enemy_1.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;

public class Enemy_3 : IEnemy 
{
    private int _Enemy3Hp;
    private float _speed;
    private GameObject _firGun;
    private GameObject _fireGunRight;
    private GameObject _fireGunleft;
    private bool _ve;
    private string tagString;

   
    void Awake()
    {
        _ve = true;
       _speed = 0.3f;
        _firGun = transform.Find("FireGun").gameObject;
        _fireGunRight = transform.Find("FireGunRight").gameObject;
        _fireGunleft = transform.Find("FireGunLeft").gameObject;
    }
    void OnEnable()
    {
        RanPos();
        _Enemy3Hp = 200;
        _icon = Random.Range(1, 3);
        StartCoroutine(LineFly());
        StartCoroutine(Shot());
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        tagString = coll.tag;
        StaticData.Enemy_3 = gameObject;
        if (coll.tag == "Bullet_1")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.GameFactory, Paths.PLAYER1_BULLET, coll.gameObject);
            _Enemy3Hp -= SwitchPlayerAttack();
            if (_Enemy3Hp <= 0)
            {
               
                GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy_3, Paths.ENEMY_3, this.gameObject);
                GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_3, this.transform);
                IconScore();
            }
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);

            Invoke("WaitColor", 0.05f);

        }
        if (coll.tag == "Bullet_2")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.Bullet_2, Paths.PLAYER2_BULLET, coll.gameObject);
            _Enemy3Hp -= SwitchPlayerAttack();
            if (_Enemy3Hp <= 0)
            {
               
                GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy_3, Paths.ENEMY_3, this.gameObject);
                GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_3, this.transform);
                IconScore();
            }
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);

            Invoke("WaitColor", 0.05f);

        }
        if (coll.tag == "Bullet_3")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.Bullet_3, Paths.PLAYER3_BULLET, coll.gameObject);
            _Enemy3Hp -= SwitchPlayerAttack();
            if (_Enemy3Hp <= 0)
            {

                GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy_3, Paths.ENEMY_3, this.gameObject);
                GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_3, this.transform);
                IconScore();
            }
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);

            Invoke("WaitColor", 0.05f);

        }
        if (coll.tag == "Player")
        {
            GameManager.Single.PushGameObjectToFactory(FactoryType.Enemy_3, Paths.ENEMY_3, this.gameObject);
            GameManager.Single.GetGameObjectResource(FactoryType.BoomFactory, Paths.BOOM_3, this.transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
        }
    }
    public void WaitColor()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }

    void Update()
    {
        
    }
    private void FirGun3()
    {
        GameManager.Single.GetGameObjectResource(FactoryType.Fire_3, Paths.FIRE_3, _firGun.transform);
       
        
    }
    public IEnumerator Shot()
    {
        while (true)
        {
           
                FirGun3();
          

            
            yield return new WaitForSeconds(1f);
        }

    }

   

    IEnumerator LineFly()
    {
        while (true)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
            yield return 0;
        }
    }



}