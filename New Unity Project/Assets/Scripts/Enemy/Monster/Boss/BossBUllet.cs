/****************************************************
    文件：BossBUllet.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class BossBUllet : MonoBehaviour 
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DownWall")
        {
            Destroy(this.gameObject);
        }
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            
            AudioSourceManager.Single.PlayEffectMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_ENEMY_1));
        }
    }
}