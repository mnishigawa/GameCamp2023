using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 移動速度
    [SerializeField]
    float fMove;

    //回転角度
    [SerializeField]
    float fAngle;

    [SerializeField]
    private GameObject m_BulletPrefab;

    private Vector3 m_move; // 移動量

    // N-WAY
    [SerializeField]
    private int nWayNum;

    // 移動判定
    private bool bMove;
    private bool bMoveAnim;
    private bool bControll;

    // 状態
    private enum STATE
    {
        NONE,       // 何もなし
        DAMAGE,     // ダメージ状態
        INVINCIBLE, // 無敵
        MAX
    }

    // 状態
    private STATE m_state;

    // 状態遷移カウンター
    private int m_nCntState;

    // 不透明度
    private float m_fAlpha = 1.0f;

    [SerializeField]
    private int m_nLife = 5;
    private int m_nMaxLife;

    // Start is called before the first frame update
    void Start()
    {
        // 最大体力保存
        m_nMaxLife = m_nLife;
        bControll = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 操作処理
        if (bControll == true)
        {
            Controll();
        }

        // アニメーション情報取得
        Animator animator = GetComponent<Animator>();

        if (bMove == true && bMoveAnim == false)
        {// 移動中 && アニメーションしてなかったら
            animator.Play("walk", 0, 0);
            bMoveAnim = true;
        }

        if (m_move.x < 0.01f && m_move.x > -0.01f && m_move.y < 0.01f && m_move.y > -0.01f)
        {
            // 移動状態停止
            bMove = false;

            if (bMoveAnim == true)
            {
                animator.Play("Player", 0, 0);
                bMoveAnim = false;
            }
        }

        // 状態更新処理
        State();

        if (m_state != STATE.INVINCIBLE)
        {
            // 画面外判定
            OutsideScreenCheck();
        }
    }

    //=====================================================
    // 操作処理
    //=====================================================
    private void Controll()
    {
        // アタッチされてるUIManagerのインスタンスを取得
        UIManager UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (UImanager.EndFrag == true)
        {// 終了していたら
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {// Aが押されてたら, 左移動

            if (Input.GetKey(KeyCode.S))
            {// Sが押されてたら, 左下移動

                m_move.x += Mathf.Sin(Mathf.PI * -0.75f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * -0.75f) * fMove;
            }
            else if (Input.GetKey(KeyCode.W))
            {// Wが押されてたら, 左上移動

                m_move.x += Mathf.Sin(Mathf.PI * -0.25f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * -0.25f) * fMove;
            }
            else
            {// Aが押されてたら, 左移動

                m_move.x += Mathf.Sin(Mathf.PI * -0.5f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * -0.5f) * fMove;
            }

            // 移動状態
            bMove = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {// Dが押されてたら, 右移動

            if (Input.GetKey(KeyCode.S))
            {// Sが押されてたら, 右下移動

                m_move.x += Mathf.Sin(Mathf.PI * 0.75f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * 0.75f) * fMove;
            }
            else if (Input.GetKey(KeyCode.W))
            {// Wが押されてたら, 右上移動

                m_move.x += Mathf.Sin(Mathf.PI * 0.25f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * 0.25f) * fMove;
            }
            else
            {// Aが押されてたら, 右移動

                m_move.x += Mathf.Sin(Mathf.PI * 0.5f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * 0.5f) * fMove;
            }

            // 移動状態
            bMove = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {// Wが押されてたら, 上移動

            m_move.x += Mathf.Sin(Mathf.PI * 0.0f) * fMove;
            m_move.y += Mathf.Cos(Mathf.PI * 0.0f) * fMove;

            // 移動状態
            bMove = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {// Sが押されてたら, 下移動

            m_move.x += Mathf.Sin(Mathf.PI * 1.0f) * fMove;
            m_move.y += Mathf.Cos(Mathf.PI * 1.0f) * fMove;

            // 移動状態
            bMove = true;
        }

        // 移動する
        transform.position += m_move;

        // 慣性
        m_move.x += (0.0f - m_move.x) * 0.25f;
        m_move.y += (0.0f - m_move.y) * 0.25f;

        // プレイヤー情報
        Vector3 pos = transform.position,
                rot = transform.eulerAngles,
                scale = transform.localScale;

        if (Input.GetKeyDown(KeyCode.Space))
        {// 弾発射

            // アニメーション情報取得
            Animator animator = GetComponent<Animator>();

            // アニメーション再生
            animator.Play("walk", 0, 0);

            float fOneRot = 180.0f / (float)(nWayNum + 1);
            for (int nCntWay = 0; nCntWay < nWayNum; nCntWay++)
            {
                // 通常弾を生成  
                GameObject obj = Instantiate(m_BulletPrefab);
                Bullet bullet = obj.GetComponent<Bullet>();
                bullet.transform.position = pos;
                bullet.transform.Rotate(0.0f, 0.0f, -90.0f + 180.0f - fOneRot * (nCntWay + 1));
            }
        }
    }

    //=====================================================
    // 画面外判定
    //=====================================================
    private void OutsideScreenCheck()
    {
        // プレイヤー情報
        Vector3 pos = transform.position,
                rot = transform.eulerAngles,
                scale = transform.localScale;

        // 画面のサイズ取得
        Vector3 LeftDown = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector3 RightUp = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // スプライトサイズ取得
        float fWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float fHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // 画面外判定
        pos.x = Mathf.Clamp(pos.x, LeftDown.x + fWidth / 2.0f, RightUp.x - fWidth / 2.0f);
        pos.y = Mathf.Clamp(pos.y, LeftDown.y + fHeight / 2.0f, RightUp.y - fHeight / 2.0f);

        // 位置反映
        transform.position = pos;
    }

    //=====================================================
    // 当たり判定
    //=====================================================
    void OnTriggerEnter2D(Collider2D collision)
    {// 何かに当たった

        // アタッチされてるUIManagerのインスタンスを取得
        UIManager UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (UImanager.EndFrag == true)
        {// 終了していたら
            return;
        }

            if (collision.gameObject.CompareTag("Enemy"))
        {// 敵だったら

            // インスタンス生成
            Instantiate(Resources.Load("explosion000_0"), transform.position, Quaternion.identity);

            // 残機減らす
            if (m_state == STATE.NONE)
            {
                if (HitDamage(50) == true)
                {// 死んでたら残機減らす

                    // 残機減らす
                    if (UImanager.AddLife(-1) == true)
                    {// 死んでたら完全に削除

                        if (UImanager.EndFrag == false)
                        {// なくなったら
                            // ゲームオーバーの設定
                            UImanager.SetEndText(UIManager.ENDTYPE.GAMEOVER);
                        }

                        // インスタンス生成
                        Instantiate(Resources.Load("explosion000_0"), transform.position, Quaternion.identity);

                        // 相手を削除
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    //=====================================================
    // ヒット処理
    //=====================================================
    public bool HitDamage(int nValue)
    {
        // アタッチされてるUIManagerのインスタンスを取得
        UIManager UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (UImanager.EndFrag == true)
        {// 終了していたら
            return false;
        }

        if (m_state != STATE.NONE)
        {// 通常じゃなければ
            return false;
        }

        // 体力減らす
        m_nLife -= nValue;

        m_nCntState = 5;
        m_state = STATE.DAMAGE;

        if (m_nLife <= 0)
        {// 0以下で死亡

            // ライフリセット
            m_nLife = m_nMaxLife;

            // 移動不可状態
            bControll = false;

            // 移動量リセット
            m_move = new Vector3(0.0f, 0.0f, 0.0f);

            // 無敵状態に設定
            m_nCntState = 90;
            m_state = STATE.INVINCIBLE;

            // 移動する
            transform.position = new Vector3(-11.0f, 0.0f);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 状態更新
    /// </summary>
    protected void State()
    {
        switch (m_state)
        {
            case STATE.NONE:

                // 通常に戻す
                GetComponent<SpriteRenderer>().material.color = Color.white;
                break;

            case STATE.DAMAGE:

                // ダメージ色変更
                GetComponent<SpriteRenderer>().material.color = Color.red;

                // 状態遷移カウンター減算
                m_nCntState--;

                if (m_nCntState <= 0)
                {// 0を下回ったら

                    // リセット
                    m_nCntState = 0;
                    m_state = STATE.NONE;
                }
                break;

            case STATE.INVINCIBLE:

                m_fAlpha = Mathf.Sin(Mathf.PI * ((float)m_nCntState / (10.0f)));

                // 点滅
                Color color = new Color(1.0f, 1.0f, 1.0f, m_fAlpha);
                GetComponent<SpriteRenderer>().material.color = color;

                // プレイヤー情報
                Vector3 pos = transform.position;

                // 移動する
                pos.x += (-6.0f - transform.position.x) * 0.05f;
                transform.position = pos;

                // 状態遷移カウンター減算
                m_nCntState--;

                if(m_nCntState <= 30)
                {
                    bControll = true;
                }

                if (m_nCntState <= 0)
                {// 0を下回ったら

                    // リセット
                    m_nCntState = 0;
                    m_state = STATE.NONE;
                }
                break;
        }
    }

}
