/****************************************************
    文件：IntensifyController.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using LitJson;
using System.IO;
using UnityEngine;
[PrefabBind(Paths.INTENSIFYVIEW,Paths.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class IntensifyController : ControllerBase 
{
    public override void Init()
    {
        transform.Find("Player").gameObject.AddComponent<PlayerController>();
        transform.Find("ThreeData").gameObject.AddComponent<ThreeData>();
        transform.ButtonAction("Back", () =>
        {
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_BUTTONONCLICK));
            UIMgr.Single.Back(Paths.SELECT_HERO_VIEW, GameObject.Find("Canvas").transform);
            //JsonCache.Single.SetJson();
           
        });
    }
   
}