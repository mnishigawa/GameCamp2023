using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace game
{
    public class GameMain : MonoBehaviour
    {
        public static GameMain instance = null;

        public const int PlayerNum = 3;

        public enum PlayerIndex
        {
            ZOU = 0,
            WAKAME = 1,
            UNI = 2
        }

        public enum ObjectType
        {
            ZOU,
            WAKAME,
            UNI,
            WATER,
            MINIWAKAME,
            MINIUNI
        }

        private PlayerInput inputManager;

        public Tilemap tilemap;

        public List<PlayerBase> playerList;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            DontDestroyOnLoad(this);

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

        // 指定位置のタイルを取得
        public static TileBase GetCurrentTile(Vector3 position, Tilemap tileMap)
        {
            Vector3Int cellPosition = tileMap.WorldToCell(position);

            var targetTile = tileMap.GetTile(cellPosition);

            return targetTile;
        }

        // 対象座標が壁かどうか判定する
        public static bool GetIsWall(Vector3 playerPosition, Tilemap tileMap)
        {
            Vector3Int cellPosition = tileMap.WorldToCell(playerPosition);

            var targetTile = tileMap.GetTile(cellPosition);
            
            if(targetTile.name == "Wall" || targetTile.name == "OuterWall")
            {
                return true;
            }
            return false;
        }

    }
}