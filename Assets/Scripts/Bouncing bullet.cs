using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncingbullet : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private int groundHitCount = 0;   //�n�ʂƂ̏Փˉ�
    private Collider2D bulletCollider;//�e�̓����蔻��

    [SerializeField] int Count;       //�n�ʂɃo�E���h�ł���ő��

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<Collider2D>();
    }

    /// <summary>
    /// �����ɏՓ˂����Ƃ��̏���
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            groundHitCount++;

            if (groundHitCount >= Count)
            {
                bulletCollider.enabled = false;      //Collider�𖳌��ɂ���
                Invoke(nameof(BulletCollider), 1.5f);//1.5�b���Collider��L��
            }

        }

        if (collision.collider.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// Collider��L��
    /// </summary>
    private void BulletCollider()
    {
        bulletCollider.enabled = true;
    }

}
