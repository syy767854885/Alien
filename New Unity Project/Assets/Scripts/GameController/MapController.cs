/****************************************************
    文件：MapController.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class MapController : MonoBehaviour 
{
    private float _speed = 2;

    void Start()
    {
        //
        GameObject go = Resources.Load<GameObject>(Paths.GAMECView);
        go.AddComponent<MapMgr>();
        Instantiate(go);
        //transform.Find("Born").gameObject.AddComponent<Born>();
        //

        StaticData._bossTrue = true;
        switch (StaticData.Order)
        {
            case 0:
                GameObject player1Go = Resources.Load<GameObject>(Paths.PLAYER1PREFAB);
                player1Go.AddComponent<Player>();
                Instantiate(player1Go, new Vector3(0, -2.5f, -2),Quaternion.identity);
                break;
            case 1:
                GameObject player2Go = Resources.Load<GameObject>(Paths.PLAYER2PREFAB);
                player2Go.AddComponent<Player2>();
                Instantiate(player2Go, new Vector3(0, -2.5f, -2), Quaternion.identity);
                break;
            case 2:
                GameObject player3Go = Resources.Load<GameObject>(Paths.PLAYER3PREFAB);
                player3Go.AddComponent<Player3>();
                Instantiate(player3Go, new Vector3(0, -2.5f, -2), Quaternion.identity);
                break;
        }
        
    }

    void Update()
    {
        if (StaticData._bossTrue)
        {
            EventCenter.Broadcast(EventType.MapMoveType);
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
            if (transform.position.y >= 97f)
            {
                StaticData._bossTrue = false;
            }
        }
        
    }
}