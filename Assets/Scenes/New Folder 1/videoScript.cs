using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public float moveSpeed = 1.0f; // —корость перемещени€ звезды
    public float minSize = 0.5f; // ћинимальный размер звезды
    public float maxSize = 2.0f; // ћаксимальный размер звезды

    private Vector3 targetPosition;
    private float targetSize;
    private Vector3 startPosition;
    private float startTime;

    void Start()
    {
        // «адаем случайное начальное положение и размер звезды
        startPosition = transform.position;
        targetPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
        targetSize = Random.Range(minSize, maxSize);
        startTime = Time.time;
    }

    void Update()
    {
        // ¬ычисл€ем прогресс анимации от 0 до 1
        float progress = (Time.time - startTime) * moveSpeed;

        // ѕлавно перемещаем звезду к целевой позиции
        transform.position = Vector3.Lerp(startPosition, targetPosition, progress);

        // ѕлавно измен€ем размер звезды
        transform.localScale = Vector3.Lerp(Vector3.one * minSize, Vector3.one * targetSize, progress);

        // ≈сли анимаци€ завершена, обновл€ем начальные значени€
        if (progress >= 1.0f)
        {
            startPosition = transform.position;
            targetPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
            targetSize = Random.Range(minSize, maxSize);
            startTime = Time.time;
        }
    }
}
