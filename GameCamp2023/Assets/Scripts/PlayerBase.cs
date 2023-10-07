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
                FireFlag = true;
            }

            Vector3 movedPosition = MoveAmount + transform.position;

            Vector3Int cellPosition = tileMap.WorldToCell(movedPosition);

            var targetTile = tileMap.GetTile(cellPosition);
            
            if(targetTile.name == "Wall" || targetTile.name == "OuterWall")
            {
                return;
            }

            transform.Translate(MoveAmount.x, MoveAmount.y, 0.0f, Space.Self);
        }

        public string GetCurrentTileName()
        {
            Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

            var targetTile = tileMap.GetTile(cellPosition);

            if(targetTile == null)
            {
                return string.Empty;
            }

            return targetTile.name;
        }

        protected virtual void Fire()
        {
            // 弾発射
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            // タイルとの接触処理
        }
    }
}