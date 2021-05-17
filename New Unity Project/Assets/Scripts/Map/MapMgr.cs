/****************************************************
    文件：MapMgr.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class MapMgr : MonoBehaviour 
{
    private Transform _bg1;
    private Transform _bg2;
    private GameObject _mainCamera;
    private float _temp = 0;
    private bool _poin;
    void Start()
    {
        _poin = true;
        _bg1 = transform.Find("GAMEBG");
        _bg2 = transform.Find("GAMEBG2");
        _mainCamera = GameObject.Find("Main Camera");
        EventCenter.AddListener(EventType.MapMoveType, MapMove);
    }

    public void MapMove()
    {
        
        if (_mainCamera.transform.position.y >= _bg1.transform.position.y + 17 || _mainCamera.transform.position.y >= _bg2.transform.position.y + 17)
        {
            
           
            if (_poin)
            {
                _bg1.position = new Vector3(0, _bg2.transform.position.y + 17, 0);
                _poin = false;
            }
            else
            {
                _bg2.position = new Vector3(0, _bg1.transform.position.y + 17, 0);
                _poin = true;
            }
            
        }
        
    }
}