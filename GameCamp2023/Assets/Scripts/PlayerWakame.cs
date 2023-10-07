using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerWakame : game.PlayerBase
{
    [SerializeField]
    TileBase setTile;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // タイルとの接触処理

        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

        // 現在のタイル名取得
        if (tileMap.GetTile(cellPosition) != null)
        {
            string[] name = tileMap.GetTile(cellPosition).name.Split();

            // セル座標に赤いタイルを設定
            if (name[0].Equals("Wall") == false &&
                name[0].Equals("OuterWall") == false)
            {
                tileMap.SetTile(cellPosition, setTile);
            }
        }
    }
}
