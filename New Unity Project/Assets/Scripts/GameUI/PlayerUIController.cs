/****************************************************
    文件：PlayerUIController.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour 
{
    private Text _iconText;
    private Text _dimaondText;
    private Image _imgHp;

    private float _playHp_1;
    private float _playHp_2;
    private float _playHp_3;

    void Start()
    {
        _playHp_1 = PlayerPrefs.GetInt("Player1Life") * 0.01f;
        _playHp_2 = PlayerPrefs.GetInt("Player2Life") * 0.01f;
        _playHp_3 = PlayerPrefs.GetInt("Player3Life") * 0.01f;
        _iconText = transform.Find("IconNum").GetComponent<Text>();
        _dimaondText = transform.Find("DiamondNum").GetComponent<Text>();
        _imgHp = transform.Find("HpSlider").GetComponent<Image>();
        EventCenter.AddListener(EventType.ScoreType, ShowSore);
        EventCenter.Broadcast(EventType.ScoreType);
        StaticData.Hp = 0;
        ShowSore();
    }

    public void ShowSore()
    {
        

        _iconText.text = PlayerPrefs.GetInt("Icon").ToString();
        _dimaondText.text = PlayerPrefs.GetInt("Diamond").ToString();
        switch (StaticData.Order)
        {
            case 0:
                _imgHp.fillAmount = _playHp_1 + StaticData.Hp * 0.01f;
                StaticData.PlyaerHP = _imgHp.fillAmount;
                break;
            case 1:
                _imgHp.fillAmount = _playHp_2 + StaticData.Hp * 0.01f;
                StaticData.PlyaerHP = _imgHp.fillAmount;
                break;
            case 2:
                _imgHp.fillAmount = _playHp_3 + StaticData.Hp * 0.01f;
                StaticData.PlyaerHP = _imgHp.fillAmount;
                break;

        }

    }
}