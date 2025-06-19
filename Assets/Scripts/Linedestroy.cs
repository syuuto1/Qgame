using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Linedestroy : MonoBehaviour
{
    [SerializeField] Material[] ColorSprite;//配列でマテリアルを指定
    private int HitCount = 0;               //衝突回数のカウント
    [SerializeField] int Count;             //破壊に必要な衝突回数
    public GameObject effectPrefab;         //エフェクトのプレハブ

    /// <summary>
    /// 何かに衝突したときの処理
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("Hit");

            HitCount++;

            //ColorSprite配列の次のマテリアルに変更
            int materialIndex = HitCount % ColorSprite.Length;
            GetComponent<Renderer>().material = ColorSprite[materialIndex];

            //もし衝突回数が規定回数以上ならオブジェクトを破壊
            if (HitCount > Count)
            {
                //エフェクトの位置を衝突位置に設定
                Vector2 collisionPoint = collision.contacts[0].point;
                GameObject effect = Instantiate(effectPrefab, collisionPoint, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}