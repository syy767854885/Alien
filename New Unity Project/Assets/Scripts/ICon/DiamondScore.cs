/****************************************************
    文件：DiamondScore.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class DiamondScore : MonoBehaviour 
{
    void OnEnable()
    {
        transform.position = StaticData.Enemy_1.gameObject.transform.position;
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.DIAMOND_AUDIO));
            GameManager.Single.PushGameObjectToFactory(FactoryType.DiamondScore, Paths.PREFAB_Diamond, this.gameObject);
            PlayerPrefs.SetInt("Diamond", PlayerPrefs.GetInt("Diamond") + 1);
            EventCenter.Broadcast(EventType.ScoreType);
            //JsonCache.Single.SetJson();
        }
    }
}