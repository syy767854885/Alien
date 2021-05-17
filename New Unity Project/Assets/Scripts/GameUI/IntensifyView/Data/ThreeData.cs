/****************************************************
    文件：ThreeData.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using LitJson;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ThreeData : MonoBehaviour
{
    //1
    private Text _attackTxt;
    private Text _diamondTxt;
    private Slider _attackSlider;
    private Button _attackButton;
    //2
    private Text _attackSpeedTxt;
    private Text _SpeedIconTxt;
    private Slider _attackSpeedSlider;
    private Button _attackSpeedButton;
    //3
    private Text _lifeTxt;
    private Text _lifeIconTxt;
    private Slider _lifeSlider;
    private Button _lifeButton;
    //4
    private Text _coinNum;
    private Text _diamondNum;
    private bool LeftAndRight = true;
    void Start()
    {
        
        //1
        _attackTxt = transform.Find("AttackTxt").GetComponent<Text>();
        _diamondTxt = transform.Find("DiamondNum").GetComponent<Text>();
        _attackSlider = transform.Find("AttackSlider").GetComponent<Slider>();
        _attackButton = transform.Find("AttackButton").GetComponent<Button>();
        //2
        _attackSpeedTxt = transform.Find("AttackSpeedTxt").GetComponent<Text>();
        _SpeedIconTxt = transform.Find("AttackSpeedIconNum").GetComponent<Text>();
        _attackSpeedSlider = transform.Find("AttackSpeedSlider").GetComponent<Slider>();
        _attackSpeedButton = transform.Find("AttackSpeedButton").GetComponent<Button>();
        //3
        _lifeTxt = transform.Find("LifeTxt").GetComponent<Text>();
        _lifeIconTxt = transform.Find("LifeIconNum").GetComponent<Text>();
        _lifeSlider = transform.Find("LifeSlider").GetComponent<Slider>();
        _lifeButton = transform.Find("LifeButton").GetComponent<Button>();
        //4
        _coinNum = transform.Find("CoinNum").GetComponent<Text>();
        _diamondNum = transform.Find("DiamondNumTop").GetComponent<Text>();
       
        ChangData();
        EventCenter.AddListener(EventType.JsonPlayerData, ChangData);
    }
  
    public void ChangData()
    {
        _coinNum.text =  PlayerPrefs.GetInt("Icon").ToString();
        _diamondNum.text = PlayerPrefs.GetInt("Diamond").ToString();
        switch (StaticData.Order)
        {
            case 0:
                PlayerOne();
                break;
            case 1:
                PlayerTwo();
                break;
            case 2:
                PlayerThree();
                break;
        }
        //SetJsonThreeData();
    }
    private void Update()
    {
        ChangData();
    }
    //

    private void PlayerOne()
    {
        _attackTxt.text = PlayerPrefs.GetInt("Player1Attack").ToString();
        _diamondTxt.text = PlayerPrefs.GetInt("Player1Diamond").ToString();
        _attackSlider.value = PlayerPrefs.GetInt("Player1Attack") * 0.01f;

        _attackSpeedTxt.text = PlayerPrefs.GetInt("Player1Speed").ToString();
        _SpeedIconTxt.text = PlayerPrefs.GetInt("Player1Icon").ToString();
        _attackSpeedSlider.value = PlayerPrefs.GetInt("Player1Speed") * 0.01f;

        _lifeTxt.text = PlayerPrefs.GetInt("Player1Life").ToString();
        _lifeIconTxt.text = PlayerPrefs.GetInt("Player1Icon").ToString();
        _lifeSlider.value = PlayerPrefs.GetInt("Player1Life") * 0.01f;
        if (LeftAndRight)
        {
            _attackButton.onClick.AddListener(() => AttackButtonPlayer1());
            _attackSpeedButton.onClick.AddListener(() => SpeedButtonPlayer1());
            _lifeButton.onClick.AddListener(() => LifeButtonPlayer1());
            LeftAndRight = false;
        }
        
    }
    private void PlayerTwo()
    {
        _attackTxt.text = PlayerPrefs.GetInt("Player2Attack").ToString();
        _diamondTxt.text = PlayerPrefs.GetInt("Player2Diamond").ToString();
        _attackSlider.value = PlayerPrefs.GetInt("Player2Attack") * 0.01f;

        _attackSpeedTxt.text =  PlayerPrefs.GetInt("Player2Speed").ToString();
        _SpeedIconTxt.text = PlayerPrefs.GetInt("Player2Icon").ToString();
        _attackSpeedSlider.value =  PlayerPrefs.GetInt("Player2Speed") * 0.01f;

        _lifeTxt.text = PlayerPrefs.GetInt("Player2Life").ToString();
        _lifeIconTxt.text = PlayerPrefs.GetInt("Player2Icon").ToString();
        _lifeSlider.value = PlayerPrefs.GetInt("Player2Life") * 0.01f;
    
    }

    private void PlayerThree()
    {
        _attackTxt.text = PlayerPrefs.GetInt("Player3Attack").ToString();
        _diamondTxt.text = PlayerPrefs.GetInt("Player3Diamond").ToString();
        _attackSlider.value = PlayerPrefs.GetInt("Player3Attack") * 0.01f;

        _attackSpeedTxt.text = PlayerPrefs.GetInt("Player3Speed").ToString();
        _SpeedIconTxt.text = PlayerPrefs.GetInt("Player3Icon").ToString();
        _attackSpeedSlider.value = PlayerPrefs.GetInt("Player3Speed") * 0.01f;

        _lifeTxt.text = PlayerPrefs.GetInt("Player3Life").ToString();
        _lifeIconTxt.text = PlayerPrefs.GetInt("Player3Icon").ToString();
        _lifeSlider.value = PlayerPrefs.GetInt("Player3Life") * 0.01f;
     
    }

    private void AttackButtonPlayer1()
    {
        AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.UI_AUDIO));
        if (StaticData.Order == 0)
        {
            if (PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Player1Diamond") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player1Attack", PlayerPrefs.GetInt("Player1Attack") + 2);
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Player1Diamond"));
            }
            //缓存的钻石
            _diamondNum.text = PlayerPrefs.GetInt("Diamond").ToString();
            _attackTxt.text = PlayerPrefs.GetInt("Player1Attack").ToString();
            _attackSlider.value = PlayerPrefs.GetInt("Player1Attack") * 0.01f;

        }
        if (StaticData.Order == 1)
        {
            if (PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Player2Diamond") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player2Attack", PlayerPrefs.GetInt("Player2Attack") + 2);
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Player2Diamond"));
            }
            //缓存的钻石
            _diamondNum.text = PlayerPrefs.GetInt("Diamond").ToString();
            _attackTxt.text = PlayerPrefs.GetInt("Player2Attack").ToString();
            _attackSlider.value = PlayerPrefs.GetInt("Player2Attack") * 0.01f;

        }
        if (StaticData.Order == 2)
        {
            if (PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Player3Diamond") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player3Attack", PlayerPrefs.GetInt("Player3Attack") + 2);
                PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") - PlayerPrefs.GetInt("Player3Diamond"));
            }
            //缓存的钻石
            _diamondNum.text = PlayerPrefs.GetInt("Diamond").ToString();
            _attackTxt.text = PlayerPrefs.GetInt("Player3Attack").ToString();
            _attackSlider.value = PlayerPrefs.GetInt("Player3Attack") * 0.01f;
        }

    }
    

    private void SpeedButtonPlayer1()
    {
        AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.UI_AUDIO));
        if (StaticData.Order == 0)
        {
            if (PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player1Icon") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player1Speed", PlayerPrefs.GetInt("Player1Speed") + 2);
                PlayerPrefs.SetInt("Icon", PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player1Icon"));
            }
            //缓存的钻石
            _coinNum.text = PlayerPrefs.GetInt("Icon").ToString();
            _attackSpeedTxt.text = PlayerPrefs.GetInt("Player1Speed").ToString();
            _attackSpeedSlider.value = PlayerPrefs.GetInt("Player1Speed") * 0.01f;
        }

        if (StaticData.Order == 1)
        {
            if (PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player2Icon") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player2Speed", PlayerPrefs.GetInt("Player2Speed") + 2);
                PlayerPrefs.SetInt("Icon", PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player2Icon"));
            }
            //缓存的钻石
            _coinNum.text = PlayerPrefs.GetInt("Icon").ToString();
            _attackSpeedTxt.text = PlayerPrefs.GetInt("Player2Speed").ToString();
            _attackSpeedSlider.value = PlayerPrefs.GetInt("Player2Speed") * 0.01f;
        }
        if (StaticData.Order == 2)
        {
            if (PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player3Icon") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player3Speed", PlayerPrefs.GetInt("Player3Speed") + 2);
                PlayerPrefs.SetInt("Icon", PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player3Icon"));
            }
            //缓存的钻石
            _coinNum.text = PlayerPrefs.GetInt("Icon").ToString();
            _attackSpeedTxt.text = PlayerPrefs.GetInt("Player3Speed").ToString();
            _attackSpeedSlider.value = PlayerPrefs.GetInt("Player3Speed") * 0.01f;
        }
    }
   

    private void LifeButtonPlayer1()
    {
        AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.UI_AUDIO));
        if (StaticData.Order == 0)
        {
            if (PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player1Icon") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player1Life", PlayerPrefs.GetInt("Player1Life") + 2);
                PlayerPrefs.SetInt("Icon", PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player1Icon"));
            }
            //缓存的钻石
            _coinNum.text = PlayerPrefs.GetInt("Icon").ToString();
            _lifeTxt.text = PlayerPrefs.GetInt("Player1Life").ToString();
            _lifeSlider.value = PlayerPrefs.GetInt("Player1Life") * 0.01f;
        }
        if (StaticData.Order == 1)
        {
            if (PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player2Icon") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player2Life", PlayerPrefs.GetInt("Player2Life") + 2);
                PlayerPrefs.SetInt("Icon", PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player2Icon"));
            }
            //缓存的钻石
            _coinNum.text = PlayerPrefs.GetInt("Icon").ToString();
            _lifeTxt.text = PlayerPrefs.GetInt("Player2Life").ToString();
            _lifeSlider.value = PlayerPrefs.GetInt("Player2Life") * 0.01f;
        }
        if (StaticData.Order == 2)
        {
            if (PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player3Icon") < 0)
            {
                Debug.Log("金钱不足");
            }
            else
            {
                PlayerPrefs.SetInt("Player3Life", PlayerPrefs.GetInt("Player3Life") + 2);
                PlayerPrefs.SetInt("Icon", PlayerPrefs.GetInt("Icon") - PlayerPrefs.GetInt("Player3Icon"));
            }
            //缓存的钻石
            _coinNum.text = PlayerPrefs.GetInt("Icon").ToString();
            _lifeTxt.text = PlayerPrefs.GetInt("Player3Life").ToString();
            _lifeSlider.value = PlayerPrefs.GetInt("Player3Life") * 0.01f;
        }
    }
    //public void SetJsonThreeData()
    //{
    //    JsonCache.Single.player1.Name = "Player1";
    //    JsonCache.Single.player1.DataPlayer["攻击"] = PlayerPrefs.GetInt("Player1Attack");
    //    JsonCache.Single.player1.DataPlayer["攻速"] = PlayerPrefs.GetInt("Player1Speed");
    //    JsonCache.Single.player1.DataPlayer["生命"] = PlayerPrefs.GetInt("Player1Life");
    //    JsonCache.Single.player1.DataPlayer["金币"] = PlayerPrefs.GetInt("Player1Icon");
    //    JsonCache.Single.player1.DataPlayer["钻石"] = PlayerPrefs.GetInt("Player1Diamond");

    //    JsonCache.Single.player2.Name = "Player2";
    //    JsonCache.Single.player2.DataPlayer["攻击"] = PlayerPrefs.GetInt("Player2Attack");
    //    JsonCache.Single.player2.DataPlayer["攻速"] =  PlayerPrefs.GetInt("Player2Speed");
    //    JsonCache.Single.player2.DataPlayer["生命"] = PlayerPrefs.GetInt("Player2Life");
    //    JsonCache.Single.player2.DataPlayer["金币"] = PlayerPrefs.GetInt("Player2Icon");
    //    JsonCache.Single.player2.DataPlayer["钻石"] = PlayerPrefs.GetInt("Player2Diamond");

    //    JsonCache.Single.player3.Name = "Player3";
    //    JsonCache.Single.player3.DataPlayer["攻击"] = PlayerPrefs.GetInt("Player3Attack");
    //    JsonCache.Single.player3.DataPlayer["攻速"] = PlayerPrefs.GetInt("Player3Speed");
    //    JsonCache.Single.player3.DataPlayer["生命"] = PlayerPrefs.GetInt("Player3Life");
    //    JsonCache.Single.player3.DataPlayer["金币"] = PlayerPrefs.GetInt("Player3Icon");
    //    JsonCache.Single.player3.DataPlayer["钻石"] = PlayerPrefs.GetInt("Player3Diamond");

    //    JsonCache.Single.iconAndDiamond.Name = "iconAndDiamond";
    //    PlayerPrefs.SetInt("Diamond",) = PlayerPrefs.GetInt("iconAndDiamond");
    //    JsonCache.Single.iconAndDiamond.DataPlayer["Icon"] =  PlayerPrefs.GetInt("Diamond");

    //}

    
}