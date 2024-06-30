using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trackingbullet : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] Vector2 direction; // �e�̈ړ�����
    [SerializeField] float RotateSpeed;
    [SerializeField] float angle;

    private bool tracking = true;

    void Start()
    {
        // �������x�ƕ����Œe�𔭎˂���
        //GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void Update()
    {
        if (tracking)
        {
            Tracking();
        }
    }

    // �e�������ɏՓ˂����Ƃ��̏���
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            // Line�^�O���t�����I�u�W�F�N�g�ɓ��������瑬�x��0�ɂ���
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // �����x�N�g����0�ɂ���i��~����j
            //direction = Vector2.zero;

            // �d�͂�L���ɂ���
            EnableGravity();

            // �ǐՂ𖳌��ɂ���
            tracking = false;
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    // �d�͂�L���ɂ��郁�\�b�h
    void EnableGravity()
    {
        //isGravityEnabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void Tracking()
    {
        // �}�E�X�̈ʒu���擾���A���[���h���W�ɕϊ�
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // �e���ŐV�̃}�E�X�ʒu�Ɍ������Ĉړ�������
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, step);

        angle += RotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}