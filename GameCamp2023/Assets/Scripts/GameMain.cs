using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public PlayerInput inputManager;

        // Start is called before the first frame update
        void Start()
        {
            // 入力マネージャ　インスタンス生成と初期化
            inputManager = new PlayerInput();
            inputManager.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            // 入力情報の更新
            inputManager.UpdateInputStatus();

            if (Input.GetKeyDown("space"))
            {
                inputManager.GetInputStatus(PlayerIndex.ZOU);
            }
        }
    }
}