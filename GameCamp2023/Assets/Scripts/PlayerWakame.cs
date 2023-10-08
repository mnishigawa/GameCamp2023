using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerWakame : game.PlayerBase
{
    [SerializeField]
    TileBase setTile;   // 設置するタイル

    [SerializeField]
    GameObject miniWakamePrefab;    // 生成するわかめ

    public int wakameCreateNum = 5;

    public float miniWakameForce = 1f;

    public override string ReplaceTile()
    {// タイルとの接触処理

        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

        if (tileMap.GetTile(cellPosition) == null)
        {
            return string.Empty;
        }

        // 接触タイル名取得
        string name = game.GameMain.GetCurrentTile(transform.position, tileMap).name;

        if (name.Equals("BaseTile"))
        {
            // セル座標にタイルを設定
            tileMap.SetTile(cellPosition, setTile);
            return name;
        }

        return string.Empty;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var type = collision.gameObject.GetComponent<ObjectType>();

        if(type != null)
        {
            if(type.type == game.GameMain.ObjectType.WATER)
            {
                // みにわかめ生成
                Vector2 force = new Vector2();
                for(int i = 0; i < wakameCreateNum; i++)
                {
                    GameObject obj = GameObject.Instantiate(miniWakamePrefab, transform.position, Quaternion.identity);
                    force.x = Random.Range(-miniWakameForce, miniWakameForce);
                    force.y = Random.Range(-miniWakameForce, miniWakameForce);
                    obj.GetComponent<Rigidbody2D>().AddForce(force);
                }
                // 水消す
                Destroy(collision.gameObject);
            } 
        }
    }
}
