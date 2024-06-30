using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linedestroy : MonoBehaviour
{
    [SerializeField] Material[] ColorSprite;  // �z��Ń}�e���A�����w��
    private int HitCount = 0;  // �Փˉ񐔂̃J�E���g
    [SerializeField] int Count;  // �j��ɕK�v�ȏՓˉ�

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("Hit");

            // �Փˉ񐔂𑝂₷
            HitCount++;

            // ColorSprite�z��̎��̃}�e���A���ɕύX
            int materialIndex = HitCount % ColorSprite.Length;
            GetComponent<Renderer>().material = ColorSprite[materialIndex];

            // �����Փˉ񐔂��K��񐔈ȏ�Ȃ�I�u�W�F�N�g��j�󂷂�
            if (HitCount > Count)
            {
                // �I�u�W�F�N�g��j��
                Destroy(gameObject);
            }
        }
    }
}