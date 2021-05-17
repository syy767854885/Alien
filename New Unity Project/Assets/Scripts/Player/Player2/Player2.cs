/****************************************************
    文件：Player.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour 
{
    private float _speed = 2;
    private float speedPlayer = 2500;
    private Rigidbody2D playerRig;
    private GameObject bullet;
    public Transform Gun1;

    private float attackSpeed;
    void Start()
    {
        StaticData.PlayerBool = true;
        playerRig = transform.GetComponent<Rigidbody2D>();
        ResourcesLoaderMgr.Single.ResourceLoaderGameObject(Paths.JOYSTICK, GameObject.Find("Canva").transform);
        Gun1 = transform.Find("Gun");
        StartCoroutine(Shot());
        StaticData.PlayerPos = transform.gameObject;
        attackSpeed = 1 - PlayerPrefs.GetInt("Player2Speed") * 0.01f;
    }

    void Update()
    {
        playerRig.AddForce(new Vector2(StaticData.inputValue.x * speedPlayer * Time.deltaTime, StaticData.inputValue.y * speedPlayer * Time.deltaTime));
        if (StaticData._bossTrue)
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }
        
        StaticData.PlayerPos = transform.gameObject;
        
    }
    public  IEnumerator Shot()
    {
        attackSpeed = 1 - PlayerPrefs.GetInt("Player2Speed") * 0.01f;
        while (true)
        {
            bullet = GameManager.Single.GetGameObjectResource(FactoryType.Bullet_2, Paths.PLAYER2_BULLET, Gun1);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ZIDAN));
            //bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2005 * Time.deltaTime));
            yield return new WaitForSeconds(attackSpeed);

        }
        
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            StaticData.Hp -= 5;
            EventCenter.Broadcast(EventType.ScoreType);

        }
        if (coll.tag == "Enemy3")
        {
            StaticData.Hp -= 10;
            EventCenter.Broadcast(EventType.ScoreType);

        }
        if (coll.tag == "Bullet3")
        {
            StaticData.Hp -= 8;
            EventCenter.Broadcast(EventType.ScoreType);

        }
        if (StaticData.PlyaerHP == 0)
        {
            //EventCenter.Broadcast(EventType.GameOver);
            JsonSingle.Single.PlayerJsonData.Clear();
            BaseFactory.ClearDict();
            StaticData.PlayerBool = false;
            EventCenter.m_EventTable.Clear();
            SceneManager.LoadSceneAsync(0);
        }
    }

    public void InvokeLoad()
    {
        
    }
}