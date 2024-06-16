using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollisionDetector : MonoBehaviour
{
    void Start()
    {
        // EdgeCollider2Dを持つGameObjectを取得
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        // 新しいポリゴンを作成
        PolygonCollider2D polygonCollider = gameObject.AddComponent<PolygonCollider2D>();

        // EdgeCollider2Dのポイントを取得
        Vector2[] edgePoints = edgeCollider.points;

        // PolygonCollider2Dにポイントを設定
        polygonCollider.points = edgePoints;

        // 不要になったEdgeCollider2Dを削除
        //Destroy(edgeCollider);
    }
}







