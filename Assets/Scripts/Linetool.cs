using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linetool : MonoBehaviour
{
    public GameObject linePrefab; // 線のプレハブ
    private LineRenderer currentLineRenderer;
    private EdgeCollider2D currentEdgeCollider;
    private Rigidbody2D currentRigidbody; // Rigidbody2Dの参照を保持
    private List<Vector2> points = new List<Vector2>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], mousePos) > .1f)
            {
                UpdateLine(mousePos);
            }
        }

        if (Input.GetMouseButtonUp(0)) // マウスボタンが離されたとき
        {
            EnableRigidbodySimulation(); // Rigidbody2Dのシミュレーションを有効にする
        }
    }

    void CreateLine()
    {
        GameObject line = Instantiate(linePrefab);
        currentLineRenderer = line.GetComponent<LineRenderer>();
        currentEdgeCollider = line.GetComponent<EdgeCollider2D>();
        currentRigidbody = line.GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        points.Clear();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(mousePos);
        points.Add(mousePos);

        currentLineRenderer.positionCount = 2; // positionCountを設定
        currentLineRenderer.SetPosition(0, points[0]);
        currentLineRenderer.SetPosition(1, points[1]);
        currentEdgeCollider.points = points.ToArray();
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = false; // 初期状態でRigidbody2Dのシミュレーションを無効にする
        }
    }

    void UpdateLine(Vector2 newPoint)
    {
        points.Add(newPoint);
        currentLineRenderer.positionCount = points.Count; // positionCountを更新
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, newPoint);
        currentEdgeCollider.points = points.ToArray();
    }

    void EnableRigidbodySimulation()
    {
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = true; // Rigidbody2Dのシミュレーションを有効にする
        }
    }

    
}

/*public class Linetool : MonoBehaviour //PolygonCollider2D
{
    public GameObject linePrefab; // 線のプレハブ
    private LineRenderer currentLineRenderer;
    private PolygonCollider2D currentPolygonCollider; // PolygonCollider2Dの参照を保持
    private Rigidbody2D currentRigidbody; // Rigidbody2Dの参照を保持
    private List<Vector2> points = new List<Vector2>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], mousePos) > .1f)
            {
                UpdateLine(mousePos);
            }
        }

        if (Input.GetMouseButtonUp(0)) // マウスボタンが離されたとき
        {
            EnableRigidbodySimulation(); // Rigidbody2Dのシミュレーションを有効にする
        }
    }

    void CreateLine()
    {
        GameObject line = Instantiate(linePrefab);
        currentLineRenderer = line.GetComponent<LineRenderer>();
        currentPolygonCollider = line.AddComponent<PolygonCollider2D>(); // PolygonCollider2Dを追加
        currentRigidbody = line.GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        points.Clear();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(mousePos);
        points.Add(mousePos);

        currentLineRenderer.positionCount = 2; // positionCountを設定
        currentLineRenderer.SetPosition(0, points[0]);
        currentLineRenderer.SetPosition(1, points[1]);
        currentPolygonCollider.points = points.ToArray(); // PolygonCollider2Dのポイントを設定
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = false; // 初期状態でRigidbody2Dのシミュレーションを無効にする
        }
    }

    void UpdateLine(Vector2 newPoint)
    {
        points.Add(newPoint);
        currentLineRenderer.positionCount = points.Count; // positionCountを更新
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, newPoint);
        currentPolygonCollider.points = points.ToArray(); // PolygonCollider2Dのポイントを更新
    }

    void EnableRigidbodySimulation()
    {
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = true; // Rigidbody2Dのシミュレーションを有効にする
        }
    }
}*/