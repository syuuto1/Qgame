using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollisionDetector : MonoBehaviour
{
    void Start()
    {
        // EdgeCollider2D������GameObject���擾
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        // �V�����|���S�����쐬
        PolygonCollider2D polygonCollider = gameObject.AddComponent<PolygonCollider2D>();

        // EdgeCollider2D�̃|�C���g���擾
        Vector2[] edgePoints = edgeCollider.points;

        // PolygonCollider2D�Ƀ|�C���g��ݒ�
        polygonCollider.points = edgePoints;

        // �s�v�ɂȂ���EdgeCollider2D���폜
        //Destroy(edgeCollider);
    }
}







