using System.Collections;
using System.Collections.Generic;
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

        private float MoveSpeed = 1f;

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
            Vector3 MoveAxis = new Vector3();
            MoveAxis = Vector3.zero;

            MoveAxis.x += Mathf.Sin(Mathf.PI * (float)bulletAngle * 0.5f) * MoveSpeed * Time.deltaTime;
            MoveAxis.y += Mathf.Cos(Mathf.PI * (float)bulletAngle * 0.5f) * MoveSpeed * Time.deltaTime;

            transform.Translate(MoveAxis.x, MoveAxis.y, 0.0f, Space.Self);

            // タイルとの判定を取る

        }

        public string GetCurrentTileName(Vector3 position)
        {
            Vector3Int cellPosition = tileMap.WorldToCell(position);

            var targetTile = tileMap.GetTile(cellPosition);

            if (targetTile == null)
            {
                return string.Empty;
            }

            return targetTile.name;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // ワカメとの接触
            if (collision.gameObject.name == "Wakame")
            {
                // ワカメの増殖
            }
        }
    }
}
