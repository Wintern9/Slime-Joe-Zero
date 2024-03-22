using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private Collider2D boundaryCollider;

    void Start()
    {
        // �������� ��������� Collider2D � ������������� �������
        boundaryCollider = GameObject.FindGameObjectWithTag("CloudDelete").GetComponent<Collider2D>();

        if (boundaryCollider == null)
        {
            Debug.LogError("Boundary collider not found!");
        }
    }

    void Update()
    {
        transform.position += new Vector3(Settings.SpeedCloud, 0, 0);
        // ���������, ���� ������ �������� ������� 2D ����������
        if (!boundaryCollider.bounds.Contains(transform.position))
        {
            // ������� ������
            Destroy(gameObject);
        }
    }
}


