/****************************************************
    文件：StartController.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
[PrefabBind(Paths.START_VIEW, Paths.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class StartController :ControllerBase
{
    public override void Init()
    {
        transform.ButtonAction("Start", ()=> 
        {
            UIMgr.Single.Show(Paths.SELECT_HERO_VIEW, GameObject.Find("Canvas").transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_BUTTONONCLICK));
        });
    }
}