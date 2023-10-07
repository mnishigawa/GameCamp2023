using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerZou : game.PlayerBase
{
    [SerializeField]
    TileBase setTile;   // 設置するタイル

    [SerializeField]
    GameObject bulletobj;

    // 弾発射
    protected override void Fire()
    {
        // 弾を生成
        GameObject obj = Instantiate(bulletobj);
        obj.transform.position = transform.position;

        // 発射方向の設定
        game.Bullet bullet = obj.GetComponent<game.Bullet>();
        bullet.SetAngle(game.Bullet.BulletAngle.DOWN);
    }

    // 接触処理
    public override bool ReplaceTile()
    {
        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

        if (tileMap.GetTile(cellPosition) == null)
        {
            return true;
        }

        // 接触タイル名取得
        string name = base.GetCurrentTileName();

        if (name.Equals("Wall") == false &&
            name.Equals("OuterWall") == false &&
            name.Equals("BlueTile") == false)
        {
            // セル座標にタイルを設定
            tileMap.SetTile(cellPosition, setTile);
            return true;
        }

        return false;
    }
}