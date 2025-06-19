using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trackingbullet : MonoBehaviour
{
    [SerializeField] float speed;      //�e�̈ړ����x
    [SerializeField] float RotateSpeed;//�e�̉�]���x
    [SerializeField] float angle;      //���݂̉�]�p�x

    private bool tracking = true;      //�ǐՋ@�\

    void Update()
    {
        //�ǐՂ��L���ȂƂ�
        if (tracking)
        {
            Tracking();
        }
    }

    /// <summary>
    /// �e�������ɏՓ˂����Ƃ��̏���
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            //Line�^�O���t�����I�u�W�F�N�g�ɓ��������瑬�x��0
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            EnableGravity(); //�d�͂�L���ɂ���
            tracking = false;//�ǐՂ𖳌��ɂ���
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// �d�͂�L��
    /// </summary>
    void EnableGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;//�d�͂̉e�����󂯂�悤��
    }

    /// <summary>
    /// �}�E�X�ǐՂƉ�]�̏���
    /// </summary>
    void Tracking()
    {
        //�}�E�X�̈ʒu���擾���A���[���h���W�ɕϊ�
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //�e���ŐV�̃}�E�X�ʒu�Ɍ������Ĉړ�������
        float step = speed * Time.deltaTime;//1�t���[��������̈ړ��������v�Z
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, step);

        //�e�̉�]�p�x�����Ԍo�߂ƂƂ��ɑ���������
        angle += RotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}