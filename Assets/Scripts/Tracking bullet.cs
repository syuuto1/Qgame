using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Trackingbullet : MonoBehaviour
{
    [SerializeField] float speed;      //弾の移動速度
    [SerializeField] float RotateSpeed;//弾の回転速度
    [SerializeField] float angle;      //現在の回転角度

    private bool tracking = true;      //追跡機能

    void Update()
    {
        //追跡が有効なとき
        if (tracking)
        {
            Tracking();
        }
    }

    /// <summary>
    /// 弾が何かに衝突したときの処理
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Line"))
        {
            //Lineタグが付いたオブジェクトに当たったら速度を0
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            EnableGravity(); //重力を有効にする
            tracking = false;//追跡を無効にする
        }

        if (other.CompareTag("Destroy wall"))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 重力を有効
    /// </summary>
    void EnableGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;//重力の影響を受けるように
    }

    /// <summary>
    /// マウス追跡と回転の処理
    /// </summary>
    void Tracking()
    {
        //マウスの位置を取得し、ワールド座標に変換
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //弾を最新のマウス位置に向かって移動させる
        float step = speed * Time.deltaTime;//1フレームあたりの移動距離を計算
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, step);

        //弾の回転角度を時間経過とともに増加させる
        angle += RotateSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}