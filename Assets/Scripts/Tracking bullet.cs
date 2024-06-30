using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trackingbullet : MonoBehaviour
{
    [SerializeField] float speed;
    //[SerializeField] Vector2 direction; // 弾の移動方向
    [SerializeField] float RotateSpeed;
    [SerializeField] float angle;

    private bool tracking = true;

    void Start()
    {
        // 初期速度と方向で弾を発射する
        //GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    void Update()
    {
        if (tracking)
        {
            Tracking();
        }
    }

    // 弾が何かに衝突したときの処理
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            // Lineタグが付いたオブジェクトに当たったら速度を0にする
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // 方向ベクトルも0にする（停止する）
            //direction = Vector2.zero;

            // 重力を有効にする
            EnableGravity();

            // 追跡を無効にする
            tracking = false;
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    // 重力を有効にするメソッド
    void EnableGravity()
    {
        //isGravityEnabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    void Tracking()
    {
        // マウスの位置を取得し、ワールド座標に変換
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 弾を最新のマウス位置に向かって移動させる
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, step);

        angle += RotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}