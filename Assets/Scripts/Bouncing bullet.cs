using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncingbullet : MonoBehaviour
{
    private Rigidbody2D Rigidbody;
    private int groundHitCount = 0;   //地面との衝突回数
    private Collider2D bulletCollider;//弾の当たり判定

    [SerializeField] int Count;       //地面にバウンドできる最大回数

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        bulletCollider = GetComponent<Collider2D>();
    }

    /// <summary>
    /// 何かに衝突したときの処理
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            groundHitCount++;

            if (groundHitCount >= Count)
            {
                bulletCollider.enabled = false;      //Colliderを無効にする
                Invoke(nameof(BulletCollider), 1.5f);//1.5秒後にColliderを有効
            }

        }

        if (collision.collider.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }

    }

    /// <summary>
    /// Colliderを有効
    /// </summary>
    private void BulletCollider()
    {
        bulletCollider.enabled = true;
    }

}
