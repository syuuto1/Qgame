using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _rend;
    [SerializeField] private Camera _cam;
    [SerializeField] private EdgeCollider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody;
    private int posCount = 0;
    private float interval = 0.1f;
    private List<Vector2> _points = new List<Vector2>();
    private void Awake()
    {
        _rigidbody.simulated = false;
    }
    private void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
            SetPosition(mousePos);
        else if (Input.GetMouseButtonUp(0))
        {
            _rigidbody.simulated = true;
            posCount = 0;
        }
    }
    private void SetPosition(Vector2 pos)
    {
        if (!PosCheck(pos)) return;
        posCount++;
        _rend.positionCount = posCount;
        _rend.SetPosition(posCount - 1, pos);
        _points.Add(pos);
        _collider.points = _points.ToArray();
    }
    private bool PosCheck(Vector2 pos)
    {
        if (posCount == 0) return true;
        float distance = Vector2.Distance(_rend.GetPosition(posCount - 1), pos);
        if (distance > interval)
            return true;
        else
            return false;
    }
}