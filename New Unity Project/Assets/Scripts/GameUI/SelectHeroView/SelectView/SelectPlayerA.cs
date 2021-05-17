/****************************************************
    文件：SelectPlayerA.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class SelectPlayerA : SelectView
{
    
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(BtnOnclick);
    }

    public void BtnOnclick()
    {
        AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.UI_AUDIO));
        PlayerInit();
        transform.GetComponent<Image>().color = Color.white;
        StaticData.Order = 0;
    }
   

}