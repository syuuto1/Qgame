using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed; // 弾の初期速度
    [SerializeField] Vector2 direction; // 弾の移動方向
    //private bool isGravityEnabled = false; // 重力の有効/無効のフラグ

    void Start()
    {
        // 初期速度と方向で弾を発射する
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    // 弾が何かに衝突したときの処理
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            // Lineタグが付いたオブジェクトに当たったら速度を0にする
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // 方向ベクトルも0にする（停止する）
            direction = Vector2.zero;

            // 重力を有効にする
            EnableGravity();
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    // 外部から弾の移動方向を設定するためのメソッド
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    // 重力を有効にするメソッド
    private void EnableGravity()
    {
        //isGravityEnabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}