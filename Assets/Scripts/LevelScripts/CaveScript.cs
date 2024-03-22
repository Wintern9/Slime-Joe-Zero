using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TransparencyOnCollision : MonoBehaviour
{
    public float maxDistance = 5f; // Максимальное расстояние для изменения прозрачности
    public float maxAlpha = 1f; // Максимальное значение альфа-канала (прозрачность)

    private SpriteRenderer spriteRenderer;

    private Collider2D playerCollider;
    private Collider2D col;

    Vector2 maxPoint;
    Vector2 minPoint;
    Vector2 SizeBounds;
    float SizeBoundsPlayer;


    void Start()
    {
        col = GetComponent<Collider2D>();

        if (col != null)
        {
            Bounds bounds = col.bounds;
            maxPoint = bounds.max;
            minPoint = bounds.min;

            SizeBounds = bounds.size;
        }
        else
        {
            Debug.LogWarning("Collider2D component not found!");
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

        try
        {
            playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
            SizeBoundsPlayer = playerCollider.bounds.size.x;
        }
        catch
        {
            Debug.LogError("Не существует Игрока");
        }
        
    }

    float distantL;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            distantL = playerCollider.bounds.max.x - minPoint.x;

            Debug.Log($"{SizeBoundsPlayer} - {distantL} = " + Mathf.Clamp01(SizeBoundsPlayer / (SizeBoundsPlayer - distantL)));

            // Определяем прозрачность в зависимости от расстояния
            float transparency = Mathf.Clamp01((SizeBoundsPlayer - distantL) / SizeBoundsPlayer);
            transparency = Mathf.Abs(transparency);
            Color color = spriteRenderer.color;
            color.a = transparency;
            spriteRenderer.color = color;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;
        }
    }
}
