using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linedestroy : MonoBehaviour
{
    [SerializeField] Material[] ColorSprite;//�z��Ń}�e���A�����w��
    private int HitCount = 0;               //�Փˉ񐔂̃J�E���g
    [SerializeField] int Count;             //�j��ɕK�v�ȏՓˉ�
    public GameObject effectPrefab;         //�G�t�F�N�g�̃v���n�u

    /// <summary>
    /// �����ɏՓ˂����Ƃ��̏���
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("Hit");

            HitCount++;

            //ColorSprite�z��̎��̃}�e���A���ɕύX
            int materialIndex = HitCount % ColorSprite.Length;
            GetComponent<Renderer>().material = ColorSprite[materialIndex];

            //�����Փˉ񐔂��K��񐔈ȏ�Ȃ�I�u�W�F�N�g��j��
            if (HitCount > Count)
            {
                //�G�t�F�N�g�̈ʒu���Փˈʒu�ɐݒ�
                Vector2 collisionPoint = collision.contacts[0].point;
                GameObject effect = Instantiate(effectPrefab, collisionPoint, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}