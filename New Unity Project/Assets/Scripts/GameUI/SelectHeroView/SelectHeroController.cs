/****************************************************
    文件：SelectHeroController.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;
[PrefabBind(Paths.SELECT_HERO_VIEW,Paths.BIND_PREFAB_PRIORITY_CONTROLLER)]
public class SelectHeroController : ControllerBase 
{
    public override void Init()
    {
        StaticData.Order = 0;
        transform.Find("SelectView").gameObject.AddComponent<SelectView>();
        transform.ButtonAction("Intensify", () =>
        {
            UIMgr.Single.Show(Paths.INTENSIFYVIEW, GameObject.Find("Canvas").transform);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.UI_AUDIO));
        });
        
        transform.ButtonAction("StartButton", () =>
        {
             ResSvc.Single.AsyncLoadScene(Paths.GAME, GameViewController);
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.UI_AUDIO));
        });
    }

    private void GameViewController()
    {
        AudioSourceManager.Single.PlayBGMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_LEVEL1));
        GameObject.Find("Main Camera").AddComponent<MapController>();
        GameObject playerUIGo = ResourcesLoaderMgr.Single.ResourceLoaderGameObject(Paths.PLAYERUI, GameObject.Find("Canva").transform);
        playerUIGo.AddComponent<PlayerUIController>();
        //switch (StaticData.Order)
        //{
        //    case 0:

        //        break;
        //    case 1:
        //        break;
        //    case 2:
        //        break;
        //}
        
    }
}