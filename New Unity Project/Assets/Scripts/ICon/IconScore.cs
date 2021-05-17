/****************************************************
    文件：IconScore.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections;
using UnityEngine;

public class IconScore : MonoBehaviour 
{

    void OnEnable()
    {
        transform.position = StaticData.Enemy_1.gameObject.transform.position;
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.ICON_AUDIO));
            GameManager.Single.PushGameObjectToFactory(FactoryType.IConScore, Paths.PREFAB_ICON, this.gameObject);
            PlayerPrefs.SetInt("Icon", PlayerPrefs.GetInt("Icon")+1);
            
            EventCenter.Broadcast(EventType.ScoreType);
            StartCoroutine(LoadIcon());
            //JsonCache.Single.SetJson();
        }
    }

    IEnumerator LoadIcon()
    {
        //JsonCache.Single.SetJson();
        yield return null;
    }
  
}