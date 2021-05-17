/****************************************************
    文件：LoadingWnd.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingWnd : NormalSingleton<LoadingWnd>
{
    public Text txtTips;
    public RectTransform imgFG;
    public RectTransform imgPoint;
    public Text txtPrg;
    private GameObject go;

    private float fgWidth;


    public void LoginWnd()
    {
        go = ResourcesLoaderMgr.Single.ResourceLoaderGameObject(Paths.LOGINWND, GameObject.Find("Canvas").transform);
        go.SetActive(true);
    }

    public void SetProgress(float prg)
    {
        txtTips = GameObject.Find("Text").transform.GetComponent<Text>();
        txtTips.text = (prg * 100).ToString() + "%";

        imgPoint = GameObject.Find("Image").transform.GetComponent<RectTransform>();
        imgPoint.anchoredPosition = new Vector2(-350 + 650 * prg, -533);


        imgFG = GameObject.Find("loadingSlider").transform.GetComponent<RectTransform>();
        imgFG.sizeDelta = new Vector2(740 * prg, 128);
   
        Debug.Log(txtTips.text);

    }

 

    public void SetState()
    {
        go.SetActive(false);
    }

  

  
}