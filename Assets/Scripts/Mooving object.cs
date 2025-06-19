using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moovingobject : MonoBehaviour
{
    Vector2 startPos;                        //初期位置

    [SerializeField] float speed_x;          //移動速度
    [SerializeField] float distance_x;       //移動距離

    [SerializeField] float speed_y;
    [SerializeField] float distance_y;

    [SerializeField] GameObject bulletPrefab;//弾のプレハブ
    [SerializeField] float shootInterval;    //弾発射の間隔

    private float shootTimer;                //弾発射のタイマー

    void Start()
    {
        startPos = transform.position; //現在の位置を初期位置
    }


    void Update()
    {
        //x軸
        float posX = startPos.x + Mathf.Cos(Time.time * speed_x) * distance_x;
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        //y軸
        float posY = startPos.y + Mathf.Sin(Time.time * speed_y) * distance_y;
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);

        shooting();
    }

    /// <summary>
    /// 弾を発射
    /// </summary>
    void shooting()
    {

        shootTimer += Time.deltaTime;//前フレームからの経過時間を加算

        //タイマーが設定された発射間隔以上になった場合
        if (shootTimer >= shootInterval)
        {
            //現在位置にプレハブ生成
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            shootTimer = 0.0f;
        }
    }

}
