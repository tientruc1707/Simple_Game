using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringConstant
{
    public static class ObjectTags
    {
        public const string GROUND = "Ground";
        public const string PLAYER = "Player";
        public const string DEADZONE = "DeadZone";
        public const string ENEMY = "Enemy";
        public const string DOOR = "Door";
    }
    public static class PlayerDetail
    {
        public static float DAMAGE = 30;
        public static float HEALTH = 100;
        public static float SPEED = 150;
        public static float JUMPFORCE = 250;
    }
    public static class GameScene
    {
        public const string MAINMENU = "Main Menu";

    }
    public static class SOUNDS
    {
        public const string MAIN_SOUND = "mainSound";
        public const string GAME_BACKGROUND = "backgroundSound";
        public const string PLAYER_RUN = "runSfx";
        public const string SWORD = "swordSfx";
    }
}
