using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerUni : game.PlayerBase
{
    [SerializeField]
    TileBase setTile;   // 設置するタイル

    protected override void OnCollisionEnter2D(Collision2D collision)
    {// タイルとの接触処理

        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

        if (tileMap.GetTile(cellPosition) != null)
        {
            // 接触タイル名取得
            string name = base.GetCurrentTileName();

            if (name.Equals("Wall") == false &&
                name.Equals("OuterWall") == false)
            {
                // セル座標にタイルを設定
                tileMap.SetTile(cellPosition, setTile);
            }
        }
    }
}
