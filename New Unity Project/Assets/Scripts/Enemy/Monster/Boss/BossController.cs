/****************************************************
    文件：BossController.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour 
{
    private GameObject[] _cannon_1;
    private GameObject[] _bullet_1;

    private GameObject _left;
    private GameObject _right;
    private GameObject _bullet_2;

    public float rotationZ;

    private GameObject _middle;
    private GameObject _bullet_3;


    private bool vect = true;

    private int _fire2Num = 0;
    private bool fire2Bool = true;


    private int _fire3Num = 0;

    private Rigidbody2D rigi2D;


    private float _bossHp = 500;
    private float _attackDps;
    void Start()
    {
        fire2Bool = true;
        switch (StaticData.Order)
        {
            case 0:
                _attackDps = PlayerPrefs.GetInt("Player1Attack");
                break;
            case 1:
                _attackDps = PlayerPrefs.GetInt("Player2Attack");
                break;
            case 2:
                _attackDps = PlayerPrefs.GetInt("Player3Attack");
                break;
        }
        _bossHp = 100;
        this.transform.position =new Vector3(0, 100, -2);
        _cannon_1 = new GameObject[13];
        _bullet_1 = new GameObject[13];
        rotationZ = 150;
        _left = transform.Find("Left").gameObject;
        _right = transform.Find("Right").gameObject;

        _middle = transform.Find("Middle").gameObject;

        
        InvokeRepeating("fire_1", 1f, 2f);
        InvokeRepeating("fire_2", 2f, 0.3f);
        InvokeRepeating("fire_3", 2f, 1f);
        //_cannon_1 = transform.Find("Cannon_1").gameObject;
        //_bullet_1 = Resources.Load<GameObject>(Paths.BOSS_FIRE);
        //_bullet_1 = Instantiate(_bullet_1, _cannon_1.transform.position, _cannon_1.transform.rotation);
        //_bullet_1.GetComponent<Rigidbody2D>().velocity = _cannon_1.transform.TransformDirection(Vector2.up * 2f);
    }
    
    void Update()
    {
        if (vect == true)
        {
            transform.Translate(Vector3.left * 2 * Time.deltaTime);
            if (transform.position.x < -2)
            {
                vect = false;
            }
        }

        if (vect == false)
        {
            transform.Translate(-Vector3.left * 2 * Time.deltaTime);
            if (transform.position.x > 2)
            {
                vect = true;
            }
        }
 
    }



    private void fire_1()
    {
        for (int i = 1; i < 13; i++)
        {
            string cannon = "Cannon_" + i.ToString();
            _cannon_1[i] = transform.Find(cannon).gameObject;

            _bullet_1[i] = Resources.Load<GameObject>(Paths.BOSS_FIRE);
            _bullet_1[i] = Instantiate(_bullet_1[i], _cannon_1[i].transform.position, _cannon_1[i].transform.rotation);
            _bullet_1[i].GetComponent<Rigidbody2D>().velocity = _cannon_1[i].transform.TransformDirection(Vector2.up * 4f);
        }
    }



    private void fire_2()
    {
        if (fire2Bool)
        {
            _left.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            _bullet_2 = Resources.Load<GameObject>(Paths.BOSS_FIRE_2);
            _bullet_2 = Instantiate(_bullet_2, _left.transform.position, _left.transform.rotation);
            _bullet_2.GetComponent<Rigidbody2D>().velocity = _left.transform.TransformDirection(Vector2.up * 4f);
            
            _right.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -rotationZ);
            _bullet_2 = Resources.Load<GameObject>(Paths.BOSS_FIRE_2);
            _bullet_2 = Instantiate(_bullet_2, _right.transform.position, _right.transform.rotation);
            _bullet_2.GetComponent<Rigidbody2D>().velocity = _right.transform.TransformDirection(Vector2.up * 4f);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.BOSSFIRE2_AUDIO));
            rotationZ += 5;
            _fire2Num++;
            if (rotationZ == 210)
            {
                rotationZ = 150;
            }
            if (_fire2Num == 10)
            {
                fire2Bool = false;
                _fire2Num = 0;
            }
        }
           
        
        
    }

    private void fire_3()
    {
        if (fire2Bool == false)
        {
            _middle.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            _bullet_3 = Resources.Load<GameObject>(Paths.BOSS_FIRE_3);
            _bullet_3 = Instantiate(_bullet_3, _middle.transform.position, _middle.transform.rotation);
            _bullet_3.GetComponent<Rigidbody2D>().velocity = _middle.transform.TransformDirection(Vector2.up * 4f);
            _fire3Num++;
            if (_fire3Num == 4)
            {
                fire2Bool = true;
                _fire3Num = 0;
            }
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
    }
    //public Transform GunKou;
    //public Rigidbody2D bossbull;
    //void Start()
    //{
    //    Rigidbody2D bulletcolone;
    //    bulletcolone = (Rigidbody2D)Instantiate(bossbull, GunKou.position, GunKou.rotation);
    //    bulletcolone.velocity = transform.TransformDirection(Vector2.up * 2f);
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet_1" || other.tag == "Bullet_2"||other.tag == "Bullet_3")
        {
            switch (other.tag)
            {
                case "Bullet_1":
                    GameManager.Single.PushGameObjectToFactory(FactoryType.GameFactory, Paths.PLAYER1_BULLET, other.gameObject);
                    break;
                case "Bullet_2":
                    GameManager.Single.PushGameObjectToFactory(FactoryType.Bullet_2, Paths.PLAYER2_BULLET, other.gameObject);
                    break;
                case "Bullet_3":
                    GameManager.Single.PushGameObjectToFactory(FactoryType.Bullet_3, Paths.PLAYER3_BULLET, other.gameObject);
                    break;
            }

            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
            _bossHp -= _attackDps * 0.1f;
            if (_bossHp <= 0)
            {
                Destroy(this.gameObject);
                //EventCenter.Broadcast(EventType.PassUI);
                JsonSingle.Single.PlayerJsonData.Clear();
                BaseFactory.ClearDict();
                StaticData.PlayerBool = false;
                EventCenter.m_EventTable.Clear();
                SceneManager.LoadSceneAsync(0);
            }
            transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            transform.Find("Boss2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
            Invoke("WaitColor", 0.05f);
        }
        
    }

    public void WaitColor()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        transform.Find("Boss2").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }
    public void InvokeLoad()
    {
        SceneManager.LoadSceneAsync(1);
    }
}