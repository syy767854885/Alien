/****************************************************
    文件：LaunchGame.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour 
{
    private GameObject gameOver;
    private GameObject passUI;
    void Awake()
    {
        
        DontDestroyOnLoad(GameObject.Find("Canvas").transform);
        JsonSingle.Single.PlayerJsonData = new Dictionary<string, Dictionary<string, int>>();
        StartCoroutine(loadWWW());
    }
    void Start()
    {
        InitBind Inits = new InitBind();
        Inits.Init();
        StaticData.ScroeData = PlayerPrefs.GetInt("Icon");
        UIMgr.Single.Show(Paths.START_VIEW, GameObject.Find("Canvas").transform);
        AudioSourceManager.Single.PlayBGMusic(GameManager.Single.GetAudioClip(Paths.AUDIO_STARTBGM));
        EventCenter.AddListener(EventType.GameOver, GameOverUI);
        EventCenter.AddListener(EventType.PassUI, PassUI);
    }


    IEnumerator loadWWW()
    {
        JsonCache jsCache = new JsonCache();
        jsCache.InitJson();
        
        yield return null;
        
    }

    public void InvkeInit()
    {
        
    }
    void GameOverUI()
    {
        
        gameOver.SetActive(true);
    }
    void PassUI()
    {
        passUI.SetActive(true);
    }
}