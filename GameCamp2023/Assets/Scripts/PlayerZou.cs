using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerZou : game.PlayerBase
{
    [SerializeField]
    TileBase setTile;   // 設置するタイル

    // 弾発射
    protected override void Fire()
    {
        // 弾を生成
        //GameObject obj = Instantiate(BulletPrefab);
        //obj.transform.position = transform.position;
    }

    // 接触処理
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

        if (tileMap.GetTile(cellPosition) != null)
        {
            // 接触タイル名取得
            string[] name = tileMap.GetTile(cellPosition).name.Split();

            if (name[0].Equals("Wall") == false &&
                name[0].Equals("OuterWall") == false)
            {
                // セル座標にタイルを設定
                tileMap.SetTile(cellPosition, setTile);
            }
        }
    }
}