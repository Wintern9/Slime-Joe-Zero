using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    private Collider2D boundaryCollider;

    void Start()
    {
        // Получаем компонент Collider2D у родительского объекта
        boundaryCollider = GameObject.FindGameObjectWithTag("CloudDelete").GetComponent<Collider2D>();

        if (boundaryCollider == null)
        {
            Debug.LogError("Boundary collider not found!");
        }
    }

    void Update()
    {
        transform.position += new Vector3(Settings.SpeedCloud, 0, 0);
        // Проверяем, если объект покидает пределы 2D коллайдера
        if (!boundaryCollider.bounds.Contains(transform.position))
        {
            // Удаляем объект
            Destroy(gameObject);
        }
    }
}


