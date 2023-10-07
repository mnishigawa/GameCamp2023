using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �ړ����x
    [SerializeField]
    float fMove;

    //��]�p�x
    [SerializeField]
    float fAngle;

    [SerializeField]
    private GameObject m_BulletPrefab;

    private Vector3 m_move; // �ړ���

    // N-WAY
    [SerializeField]
    private int nWayNum;

    // �ړ�����
    private bool bMove;
    private bool bMoveAnim;
    private bool bControll;

    // ���
    private enum STATE
    {
        NONE,       // �����Ȃ�
        DAMAGE,     // �_���[�W���
        INVINCIBLE, // ���G
        MAX
    }

    // ���
    private STATE m_state;

    // ��ԑJ�ڃJ�E���^�[
    private int m_nCntState;

    // �s�����x
    private float m_fAlpha = 1.0f;

    [SerializeField]
    private int m_nLife = 5;
    private int m_nMaxLife;

    // Start is called before the first frame update
    void Start()
    {
        // �ő�̗͕ۑ�
        m_nMaxLife = m_nLife;
        bControll = true;
    }

    // Update is called once per frame
    void Update()
    {
        // ���쏈��
        if (bControll == true)
        {
            Controll();
        }

        // �A�j���[�V�������擾
        Animator animator = GetComponent<Animator>();

        if (bMove == true && bMoveAnim == false)
        {// �ړ��� && �A�j���[�V�������ĂȂ�������
            animator.Play("walk", 0, 0);
            bMoveAnim = true;
        }

        if (m_move.x < 0.01f && m_move.x > -0.01f && m_move.y < 0.01f && m_move.y > -0.01f)
        {
            // �ړ���Ԓ�~
            bMove = false;

            if (bMoveAnim == true)
            {
                animator.Play("Player", 0, 0);
                bMoveAnim = false;
            }
        }

        // ��ԍX�V����
        State();

        if (m_state != STATE.INVINCIBLE)
        {
            // ��ʊO����
            OutsideScreenCheck();
        }
    }

    //=====================================================
    // ���쏈��
    //=====================================================
    private void Controll()
    {
        // �A�^�b�`����Ă�UIManager�̃C���X�^���X���擾
        UIManager UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (UImanager.EndFrag == true)
        {// �I�����Ă�����
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {// A��������Ă���, ���ړ�

            if (Input.GetKey(KeyCode.S))
            {// S��������Ă���, �����ړ�

                m_move.x += Mathf.Sin(Mathf.PI * -0.75f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * -0.75f) * fMove;
            }
            else if (Input.GetKey(KeyCode.W))
            {// W��������Ă���, ����ړ�

                m_move.x += Mathf.Sin(Mathf.PI * -0.25f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * -0.25f) * fMove;
            }
            else
            {// A��������Ă���, ���ړ�

                m_move.x += Mathf.Sin(Mathf.PI * -0.5f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * -0.5f) * fMove;
            }

            // �ړ����
            bMove = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {// D��������Ă���, �E�ړ�

            if (Input.GetKey(KeyCode.S))
            {// S��������Ă���, �E���ړ�

                m_move.x += Mathf.Sin(Mathf.PI * 0.75f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * 0.75f) * fMove;
            }
            else if (Input.GetKey(KeyCode.W))
            {// W��������Ă���, �E��ړ�

                m_move.x += Mathf.Sin(Mathf.PI * 0.25f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * 0.25f) * fMove;
            }
            else
            {// A��������Ă���, �E�ړ�

                m_move.x += Mathf.Sin(Mathf.PI * 0.5f) * fMove;
                m_move.y += Mathf.Cos(Mathf.PI * 0.5f) * fMove;
            }

            // �ړ����
            bMove = true;
        }
        else if (Input.GetKey(KeyCode.W))
        {// W��������Ă���, ��ړ�

            m_move.x += Mathf.Sin(Mathf.PI * 0.0f) * fMove;
            m_move.y += Mathf.Cos(Mathf.PI * 0.0f) * fMove;

            // �ړ����
            bMove = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {// S��������Ă���, ���ړ�

            m_move.x += Mathf.Sin(Mathf.PI * 1.0f) * fMove;
            m_move.y += Mathf.Cos(Mathf.PI * 1.0f) * fMove;

            // �ړ����
            bMove = true;
        }

        // �ړ�����
        transform.position += m_move;

        // ����
        m_move.x += (0.0f - m_move.x) * 0.25f;
        m_move.y += (0.0f - m_move.y) * 0.25f;

        // �v���C���[���
        Vector3 pos = transform.position,
                rot = transform.eulerAngles,
                scale = transform.localScale;

        if (Input.GetKeyDown(KeyCode.Space))
        {// �e����

            // �A�j���[�V�������擾
            Animator animator = GetComponent<Animator>();

            // �A�j���[�V�����Đ�
            animator.Play("walk", 0, 0);

            float fOneRot = 180.0f / (float)(nWayNum + 1);
            for (int nCntWay = 0; nCntWay < nWayNum; nCntWay++)
            {
                // �ʏ�e�𐶐�  
                GameObject obj = Instantiate(m_BulletPrefab);
                Bullet bullet = obj.GetComponent<Bullet>();
                bullet.transform.position = pos;
                bullet.transform.Rotate(0.0f, 0.0f, -90.0f + 180.0f - fOneRot * (nCntWay + 1));
            }
        }
    }

    //=====================================================
    // ��ʊO����
    //=====================================================
    private void OutsideScreenCheck()
    {
        // �v���C���[���
        Vector3 pos = transform.position,
                rot = transform.eulerAngles,
                scale = transform.localScale;

        // ��ʂ̃T�C�Y�擾
        Vector3 LeftDown = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector3 RightUp = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // �X�v���C�g�T�C�Y�擾
        float fWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        float fHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // ��ʊO����
        pos.x = Mathf.Clamp(pos.x, LeftDown.x + fWidth / 2.0f, RightUp.x - fWidth / 2.0f);
        pos.y = Mathf.Clamp(pos.y, LeftDown.y + fHeight / 2.0f, RightUp.y - fHeight / 2.0f);

        // �ʒu���f
        transform.position = pos;
    }

    //=====================================================
    // �����蔻��
    //=====================================================
    void OnTriggerEnter2D(Collider2D collision)
    {// �����ɓ�������

        // �A�^�b�`����Ă�UIManager�̃C���X�^���X���擾
        UIManager UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (UImanager.EndFrag == true)
        {// �I�����Ă�����
            return;
        }

            if (collision.gameObject.CompareTag("Enemy"))
        {// �G��������

            // �C���X�^���X����
            Instantiate(Resources.Load("explosion000_0"), transform.position, Quaternion.identity);

            // �c�@���炷
            if (m_state == STATE.NONE)
            {
                if (HitDamage(50) == true)
                {// ����ł���c�@���炷

                    // �c�@���炷
                    if (UImanager.AddLife(-1) == true)
                    {// ����ł��犮�S�ɍ폜

                        if (UImanager.EndFrag == false)
                        {// �Ȃ��Ȃ�����
                            // �Q�[���I�[�o�[�̐ݒ�
                            UImanager.SetEndText(UIManager.ENDTYPE.GAMEOVER);
                        }

                        // �C���X�^���X����
                        Instantiate(Resources.Load("explosion000_0"), transform.position, Quaternion.identity);

                        // ������폜
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    //=====================================================
    // �q�b�g����
    //=====================================================
    public bool HitDamage(int nValue)
    {
        // �A�^�b�`����Ă�UIManager�̃C���X�^���X���擾
        UIManager UImanager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (UImanager.EndFrag == true)
        {// �I�����Ă�����
            return false;
        }

        if (m_state != STATE.NONE)
        {// �ʏ킶��Ȃ����
            return false;
        }

        // �̗͌��炷
        m_nLife -= nValue;

        m_nCntState = 5;
        m_state = STATE.DAMAGE;

        if (m_nLife <= 0)
        {// 0�ȉ��Ŏ��S

            // ���C�t���Z�b�g
            m_nLife = m_nMaxLife;

            // �ړ��s���
            bControll = false;

            // �ړ��ʃ��Z�b�g
            m_move = new Vector3(0.0f, 0.0f, 0.0f);

            // ���G��Ԃɐݒ�
            m_nCntState = 90;
            m_state = STATE.INVINCIBLE;

            // �ړ�����
            transform.position = new Vector3(-11.0f, 0.0f);
            return true;
        }

        return false;
    }

    /// <summary>
    /// ��ԍX�V
    /// </summary>
    protected void State()
    {
        switch (m_state)
        {
            case STATE.NONE:

                // �ʏ�ɖ߂�
                GetComponent<SpriteRenderer>().material.color = Color.white;
                break;

            case STATE.DAMAGE:

                // �_���[�W�F�ύX
                GetComponent<SpriteRenderer>().material.color = Color.red;

                // ��ԑJ�ڃJ�E���^�[���Z
                m_nCntState--;

                if (m_nCntState <= 0)
                {// 0�����������

                    // ���Z�b�g
                    m_nCntState = 0;
                    m_state = STATE.NONE;
                }
                break;

            case STATE.INVINCIBLE:

                m_fAlpha = Mathf.Sin(Mathf.PI * ((float)m_nCntState / (10.0f)));

                // �_��
                Color color = new Color(1.0f, 1.0f, 1.0f, m_fAlpha);
                GetComponent<SpriteRenderer>().material.color = color;

                // �v���C���[���
                Vector3 pos = transform.position;

                // �ړ�����
                pos.x += (-6.0f - transform.position.x) * 0.05f;
                transform.position = pos;

                // ��ԑJ�ڃJ�E���^�[���Z
                m_nCntState--;

                if(m_nCntState <= 30)
                {
                    bControll = true;
                }

                if (m_nCntState <= 0)
                {// 0�����������

                    // ���Z�b�g
                    m_nCntState = 0;
                    m_state = STATE.NONE;
                }
                break;
        }
    }

}
