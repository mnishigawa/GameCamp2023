using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace game
{
    public class Bullet : MonoBehaviour
    {
        /// <summary>
        /// 移動方向
        /// </summary>
        public enum BulletAngle
        {
            UP = 0,
            RIGHT = 1,
            DOWN = 2,
            LEFT = 3
        }
        private BulletAngle bulletAngle;    // 移動方向

        private float LifeTime = 1.0f;

        public float MoveSpeed = 1f;

        public float CollisionOffset = 0.1f;

        public GameObject WaterPrefab;

        Tilemap tileMap;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void Initialize(Tilemap tilemap)
        {
            tileMap = tilemap;
        }

        public void SetAngle(BulletAngle angle)
        {
            bulletAngle = angle;
        }

        // Update is called once per frame
        void Update()
        {
            LifeTime -= Time.deltaTime;
            bool isCreateWater = false;
            Vector3 MoveAmount = new Vector3();
            MoveAmount = Vector3.zero;

            // 消滅時間に達していなければ移動　達していれば現在のタイルに水を生成
            if(LifeTime > 0f)
            {
                MoveAmount.x += Mathf.Sin(Mathf.PI * (float)bulletAngle * 0.5f) * MoveSpeed * Time.deltaTime;
                MoveAmount.y += Mathf.Cos(Mathf.PI * (float)bulletAngle * 0.5f) * MoveSpeed * Time.deltaTime;

                Vector3 movedPosition = MoveAmount + transform.position;

                // 移動後が壁の中なら現在タイルに水を生成して消える
                // x軸を判定
                Vector3 offset = new Vector3(CollisionOffset, 0, 0);
                if(GameMain.GetIsWall(movedPosition + offset, tileMap) || GameMain.GetIsWall(movedPosition - offset, tileMap))
                {
                    isCreateWater = true;
                }
                // y軸を判定
                offset = new Vector3(0, CollisionOffset, 0);
                if(GameMain.GetIsWall(movedPosition + offset, tileMap) || GameMain.GetIsWall(movedPosition - offset, tileMap))
                {
                    isCreateWater = true;
                }
            }
            else
            {
                isCreateWater = true;
            }

            if(isCreateWater)
            {
                    CreateWater(transform.position);
                    Destroy(this.gameObject);
            }
            else
            {
                transform.Translate(MoveAmount.x, MoveAmount.y, 0.0f, Space.Self);
            }

        }

        private void CreateWater(Vector3 position)
        {
            GameObject.Instantiate(WaterPrefab, position, Quaternion.identity);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // わかめに当たった際の破棄処理はわかめ側に記述
        }
    }
}
