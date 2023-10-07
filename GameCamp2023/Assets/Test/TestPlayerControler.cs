using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestPlayerControler : MonoBehaviour
{


    [SerializeField]
    float fMoveValue = 0.01f; // �ړ����x

    [SerializeField]
    Tilemap tilemap;    // �^�C���}�b�v�̃I�u�W�F�N�g

    [SerializeField]
    Tile redTile;       // �Ԃ��^�C���̃I�u�W�F�N�g

    [SerializeField]
    Sprite sprite;      // �X�v���C�g�̃I�u�W�F�N�g

    Vector3 move;       // �ړ���

    //=================================================
    // ����������
    //=================================================
    void Start()
    {
        
    }

    //=================================================
    // �X�V����
    //=================================================
    void Update()
    {

#if true
        // �L�[�{�[�h����
        ControllKeyboard();

        // �v���C���[�̈ʒu���Z�����W�ɕϊ�
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

        // �Z�����W�ɐԂ��^�C����ݒ�
        tilemap.SetTile(cellPosition, redTile);
#endif

        // ���[�J�����W�ړ�
        transform.Translate(move.x, move.y, 0.0f, Space.Self);
    }

    //=================================================
    // �L�[�{�[�h����
    //=================================================
    private void ControllKeyboard()
    {
        if (Input.GetKey(KeyCode.A))
        {// A��������Ă���, ���ړ�

            if (Input.GetKey(KeyCode.S))
            {// S��������Ă���, �����ړ�

                move.x += Mathf.Sin(Mathf.PI * -0.75f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * -0.75f) * fMoveValue;
            }
            else if (Input.GetKey(KeyCode.W))
            {// W��������Ă���, ����ړ�

                move.x += Mathf.Sin(Mathf.PI * -0.25f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * -0.25f) * fMoveValue;
            }
            else
            {// A��������Ă���, ���ړ�

                move.x += Mathf.Sin(Mathf.PI * -0.5f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * -0.5f) * fMoveValue;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {// D��������Ă���, �E�ړ�

            if (Input.GetKey(KeyCode.S))
            {// S��������Ă���, �E���ړ�

                move.x += Mathf.Sin(Mathf.PI * 0.75f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * 0.75f) * fMoveValue;
            }
            else if (Input.GetKey(KeyCode.W))
            {// W��������Ă���, �E��ړ�

                move.x += Mathf.Sin(Mathf.PI * 0.25f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * 0.25f) * fMoveValue;
            }
            else
            {// A��������Ă���, �E�ړ�

                move.x += Mathf.Sin(Mathf.PI * 0.5f) * fMoveValue;
                move.y += Mathf.Cos(Mathf.PI * 0.5f) * fMoveValue;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {// W��������Ă���, ��ړ�

            move.x += Mathf.Sin(Mathf.PI * 0.0f) * fMoveValue;
            move.y += Mathf.Cos(Mathf.PI * 0.0f) * fMoveValue;
        }
        else if (Input.GetKey(KeyCode.S))
        {// S��������Ă���, ���ړ�

            move.x += Mathf.Sin(Mathf.PI * 1.0f) * fMoveValue;
            move.y += Mathf.Cos(Mathf.PI * 1.0f) * fMoveValue;
        }

        // �����␳
        move.x += (0.0f - move.x) * 0.25f;
        move.y += (0.0f - move.y) * 0.25f;
    }

    // �]�E���E�j�ׂ��A�����H�אH�ׂ��
    void OnTriggerEnter2D(Collider2D collision)
    {// �����ɓ�������
        int n = 0;
    }

    // �]�E�����̏�ɂ��鎞�p
    void OnTriggerStay2D(Collider2D collision)
    {// �����ɓ�������
        int n = 0;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // �^�C������(���s�J��)
#if false
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            // ���o�����ʒu��񂩂�^�C���}�b�v�p�̈ʒu���(�Z�����W)���擾
            Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);

            // tilemap.HasTile->�^�C�����ݒ�(�`��)����Ă�����W�ł��邩����
            if (tilemap.HasTile(cellPosition))
            {
                // �X�v���C�g����v���Ă��邩����
                if (tilemap.GetSprite(cellPosition) == sprite)
                {
                    // ����̃X�v���C�g�ƈ�v���Ă���ꍇ�͕ʂ̃^�C����ݒ肷��
                    tilemap.SetColor(cellPosition, Color.red);
                }
            }
        }
#endif
    }
}
