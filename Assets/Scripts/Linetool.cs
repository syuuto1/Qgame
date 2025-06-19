using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linetool : MonoBehaviour
{
    public GameObject linePrefab;                       //���̃v���n�u
    private LineRenderer LineRenderer;                  //���̕`��
    private EdgeCollider2D EdgeCollider;                //���̕����I�ȓ����蔻��
    private Rigidbody2D Rigidbody;
    private List<Vector2> points = new List<Vector2>(); //�_�̍��W���X�g

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //�}�E�X�������ꂽ�u��
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0)) //�}�E�X�������ꑱ���Ă����
        {
            //�}�E�X�̌��݈ʒu�����[���h���W�ɕϊ�
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //�O�̓_����̋�����0.1f�ȏ㗣��Ă���ꍇ�̂ݐV�����_��ǉ�
            if (points.Count == 0 || Vector2.Distance(points[points.Count - 1], mousePos) > .1f)
            {
                UpdateLine(mousePos); //���ɐV�����_��ǉ�
            }
        }

        if (Input.GetMouseButtonUp(0)) //�}�E�X�������ꂽ�Ƃ�
        {
            EnableRigidbodySimulation(); //�d�̗͂L��
        }
    }

    /// <summary>
    /// �V�������I�u�W�F�N�g���쐬
    /// </summary>
    void CreateLine()
    {
        GameObject line = Instantiate(linePrefab);         // �v���n�u������𐶐�

        //�����������I�u�W�F�N�g����e�R���|�[�l���g���擾
        LineRenderer = line.GetComponent<LineRenderer>();
        EdgeCollider = line.GetComponent<EdgeCollider2D>();
        Rigidbody = line.GetComponent<Rigidbody2D>();

        points.Clear();

        //�}�E�X�ʒu�����[���h���W�ɕϊ�
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //�����_
        points.Add(mousePos);
        points.Add(mousePos);

        //�_�̐���ݒ�
        LineRenderer.positionCount = 2;
        LineRenderer.SetPosition(0, points[0]);
        LineRenderer.SetPosition(1, points[1]);

        //�����蔻��p�̓_��ݒ�
        EdgeCollider.points = points.ToArray();
        if (Rigidbody != null)
        {
            Rigidbody.simulated = false;
        }
    }
    /// <summary>
    /// ���ɐV�����_��ǉ����čX�V
    /// </summary>
    /// <param name="newPoint">�V�����_</param>
    void UpdateLine(Vector2 newPoint)
    {
        points.Add(newPoint);//�V�����_�����X�g�ɒǉ�

        LineRenderer.positionCount = points.Count;                          //�`��_�����X�V
        LineRenderer.SetPosition(LineRenderer.positionCount - 1, newPoint);//�Ō�ɒǉ������_�̈ʒu��LineRenderer�ɐݒ�
        //�����蔻����X�V
        EdgeCollider.points = points.ToArray();
    }
    /// <summary>
    /// ���̕����V�~�����[�V������L��
    /// </summary>
    void EnableRigidbodySimulation()
    {
        if (Rigidbody != null)
        {
            Rigidbody.simulated = true; // Rigidbody2D�̃V�~�����[�V������L���ɂ���
        }
    }
}