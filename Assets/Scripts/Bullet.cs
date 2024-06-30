using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed; // �e�̏������x
    [SerializeField] Vector2 direction; // �e�̈ړ�����
    //private bool isGravityEnabled = false; // �d�̗͂L��/�����̃t���O

    void Start()
    {
        // �������x�ƕ����Œe�𔭎˂���
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // �e�������ɏՓ˂����Ƃ��̏���
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            // Line�^�O���t�����I�u�W�F�N�g�ɓ��������瑬�x��0�ɂ���
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // �����x�N�g����0�ɂ���i��~����j
            direction = Vector2.zero;

            // �d�͂�L���ɂ���
            EnableGravity();
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    // �O������e�̈ړ�������ݒ肷�邽�߂̃��\�b�h
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    // �d�͂�L���ɂ��郁�\�b�h
    private void EnableGravity()
    {
        //isGravityEnabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}