using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace game
{
    // プレイヤーのベースクラス
    public class PlayerBase : MonoBehaviour
    {
        // 移動速度
        public float MoveSpeed = 1f;

        // 当たり判定範囲
        public float CollsionOffset = 0.2f;

        // 弾発射フラグ
        private bool FireFlag;

        protected Tilemap tileMap;

        // MonoBehaviourによる初期化処理
        protected virtual void Start()
        {
            FireFlag = false;
        }

        // MonoBehaviourによる更新処理
        protected virtual void Update()
        {
            if(FireFlag == true)
            {
                Fire();
                FireFlag = false;
            }
        }
        
        public void Initialize(Tilemap tilemap)
        {
            tileMap = tilemap;
        }

        // 移動処理 GameMainのUpdateから呼ばれる
        public virtual void Move(game.PlayerInput.InputStatus inputStatus, Tilemap tileMap)
        {
            Vector3 MoveAmount = new Vector3();
            MoveAmount = Vector3.zero;
            if(inputStatus.UP == true)
            {
                MoveAmount.y += MoveSpeed * Time.deltaTime;
            }
            if(inputStatus.DOWN == true)
            {
                MoveAmount.y -= MoveSpeed * Time.deltaTime;
            }
            if(inputStatus.LEFT == true)
            {
                MoveAmount.x -= MoveSpeed * Time.deltaTime;
            }
            if(inputStatus.RIGHT == true)
            {
                MoveAmount.x += MoveSpeed * Time.deltaTime;
            }
            if(inputStatus.FIRE == true)
            {
                Debug.Log("Fire");
                FireFlag = true;
            }

            Vector3 movedPosition = MoveAmount + transform.position;
            
            // 移動後が壁の中にならないか判定
            // x軸を判定
            Vector3 offset = new Vector3(CollsionOffset, 0, 0);
            if(GameMain.GetIsWall(movedPosition + offset, tileMap) || GameMain.GetIsWall(movedPosition - offset, tileMap))
            {
                // x軸が引っ掛かったのでx軸移動値を0にする
                MoveAmount.x = 0f;
            }
            // y軸を判定
            offset = new Vector3(0, CollsionOffset, 0);
            if(GameMain.GetIsWall(movedPosition + offset, tileMap) || GameMain.GetIsWall(movedPosition - offset, tileMap))
            {
                // y軸が引っ掛かったのでy軸移動量を0にする
                MoveAmount.y = 0f;
            }

            transform.Translate(MoveAmount.x, MoveAmount.y, 0.0f, Space.Self);
        }

        public virtual bool ReplaceTile()
        {
            return false;
        }

        protected virtual void Fire()
        {
            // 弾発射
        }
    }
}