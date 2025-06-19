using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linetool : MonoBehaviour
{
    public GameObject linePrefab;                       //線のプレハブ
    private LineRenderer LineRenderer;                  //線の描画
    private EdgeCollider2D EdgeCollider;                //線の物理的な当たり判定
    private Rigidbody2D Rigidbody;
    private List<Vector2> points = new List<Vector2>(); //点の座標リスト

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //マウスが押された瞬間
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0)) //マウスが押され続けている間
        {
            //マウスの現在位置をワールド座標に変換
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //前の点からの距離が0.1f以上離れている場合のみ新しい点を追加
            if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], mousePos) > .1f)
            {
                UpdateLine(mousePos); //線に新しい点を追加
            }
        }

        if (Input.GetMouseButtonUp(0)) //マウスが離されたとき
        {
            EnableRigidbodySimulation(); //重力の有効
        }
    }

    /// <summary>
    /// 新しい線オブジェクトを作成
    /// </summary>
    void CreateLine()
    {
        GameObject line = Instantiate(linePrefab);         // プレハブから線を生成

        //生成した線オブジェクトから各コンポーネントを取得
        LineRenderer = line.GetComponent<LineRenderer>();
        EdgeCollider = line.GetComponent<EdgeCollider2D>();
        Rigidbody = line.GetComponent<Rigidbody2D>();

        points.Clear();

        //マウス位置をワールド座標に変換
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //初期点
        points.Add(mousePos);
        points.Add(mousePos);

        //点の数を設定
        LineRenderer.positionCount = 2;
        LineRenderer.SetPosition(0, points[0]);
        LineRenderer.SetPosition(1, points[1]);

        //当たり判定用の点を設定
        EdgeCollider.points = points.ToArray();
        if (Rigidbody != null)
        {
            Rigidbody.simulated = false;
        }
    }
    /// <summary>
    /// 線に新しい点を追加して更新
    /// </summary>
    /// <param name="newPoint">新しい点</param>
    void UpdateLine(Vector2 newPoint)
    {
        points.Add(newPoint);//新しい点をリストに追加

        LineRenderer.positionCount = points.Count;                          //描画点数を更新
        LineRenderer.SetPosition(LineRenderer.positionCount - 1, newPoint);//最後に追加した点の位置をLineRendererに設定
        //当たり判定も更新
        EdgeCollider.points = points.ToArray();
    }
    /// <summary>
    /// 線の物理シミュレーションを有効
    /// </summary>
    void EnableRigidbodySimulation()
    {
        if (Rigidbody != null)
        {
            Rigidbody.simulated = true; // Rigidbody2Dのシミュレーションを有効にする
        }
    }
}