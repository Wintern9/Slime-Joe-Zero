using UnityEngine;

public class ClampRectTransformY : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        // �������� ��������� RectTransform �������
        rectTransform = GetComponent<RectTransform>();
    }

    public void Scroll()
    {
        // ��������� �������� ���������� Y
        if (rectTransform.anchoredPosition.y < 0)
        {
            // ���� �������� ������ 0, ������������� ��� � 0
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
        }
    }
}
