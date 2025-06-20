using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;      //�e�̏������x
    [SerializeField] Vector2 direction;// �e�̈ړ�����

    void Start()
    {
        //�������x�ƕ����Œe�𔭎�
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    /// <summary>
    /// �e���Փ˂����Ƃ��̏���
    /// </summary>
    /// <param name="other">�ڐG���̏��</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            //Line�^�O���t�����I�u�W�F�N�g�ɓ��������瑬�x��0
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            direction = Vector2.zero;// �����x�N�g����0(��~�j
            EnableGravity();//�d�͂�L���ɂ���
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �e�̈ړ�������ݒ�
    /// </summary>
    /// <param name="dir">����</param>
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    /// <summary>
    /// �d�͂�L��
    /// </summary>
    private void EnableGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}