using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace game
{
    public class GameMain : MonoBehaviour
    {
        public const int PlayerNum = 3;

        public enum PlayerIndex
        {
            ZOU = 0,
            WAKAME = 1,
            UNI = 2
        }

        private PlayerInput inputManager;

        public Tilemap tilemap;

        public List<PlayerBase> playerList;

        // Start is called before the first frame update
        void Start()
        {
            // 入力マネージャ　インスタンス生成と初期化
            inputManager = new PlayerInput();
            inputManager.Initialize();

            // プレイヤーの初期化
            foreach(var player in playerList)
            {
                player.Initialize(tilemap);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // 入力情報の更新
            inputManager.UpdateInputStatus();

            // プレイヤー更新
            for(int i = 0; i < PlayerNum; i++)
            {
                playerList[i].Move(inputManager.GetInputStatus((PlayerIndex)i), tilemap);
                playerList[i].ReplaceTile();
            }
        }
    }
}