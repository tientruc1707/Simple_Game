using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringConstant
{
    public static class ObjectTags
    {
        public const string GROUND = "Ground";
        public const string PLAYER = "Player";
        public const string TRAP = "Trap";
        public const string ENEMY = "Enemy";
    }

    public static class GameState
    {
        public const string MAINMENU = "MainMenu";
        public const string PAUSEGAME = "PauseGame";
        public const string PLAYING = "Playing";
        public const string GAMEOVER = "GameOver";
        public const string WINGAME = "WinGame";
        public const string TROPHY = "TrophyUI";
        public const string SETTING = "SettingUI";
        public const string SELECTLEVEL = "SelectLevelUI";
    }
}
