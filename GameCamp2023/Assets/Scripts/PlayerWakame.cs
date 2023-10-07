using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerWakame : game.PlayerBase
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // タイルとの接触処理

        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition =  .WorldToCell(transform.position);
        collision.gameObject.GetComponent<Tilemap>.

        // 現在のタイル名取得
        if (tilemap.GetTile(cellPosition) != null)
        {
            string[] name = tilemap.GetTile(cellPosition).name.Split();

            // セル座標に赤いタイルを設定
            if (name[0].Equals("Wall") == false &&
        name[0].Equals("OuterWall") == false)
            {
                tilemap.SetTile(cellPosition, redTile);
            }
        }
    }
}
