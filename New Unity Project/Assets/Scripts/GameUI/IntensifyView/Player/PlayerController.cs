/****************************************************
    文件：PlayerController.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    private Button _leftButton;
    private Button _rightButton;
    private Image _img;
    private Sprite[] _imgS;
    
    void Start()
    {
        SelectPlayerImg();
    }




    private void SelectPlayerImg()
    {
        StaticData.Order = 0;
        _leftButton = transform.Find("Left").GetComponent<Button>();
        _rightButton = transform.Find("Right").GetComponent<Button>();
        _img = transform.GetComponent<Image>();
        _imgS = ResourcesLoaderMgr.Single.ResourceLoadAll<Sprite>(Paths.PLAYERPATH);
        _leftButton.onClick.AddListener(LeftButtonAct);
        _rightButton.onClick.AddListener(RightButtonAct);
    }
    private void LeftButtonAct()
    {
        AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_BUTTONONCLICK));
        StaticData.Order -= 1;
        if (StaticData.Order <= 0)
        {
            StaticData.Order = 0;
        }
        _img.sprite = _imgS[StaticData.Order];
        EventCenter.Broadcast(EventType.JsonPlayerData);
    }
    private void RightButtonAct()
    {
        AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_BUTTONONCLICK));
        StaticData.Order += 1;
        if (StaticData.Order >= 2)
        {
            StaticData.Order = 2;
        }
        _img.sprite = _imgS[StaticData.Order];
        EventCenter.Broadcast(EventType.JsonPlayerData);
    }
}