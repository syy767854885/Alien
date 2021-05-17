/****************************************************
    文件：FactoryManager.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class FactoryManager
{
    public Dictionary<FactoryType, IBaseFactory> factoryDict = new Dictionary<FactoryType, IBaseFactory>();
    public AudioClipFactory audioClipFactory;
    public FactoryManager()
    {
        factoryDict.Add(FactoryType.GameFactory, new BaseFactory());
        factoryDict.Add(FactoryType.Enemy, new BaseFactory());
        factoryDict.Add(FactoryType.BoomFactory, new BaseFactory());
        factoryDict.Add(FactoryType.IConScore, new BaseFactory());
        factoryDict.Add(FactoryType.DiamondScore, new BaseFactory());
        factoryDict.Add(FactoryType.Enemy_3, new BaseFactory());
        factoryDict.Add(FactoryType.BoomFactory_3, new BaseFactory());
        factoryDict.Add(FactoryType.Fire_3, new BaseFactory());
        factoryDict.Add(FactoryType.Fire_Boss, new BaseFactory());
        //Boss
        factoryDict.Add(FactoryType.Boss_Fire_1, new BaseFactory());
        factoryDict.Add(FactoryType.BossPrefab, new BaseFactory());

        factoryDict.Add(FactoryType.Bullet_2, new BaseFactory());
        factoryDict.Add(FactoryType.Bullet_3, new BaseFactory());
        audioClipFactory = new AudioClipFactory();

    }
}