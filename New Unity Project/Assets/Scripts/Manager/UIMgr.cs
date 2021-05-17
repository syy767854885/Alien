/****************************************************
    文件：UIMgr.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : NormalSingleton<UIMgr> 
{
    private Stack<string> _uiStack = new Stack<string>();
    private Dictionary<string,GameObject> _objDic = new Dictionary<string, GameObject>();
    public void Show(string path, Transform trans)
    {

        if (_uiStack.Count > 0)
        {
            string name = _uiStack.Peek();
            GameObject goHide = _objDic[name];
            goHide.SetActive(false);
        }
        _uiStack.Push(path);
        if (!_objDic.ContainsKey(path))
        {
            GameObject go = ResourcePrefab(path, trans);
            AddBindScripts(path, go);
            InitView(go);
        }
        else
        {
            _objDic[path].SetActive(true);
        }
        
    }

    public void Back(string path, Transform trans)
    {
        if (_uiStack.Count <= 1)
        {
            return;
        }
        //先判断栈里面存储得有物体吗
        string name = _uiStack.Peek();
        GameObject goHide = _objDic[name];
        goHide.SetActive(false);
        _uiStack.Pop();
        goHide = _objDic[path];
        goHide.SetActive(true);
        _uiStack.Push(path);
        return;
    }
    public void BackScene()
    {
        if (_uiStack.Count <= 1)
        {
            return;
        }
        //先判断栈里面存储得有物体吗
        string name = _uiStack.Peek();
        GameObject goHide = _objDic[name];
        goHide.SetActive(false);
        _uiStack.Pop();
        
        return;
    }

    private GameObject ResourcePrefab(string path,Transform trans)
    {
        if (!_objDic.ContainsKey(path))
        {
            GameObject go = ResourcesLoaderMgr.Single.ResourceLoaderGameObject(path, trans);
            go.SetActive(true);
            _objDic.Add(path, go);
            return go;
        }
        else
        {
            return _objDic[path];
        }
    }

   

    private void AddBindScripts(string path,GameObject viewGo)
    {
        foreach (var type in BindUtil.BindGet(path))
        {
            viewGo.AddComponent(type);
        }
    }

    private void InitView(GameObject go)
    {
        IInit[] inits = go.GetComponents<IInit>();
        //各自进行初始化
        foreach (var init in inits)
        {
            init.Init();
        }
    }
}