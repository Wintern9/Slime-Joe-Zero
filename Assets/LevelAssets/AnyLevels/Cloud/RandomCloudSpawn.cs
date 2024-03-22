using System.Collections;
using UnityEngine;

public class SpawnRandomly : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    public Collider2D spawnArea;
    public float spawnInterval = 4f;

    private void Start()
    {
        StartCoroutine(SpawnObject());

        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            // Генерируем случайные координаты внутри коллайдера
            Vector3 randomPosition = GetRandomPositionInsideCollider(spawnArea);

            // Создаем объект в случайной позиции
            GameObject newObject = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length-1)], randomPosition, Quaternion.identity);

            // Делаем новый объект дочерним к текущему объекту
            newObject.transform.parent = transform;

            // Ждем заданный интервал времени перед созданием следующего объекта
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomPositionInsideCollider(Collider2D collider)
    {
        Bounds bounds = collider.bounds;
        Vector3 randomPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0f
        );
        return randomPoint;
    }
        

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;


    void Update()
    {
        // Рассчитываем величину смещения фона на основе движения камеры
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        float deltaY = cameraTransform.position.y - lastCameraPosition.y;

        // Применяем панорамный эффект к позиции заднего фона
        transform.position += new Vector3(deltaX * Settings.parallaxEffectMultiplier, deltaY * Settings.parallaxEffectMultiplier * 1.3f, 0f);

        // Обновляем последнюю позицию камеры
        lastCameraPosition = cameraTransform.position;
    
    }

}
