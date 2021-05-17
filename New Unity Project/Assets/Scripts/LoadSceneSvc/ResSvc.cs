/****************************************************
    文件：ResSvc.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc :  MonoSingleton<ResSvc>
{
    //加载场景
    private Action prgCB = null;
  
    public void AsyncLoadScene(string sceneName, Action loaded)
    {

        UIMgr.Single.BackScene();
        //将加载界面显示出来
        LoadingWnd.Single.LoginWnd();


         //GameRoot.Instance.loadingWnd.InitWnd();
         //获得异步加载对象
        AsyncOperation sceneAsync = SceneManager.LoadSceneAsync(sceneName);
        prgCB = () =>
        {
            //加载时间 是零点几
            float val = sceneAsync.progress;
            //GameRoot.Instance.loadingWnd.SetProgress(val);
            LoadingWnd.Single.SetProgress(val);
            if (val == 1)
            {
                //LoginSys.Instance.OpenLoginWnd();
                if (loaded != null)
                {
                    loaded();
                }
                prgCB = null;
                sceneAsync = null;
                //GameRoot.Instance.loadingWnd.gameObject.SetActive(false);
                //隐藏加载场景
                //GameRoot.Instance.loadingWnd.SetWndState(false);
                LoadingWnd.Single.SetState();
            }
        };
    }

    private void Update()
    {
        if (prgCB != null)
        {
            prgCB();
        }
    }

    
}