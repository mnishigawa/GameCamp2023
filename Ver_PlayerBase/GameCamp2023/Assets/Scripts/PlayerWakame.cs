using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWakame : game.PlayerBase
{
    
    // MonoBehaviourによる初期化処理
    protected virtual void Start()
    {
        FireFlag = false;
    }

    // MonoBehaviourによる更新処理
    protected virtual void Update()
    {
        if (FireFlag == true)
        {
            Fire();
        }
    }

    // 移動処理 GameMainのUpdateから呼ばれる
    public virtual void Move(game.PlayerInput.InputStatus inputStatus, Tilemap tileMap)
    {
        Vector3 MoveAxis = new Vector3();
        MoveAxis = Vector3.zero;
        if (inputStatus.UP == true)
        {
            MoveAxis.x += MoveSpeed;
        }
        if (inputStatus.DOWN == true)
        {
            MoveAxis.x -= MoveSpeed;
        }
        if (inputStatus.LEFT == true)
        {
            MoveAxis.y -= MoveSpeed;
        }
        if (inputStatus.RIGHT == true)
        {
            MoveAxis.x += MoveSpeed;
        }
        if (inputStatus.FIRE == true)
        {
            FireFlag = true;
        }

        Vector3Int cellPosition = tileMap.WorldToCell(transform.position);

        //tileMap.SetTile(cellPosition, redTile);

        transform.Translate(MoveAxis.x, MoveAxis.y, 0.0f, Space.Self);

    }

    protected virtual void Fire()
    {
        // 弾発射
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // タイルとの接触処理
    }

}
