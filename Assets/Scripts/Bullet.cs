using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;      //弾の初期速度
    [SerializeField] Vector2 direction;// 弾の移動方向

    void Start()
    {
        //初期速度と方向で弾を発射
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    /// <summary>
    /// 弾が衝突したときの処理
    /// </summary>
    /// <param name="other">接触物の情報</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            //Lineタグが付いたオブジェクトに当たったら速度を0
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            direction = Vector2.zero;// 方向ベクトルも0(停止）
            EnableGravity();//重力を有効にする
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 弾の移動方向を設定
    /// </summary>
    /// <param name="dir">方向</param>
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    /// <summary>
    /// 重力を有効
    /// </summary>
    private void EnableGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}