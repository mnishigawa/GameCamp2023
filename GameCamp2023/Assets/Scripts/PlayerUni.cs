using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerUni : game.PlayerBase
{
    [SerializeField]
    TileBase setTile;   // 設置するタイル

    [SerializeField]
    GameObject miniUniPrefab;    // 生成するうに

    public override bool ReplaceTile()
    {// タイルとの接触処理

        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

        if (tileMap.GetTile(cellPosition) == null)
        {
            return true;
        }

        // 接触タイル名取得
        string name = game.GameMain.GetCurrentTile(transform.position, tileMap).name;

        if (name.Equals("Wall") == false &&
            name.Equals("OuterWall") == false)
        {
            // セル座標にタイルを設定
            tileMap.SetTile(cellPosition, setTile);
            return true;
        }

        return false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var type = collision.gameObject.GetComponent<ObjectType>();

        if(type != null)
        {
            if(type.type == game.GameMain.ObjectType.MINIWAKAME)
            {
                // みにうに生成
                GameObject.Instantiate(miniUniPrefab, transform.position, Quaternion.identity);
                // みにわかめ消す
                Destroy(collision.gameObject);
            } 
        }
    }

}
