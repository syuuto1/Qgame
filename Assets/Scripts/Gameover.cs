using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    [SerializeField] Material[] ColorSprite;  // 配列でマテリアルを指定
    private int HitCount = 0;  // 衝突回数のカウント
    [SerializeField] int Count;  // 破壊に必要な衝突回数

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {

            // 衝突回数を増やす
            HitCount++;

            // ColorSprite配列の次のマテリアルに変更
            int materialIndex = HitCount % ColorSprite.Length;
            GetComponent<Renderer>().material = ColorSprite[materialIndex];

            // もし衝突回数が規定回数以上ならオブジェクトを破壊する
            if (HitCount > Count)
            {
                SceneManager.LoadScene("Game over");
            }
        }
    }
}