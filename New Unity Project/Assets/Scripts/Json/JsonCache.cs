/****************************************************
    文件：JsonCache.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonCache :NormalSingleton<JsonCache>
{
    
    public PlayerS playersLoad;
    public PlayerJson player1 = new PlayerJson();
    public PlayerJson player2 = new PlayerJson();
    public PlayerJson player3 = new PlayerJson();
    public PlayerJson iconAndDiamond = new PlayerJson();
    
    public void InitJson()
    {
        //Init();
        LoadWeaponProperty();

        //Debug.Log(JsonSingle.Single.PlayerJsonData["Player1"]["攻击"]);
        
    }


    public void LoadWeaponProperty()
    {
        if (!PlayerPrefs.HasKey("Player1Attack"))
        {
            PlayerS playersLoad = new PlayerS();
        //weaponProperties = new List<WeaponProperties>();
        string filePath = Application.streamingAssetsPath + "/PlayerInit.json";

        WWW www = new WWW(filePath);

        string jsonStr = www.text;
        playersLoad = JsonMapper.ToObject<PlayerS>(jsonStr);
        ////判断是否存在这个文件
        //if (File.Exists(filePath))
        //{
        //    //读取文件流
        //    StreamReader sr = new StreamReader(filePath);
        //    //读完
        //    string jsonStr = sr.ReadToEnd();
        //    //关闭文件流
        //    sr.Close();
        //    //给列表赋值
        //    playersLoad = JsonMapper.ToObject<PlayerS>(jsonStr);
        //    //Debug.Log(playersLoad.playerJsons[0].DataPlayer["攻击"]);
        //}
        
            foreach (PlayerJson playerJs in playersLoad.playerJsons)
            {
                if (!JsonSingle.Single.PlayerJsonData.ContainsKey(playerJs.Name))
                {
                    JsonSingle.Single.PlayerJsonData.Add(playerJs.Name, new Dictionary<string, int>());
                }

                foreach (KeyValuePair<string, int> js in playerJs.DataPlayer)
                {
                    JsonSingle.Single.PlayerJsonData[playerJs.Name].Add(js.Key, js.Value);
                }
            }
            PlayerPrefs.SetInt("Player1Attack", JsonSingle.Single.PlayerJsonData["Player1"]["攻击"]);
            PlayerPrefs.SetInt("Player1Speed", JsonSingle.Single.PlayerJsonData["Player1"]["攻速"]);
            PlayerPrefs.SetInt("Player1Life", JsonSingle.Single.PlayerJsonData["Player1"]["生命"]);
            PlayerPrefs.SetInt("Player1Diamond", JsonSingle.Single.PlayerJsonData["Player1"]["钻石"]);
            PlayerPrefs.SetInt("Player1Icon", JsonSingle.Single.PlayerJsonData["Player1"]["金币"]);

            PlayerPrefs.SetInt("Player2Attack", JsonSingle.Single.PlayerJsonData["Player2"]["攻击"]);
            PlayerPrefs.SetInt("Player2Speed", JsonSingle.Single.PlayerJsonData["Player2"]["攻速"]);
            PlayerPrefs.SetInt("Player2Life", JsonSingle.Single.PlayerJsonData["Player2"]["生命"]);
            PlayerPrefs.SetInt("Player2Diamond", JsonSingle.Single.PlayerJsonData["Player2"]["钻石"]);
            PlayerPrefs.SetInt("Player2Icon", JsonSingle.Single.PlayerJsonData["Player2"]["金币"]);

            PlayerPrefs.SetInt("Player3Attack", JsonSingle.Single.PlayerJsonData["Player3"]["攻击"]);
            PlayerPrefs.SetInt("Player3Speed", JsonSingle.Single.PlayerJsonData["Player3"]["攻速"]);
            PlayerPrefs.SetInt("Player3Life", JsonSingle.Single.PlayerJsonData["Player3"]["生命"]);
            PlayerPrefs.SetInt("Player3Diamond", JsonSingle.Single.PlayerJsonData["Player3"]["钻石"]);
            PlayerPrefs.SetInt("Player3Icon", JsonSingle.Single.PlayerJsonData["Player3"]["金币"]);

            PlayerPrefs.SetInt("Icon", JsonSingle.Single.PlayerJsonData["iconAndDiamond"]["Icon"]);
            PlayerPrefs.SetInt("Diamond", JsonSingle.Single.PlayerJsonData["iconAndDiamond"]["Diamond"]);
        }
        
      



    }

   public IEnumerator LoadWWW()
    {
        PlayerS playersLoad = new PlayerS();
        //weaponProperties = new List<WeaponProperties>();
        string filePath = Application.streamingAssetsPath + "/PlayerInit.json";
        WWW www = new WWW(filePath);
        while (!www.isDone)
        {
            yield return null;
        }
        string jsonStr = www.text;
        playersLoad = JsonMapper.ToObject<PlayerS>(jsonStr);
        foreach (PlayerJson playerJs in playersLoad.playerJsons)
        {
            if (!JsonSingle.Single.PlayerJsonData.ContainsKey(playerJs.Name))
            {
                JsonSingle.Single.PlayerJsonData.Add(playerJs.Name, new Dictionary<string, int>());
            }

            foreach (KeyValuePair<string, int> js in playerJs.DataPlayer)
            {
                JsonSingle.Single.PlayerJsonData[playerJs.Name].Add(js.Key, js.Value);
            }
        }
    }
    public void Init()
    {
        player1.Name = "Player1";
        player1.DataPlayer.Add("攻击", 30);
        player1.DataPlayer.Add("攻速", 20);
        player1.DataPlayer.Add("生命", 20);
        player1.DataPlayer.Add("钻石", 20);
        player1.DataPlayer.Add("金币", 20);
        
        player2.Name = "Player2";
        player2.DataPlayer.Add("攻击", 30);
        player2.DataPlayer.Add("攻速", 30);
        player2.DataPlayer.Add("生命", 30);
        player2.DataPlayer.Add("钻石", 20);
        player2.DataPlayer.Add("金币", 20);
        
        player3.Name = "Player3";
        player3.DataPlayer.Add("攻击", 40);
        player3.DataPlayer.Add("攻速", 40);
        player3.DataPlayer.Add("生命", 40);
        player3.DataPlayer.Add("钻石", 20);
        player3.DataPlayer.Add("金币", 20);
        
        iconAndDiamond.Name = "iconAndDiamond";
        iconAndDiamond.DataPlayer.Add("Icon", 1000);
        iconAndDiamond.DataPlayer.Add("Diamond", 1000);

        //


        PlayerS players = new PlayerS();

        players.playerJsons = new PlayerJson[] { player1, player2, player3, iconAndDiamond };

        string jsonStr = JsonMapper.ToJson(players);
        PlayerS ps = JsonMapper.ToObject<PlayerS>(jsonStr);

        string filePath = Application.dataPath + "/StreamingAssets" + "/PlayerInit.json";
        //利用JsonMapper将信息类转化为Json格式的字符串
        string saveJsonStr = JsonMapper.ToJson(ps);
        //创建一个文件流去将字符串写入一个文件夹中
        StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(saveJsonStr);
        sw.Close();
    }

    //public void SetJson()
    //{
    //    SetJsonThreeData();


    //    PlayerS players = new PlayerS();

    //    players.playerJsons = new PlayerJson[] { player1, player2, player3, iconAndDiamond };

    //    string jsonStr = JsonMapper.ToJson(players);
    //    PlayerS ps = JsonMapper.ToObject<PlayerS>(jsonStr);

    //    string filePath = Application.dataPath + "/StreamingAssets" + "/PlayerInit.json";
    //    //string filePath = Application.streamingAssetsPath + "/PlayerInit.json";
    //    //WWW


    //    //利用JsonMapper将信息类转化为Json格式的字符串
    //    string saveJsonStr = JsonMapper.ToJson(ps);
    //    //创建一个文件流去将字符串写入一个文件夹中
    //    StreamWriter sw = new StreamWriter(filePath);
    //    sw.WriteLine(saveJsonStr);
    //    sw.Close();
    //}
    public void SetJsonThreeData()
    {
        JsonCache.Single.player1.Name = "Player1";
        JsonCache.Single.player1.DataPlayer["攻击"] = JsonSingle.Single.PlayerJsonData["Player1"]["攻击"];
        JsonCache.Single.player1.DataPlayer["攻速"] = JsonSingle.Single.PlayerJsonData["Player1"]["攻速"];
        JsonCache.Single.player1.DataPlayer["生命"] = JsonSingle.Single.PlayerJsonData["Player1"]["生命"];
        JsonCache.Single.player1.DataPlayer["金币"] = JsonSingle.Single.PlayerJsonData["Player1"]["金币"];
        JsonCache.Single.player1.DataPlayer["钻石"] = JsonSingle.Single.PlayerJsonData["Player1"]["钻石"];

        JsonCache.Single.player2.Name = "Player2";
        JsonCache.Single.player2.DataPlayer["攻击"] = JsonSingle.Single.PlayerJsonData["Player2"]["攻击"];
        JsonCache.Single.player2.DataPlayer["攻速"] = JsonSingle.Single.PlayerJsonData["Player2"]["攻速"];
        JsonCache.Single.player2.DataPlayer["生命"] = JsonSingle.Single.PlayerJsonData["Player2"]["生命"];
        JsonCache.Single.player2.DataPlayer["金币"] = JsonSingle.Single.PlayerJsonData["Player2"]["金币"];
        JsonCache.Single.player2.DataPlayer["钻石"] = JsonSingle.Single.PlayerJsonData["Player2"]["钻石"];

        JsonCache.Single.player3.Name = "Player3";
        JsonCache.Single.player3.DataPlayer["攻击"] = JsonSingle.Single.PlayerJsonData["Player3"]["攻击"];
        JsonCache.Single.player3.DataPlayer["攻速"] = JsonSingle.Single.PlayerJsonData["Player3"]["攻速"];
        JsonCache.Single.player3.DataPlayer["生命"] = JsonSingle.Single.PlayerJsonData["Player3"]["生命"];
        JsonCache.Single.player3.DataPlayer["金币"] = JsonSingle.Single.PlayerJsonData["Player3"]["金币"];
        JsonCache.Single.player3.DataPlayer["钻石"] = JsonSingle.Single.PlayerJsonData["Player3"]["钻石"];

        JsonCache.Single.iconAndDiamond.Name = "iconAndDiamond";
        JsonCache.Single.iconAndDiamond.DataPlayer["Diamond"] = JsonSingle.Single.PlayerJsonData["iconAndDiamond"]["Diamond"];
        JsonCache.Single.iconAndDiamond.DataPlayer["Icon"] = JsonSingle.Single.PlayerJsonData["iconAndDiamond"]["Icon"];

    }

}