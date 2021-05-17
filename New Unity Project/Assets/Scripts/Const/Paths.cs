/****************************************************
    文件：Paths.cs
	作者：Sy
    邮箱: 767854885@qq.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using UnityEngine;

public class Paths  
{
    /// <summary>
    /// 这是预制体的路径
    /// </summary>
    public const string PREFAB = "Prefab/";
    public const string PREFAB_UIPREFAB = PREFAB + "UIPrefab/";
    public const string START_VIEW = PREFAB_UIPREFAB + "StartView";
    public const string SELECT_HERO_VIEW = PREFAB_UIPREFAB + "SelectedHeroView";
    public const string INTENSIFYVIEW = PREFAB_UIPREFAB + "IntensifyView";
    public const string LOGINWND = PREFAB_UIPREFAB + "LoginWnd";
    public const string PLAYERUI = PREFAB_UIPREFAB + "PlayerUI";

    //图片路径
    public const string PICTUREPATH = "Picture/";
    public const string PLAYERPATH = PICTUREPATH + "Player";

    //预制体
    public const string GAMEPREFAB = PREFAB + "Game/";
    public const string GAMECView = GAMEPREFAB + "GameCView";
    public const string BULLET = PREFAB + "Bullet/";
    public const string PLAYER1PREFAB = GAMEPREFAB + "Player1";
    public const string PLAYER2PREFAB = GAMEPREFAB + "Player2";
    public const string PLAYER3PREFAB = GAMEPREFAB + "Player3";
    public const string JOYSTICK = GAMEPREFAB + "JoyStick";
    public const string PLAYER1_BULLET = BULLET + "PlayerBullet_1";
    public const string PLAYER2_BULLET = BULLET + "PlayerBullet_2";
    public const string PLAYER3_BULLET = BULLET + "PlayerBullet_3";
    public const string PREFAB_ICON = GAMEPREFAB + "coin";
    public const string PREFAB_Diamond = GAMEPREFAB + "diamond";
    public const string ENEMY = PREFAB + "Enemy/";
    public const string BOOM = ENEMY + "Boom/";
    public const string FIRE = ENEMY + "EnemyFire/";
    public const string ENEMYMONSTER = ENEMY + "EnemyMonster/";
    public const string ENEMY_NUM = ENEMYMONSTER + "Ememy_";
    public const string BOOM_EXPLOCAL = BOOM + "ExpLocal";
    //三号机
    public const string ENEMY_3 = ENEMYMONSTER + "Ememy_3";
    public const string BOOM_3 = BOOM + "ExpM2";
    public const string FIRE_3 = FIRE + "Enemy_3Fire";

    //Boss
    public const string BOSS_FIRE = FIRE + "BossBullet";
    public const string BOSS_FIRE_2 = FIRE + "BossBullet_2";
    public const string BOSS_FIRE_3 = FIRE + "BossBullet_3";
    public const string Boss = ENEMY + "Boss/Boss2";
    //音频文件
    public const string AUDIO = "Audio/";
    public const string AUDIO_LEVEL = AUDIO + "Level/";
    public const string AUDIO_BUTTONONCLICK = AUDIO + "ButtonOnclick";
    public const string AUDIO_STARTBGM = AUDIO + "StartBgm";
    public const string AUDIO_LEVEL1 = AUDIO_LEVEL + "Level1";
    public const string AUDIO_ZIDAN = AUDIO_LEVEL + "ZiDan_1";
    public const string AUDIO_ENEMY_1 = AUDIO_LEVEL + "Enemy_1";
    public const string ICON_AUDIO = AUDIO_LEVEL + "IConAudio";
    public const string DIAMOND_AUDIO = AUDIO_LEVEL + "Diamond";
    public const string BOSSFIRE2_AUDIO = AUDIO_LEVEL + "Boss_fire2";

    public const string UI_AUDIO = AUDIO_LEVEL + "UI";
    /// <summary>
    /// view界面绑定脚本优先级
    /// </summary>
    public const int BIND_PREFAB_PRIORITY_VIEW = 0;
    /// <summary>
    /// controller绑定脚本优先级
    /// </summary>
    public const int BIND_PREFAB_PRIORITY_CONTROLLER = 1;
    //场景切换路径
    public const string GAME = "GAME";
    public const string Main = "Main";
}