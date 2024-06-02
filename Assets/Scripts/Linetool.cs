using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linetool : MonoBehaviour
{
    public GameObject linePrefab; // ê¸ÇÃÉvÉåÉnÉu
    private LineRenderer currentLineRenderer;
    private EdgeCollider2D currentEdgeCollider;
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
    }

    void CreateLine()
    {
        GameObject line = Instantiate(linePrefab);
        currentLineRenderer = line.GetComponent<LineRenderer>();
        currentEdgeCollider = line.GetComponent<EdgeCollider2D>();
        points.Clear();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(mousePos);
        points.Add(mousePos);
        currentLineRenderer.SetPosition(0, points[0]);
        currentLineRenderer.SetPosition(1, points[1]);
        currentEdgeCollider.points = points.ToArray();
    }

    void UpdateLine(Vector2 newPoint)
    {
        points.Add(newPoint);
        currentLineRenderer.positionCount++;
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, newPoint);
        currentEdgeCollider.points = points.ToArray();
    }
}