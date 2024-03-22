using UnityEngine;

public class ClampRectTransformY : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        // Получаем компонент RectTransform объекта
        rectTransform = GetComponent<RectTransform>();
    }

    public void Scroll()
    {
        // Проверяем значение координаты Y
        if (rectTransform.anchoredPosition.y < 0)
        {
            // Если значение меньше 0, устанавливаем его в 0
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
        }
    }
}
