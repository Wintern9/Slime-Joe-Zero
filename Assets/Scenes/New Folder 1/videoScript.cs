using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public float moveSpeed = 1.0f; // �������� ����������� ������
    public float minSize = 0.5f; // ����������� ������ ������
    public float maxSize = 2.0f; // ������������ ������ ������

    private Vector3 targetPosition;
    private float targetSize;
    private Vector3 startPosition;
    private float startTime;

    void Start()
    {
        // ������ ��������� ��������� ��������� � ������ ������
        startPosition = transform.position;
        targetPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        targetSize = Random.Range(minSize, maxSize);
        startTime = Time.time;
    }

    void Update()
    {
        // ��������� �������� �������� �� 0 �� 1
        float progress = (Time.time - startTime) * moveSpeed;

        // ������ ���������� ������ � ������� �������
        transform.position = Vector3.Lerp(startPosition, targetPosition, progress);

        // ������ �������� ������ ������
        transform.localScale = Vector3.Lerp(Vector3.one * minSize, Vector3.one * targetSize, progress);

        // ���� �������� ���������, ��������� ��������� ��������
        if (progress >= 1.0f)
        {
            startPosition = transform.position;
            targetPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
            targetSize = Random.Range(minSize, maxSize);
            startTime = Time.time;
        }
    }
}
