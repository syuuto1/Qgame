using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linetool : MonoBehaviour
{
    public GameObject linePrefab; // ���̃v���n�u
    private LineRenderer currentLineRenderer;
    private EdgeCollider2D currentEdgeCollider;
    private Rigidbody2D currentRigidbody; // Rigidbody2D�̎Q�Ƃ�ێ�
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

        if (Input.GetMouseButtonUp(0)) // �}�E�X�{�^���������ꂽ�Ƃ�
        {
            EnableRigidbodySimulation(); // Rigidbody2D�̃V�~�����[�V������L���ɂ���
        }
    }

    void CreateLine()
    {
        GameObject line = Instantiate(linePrefab);
        currentLineRenderer = line.GetComponent<LineRenderer>();
        currentEdgeCollider = line.GetComponent<EdgeCollider2D>();
        currentRigidbody = line.GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
        points.Clear();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(mousePos);
        points.Add(mousePos);

        currentLineRenderer.positionCount = 2; // positionCount��ݒ�
        currentLineRenderer.SetPosition(0, points[0]);
        currentLineRenderer.SetPosition(1, points[1]);
        currentEdgeCollider.points = points.ToArray();
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = false; // ������Ԃ�Rigidbody2D�̃V�~�����[�V�����𖳌��ɂ���
        }
    }

    void UpdateLine(Vector2 newPoint)
    {
        points.Add(newPoint);
        currentLineRenderer.positionCount = points.Count; // positionCount���X�V
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, newPoint);
        currentEdgeCollider.points = points.ToArray();
    }

    void EnableRigidbodySimulation()
    {
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = true; // Rigidbody2D�̃V�~�����[�V������L���ɂ���
        }
    }

    
}

/*public class Linetool : MonoBehaviour //PolygonCollider2D
{
    public GameObject linePrefab; // ���̃v���n�u
    private LineRenderer currentLineRenderer;
    private PolygonCollider2D currentPolygonCollider; // PolygonCollider2D�̎Q�Ƃ�ێ�
    private Rigidbody2D currentRigidbody; // Rigidbody2D�̎Q�Ƃ�ێ�
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

        if (Input.GetMouseButtonUp(0)) // �}�E�X�{�^���������ꂽ�Ƃ�
        {
            EnableRigidbodySimulation(); // Rigidbody2D�̃V�~�����[�V������L���ɂ���
        }
    }

    void CreateLine()
    {
        GameObject line = Instantiate(linePrefab);
        currentLineRenderer = line.GetComponent<LineRenderer>();
        currentPolygonCollider = line.AddComponent<PolygonCollider2D>(); // PolygonCollider2D��ǉ�
        currentRigidbody = line.GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
        points.Clear();
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(mousePos);
        points.Add(mousePos);

        currentLineRenderer.positionCount = 2; // positionCount��ݒ�
        currentLineRenderer.SetPosition(0, points[0]);
        currentLineRenderer.SetPosition(1, points[1]);
        currentPolygonCollider.points = points.ToArray(); // PolygonCollider2D�̃|�C���g��ݒ�
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = false; // ������Ԃ�Rigidbody2D�̃V�~�����[�V�����𖳌��ɂ���
        }
    }

    void UpdateLine(Vector2 newPoint)
    {
        points.Add(newPoint);
        currentLineRenderer.positionCount = points.Count; // positionCount���X�V
        currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, newPoint);
        currentPolygonCollider.points = points.ToArray(); // PolygonCollider2D�̃|�C���g���X�V
    }

    void EnableRigidbodySimulation()
    {
        if (currentRigidbody != null)
        {
            currentRigidbody.simulated = true; // Rigidbody2D�̃V�~�����[�V������L���ɂ���
        }
    }
}*/