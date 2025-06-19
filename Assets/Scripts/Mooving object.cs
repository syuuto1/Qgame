using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovingobject : MonoBehaviour
{
    Vector2 startPos;                        //�����ʒu

    [SerializeField] float speed_x;          //�ړ����x
    [SerializeField] float distance_x;       //�ړ�����

    [SerializeField] float speed_y;
    [SerializeField] float distance_y;

    [SerializeField] GameObject bulletPrefab;//�e�̃v���n�u
    [SerializeField] float shootInterval;    //�e���˂̊Ԋu

    private float shootTimer;                //�e���˂̃^�C�}�[

    void Start()
    {
        startPos = transform.position; //���݂̈ʒu�������ʒu
    }


    void Update()
    {
        //x��
        float posX = startPos.x + Mathf.Cos(Time.time * speed_x) * distance_x;
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        //y��
        float posY = startPos.y + Mathf.Sin(Time.time * speed_y) * distance_y;
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);

        shooting();
    }

    /// <summary>
    /// �e�𔭎�
    /// </summary>
    void shooting()
    {

        shootTimer += Time.deltaTime;//�O�t���[������̌o�ߎ��Ԃ����Z

        //�^�C�}�[���ݒ肳�ꂽ���ˊԊu�ȏ�ɂȂ����ꍇ
        if (shootTimer >= shootInterval)
        {
            //���݈ʒu�Ƀv���n�u����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            shootTimer = 0.0f;
        }
    }

}
