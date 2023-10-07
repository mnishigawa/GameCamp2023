using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestPlayerControler : MonoBehaviour
{


    [SerializeField]
    float fMoveValue = 0.01f; // 移動速度

    [SerializeField]
    Tilemap tilemap;    // タイルマップのオブジェクト

    [SerializeField]
    Tile redTile;       // 赤いタイルのオブジェクト

    [SerializeField]
    Sprite sprite;      // スプライトのオブジェクト

    Vector3 move;       // 移動量

    //=================================================
    // 初期化処理
    //=================================================
    void Start()
    {
        
    }

    //=================================================
    // 更新処理
    //=================================================
    void Update()
    {

#if true
        // キーボード操作
        ControllKeyboard();

        // プレイヤーの位置をセル座標に変換
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

        // セル座標に赤いタイルを設定
        tilemap.SetTile(cellPosition, redTile);
#endif

        // ローカル座標移動
        transform.Translate(move.x, move.y, 0.0f, Space.Self);
    }

    //=================================================
    // キーボード操作
    //=================================================
    private void ControllKeyboard()
    {
        if (Input.GetKey(KeyCode.A))
        {// Aが押されてたら, 左移動

            if (Input.GetKey(KeyCode.S))
            {// Sが押されてたら, 左下移動

                move.x += Mathf.Sin(Mathf.PI * -0.75f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * -0.75f) * fMoveValue;
            }
            else if (Input.GetKey(KeyCode.W))
            {// Wが押されてたら, 左上移動

                move.x += Mathf.Sin(Mathf.PI * -0.25f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * -0.25f) * fMoveValue;
            }
            else
            {// Aが押されてたら, 左移動

                move.x += Mathf.Sin(Mathf.PI * -0.5f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * -0.5f) * fMoveValue;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {// Dが押されてたら, 右移動

            if (Input.GetKey(KeyCode.S))
            {// Sが押されてたら, 右下移動

                move.x += Mathf.Sin(Mathf.PI * 0.75f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * 0.75f) * fMoveValue;
            }
            else if (Input.GetKey(KeyCode.W))
            {// Wが押されてたら, 右上移動

                move.x += Mathf.Sin(Mathf.PI * 0.25f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * 0.25f) * fMoveValue;
            }
            else
            {// Aが押されてたら, 右移動

                move.x += Mathf.Sin(Mathf.PI * 0.5f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * 0.5f) * fMoveValue;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {// Wが押されてたら, 上移動

            move.x += Mathf.Sin(Mathf.PI * 0.0f) * fMoveValue;
            move.y += Mathf.Cos(Mathf.PI * 0.0f) * fMoveValue;
        }
        else if (Input.GetKey(KeyCode.S))
        {// Sが押されてたら, 下移動

            move.x += Mathf.Sin(Mathf.PI * 1.0f) * fMoveValue;
            move.y += Mathf.Cos(Mathf.PI * 1.0f) * fMoveValue;
        }

        // 慣性補正
        move.x += (0.0f - move.x) * 0.25f;
        move.y += (0.0f - move.y) * 0.25f;
    }

    // ゾウがウニ潰す、他が食べ食べられ
    void OnTriggerEnter2D(Collider2D collision)
    {// 何かに当たった
        int n = 0;
    }

    // ゾウが水の上にいる時用
    void OnTriggerStay2D(Collider2D collision)
    {// 何かに当たった
        int n = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // タイル判定(失敗カモ)
#if false
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            // 取り出した位置情報からタイルマップ用の位置情報(セル座標)を取得
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            // tilemap.HasTile->タイルが設定(描画)されている座標であるか判定
            if (tilemap.HasTile(cellPosition))
            {
                // スプライトが一致しているか判定
                if (tilemap.GetSprite(cellPosition) == sprite)
                {
                    // 特定のスプライトと一致している場合は別のタイルを設定する
                    tilemap.SetColor(cellPosition, Color.red);
                }
            }
        }
#endif
    }
}
