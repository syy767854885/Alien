/****************************************************
    文件：IEnemy.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public abstract class IEnemy :MonoBehaviour
{
    private int attack;
    public int _icon;
    public virtual void RanPos()
    {
        switch (StaticData.BorRan)
        {
            case 1:
                transform.position = GameObject.Find("Main Camera/Born_01").transform.position;
                break;
            case 2:
                transform.position = GameObject.Find("Main Camera/Born_02").transform.position;
                break;
            case 3:
                transform.position = GameObject.Find("Main Camera/Born_03").transform.position;
                break;
        }
    }

    public virtual int SwitchPlayerAttack()
    {
        switch (StaticData.Order)
        {
            case 0:
                attack = PlayerPrefs.GetInt("Player1Attack");
                break;
            case 1:
                attack = PlayerPrefs.GetInt("Player2Attack");
                break;
            case 2:
                attack = PlayerPrefs.GetInt("Player3Attack");
                break;
        }
        return attack;
    }
    public virtual void IconScore()
    {
        if (_icon == 1)
        {
            GameManager.Single.GetGameObjectResource(FactoryType.IConScore, Paths.PREFAB_ICON, this.transform);
        }
        if (_icon == 2)
        {
            GameManager.Single.GetGameObjectResource(FactoryType.DiamondScore, Paths.PREFAB_Diamond, this.transform);
        }

    }
}