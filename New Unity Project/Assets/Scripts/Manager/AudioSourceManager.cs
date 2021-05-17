/****************************************************
    文件：AudioSourceManager.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class AudioSourceManager : GameSingle<AudioSourceManager> 
{
    private AudioSource[] audioSource;
    private bool playEffectMusic = true;
    private bool playBGMusic = true;
    
    //播放背景音乐
    public void PlayBGMusic(AudioClip audioClip)
    {
        audioSource = transform.GetComponents<AudioSource>();
        audioSource[0].volume = 0.5f;
        audioSource[0].loop = true;
        if (!audioSource[0].isPlaying || audioSource[0].clip != audioClip)
        {
            audioSource[0].clip = audioClip;
            audioSource[0].Play();
        }
    }

    //播放音效
    public void PlayEffectMusic(AudioClip audioClip)
    {
        audioSource[1].volume = 1f;
        if (playEffectMusic)
        {
            audioSource[1].PlayOneShot(audioClip);
        }
    }

    public void CloseBGMusic()
    {
        audioSource[0].Stop();
    }

    public void OpenBGMusic()
    {
        audioSource[0].Play();
    }

    public void CloseOrOpenBGMusic()
    {
        playBGMusic = !playBGMusic;
        if (playBGMusic)
        {
            OpenBGMusic();
        }
        else
        {
            CloseBGMusic();
        }
    }

    public void CloseOrOpenEffectMusic()
    {
        playEffectMusic = !playEffectMusic;
    }
}