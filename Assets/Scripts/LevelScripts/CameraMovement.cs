using UnityEngine;
using UnityEngine.SceneManagement;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform target;  // Целевой объект, за которым будет следовать камера
    [SerializeField] private float smoothSpeed = 5.0f;  // Параметр для настройки скорости следования
    [SerializeField] private float CameraY = 5.0f;  // Параметр для настройки скорости следования

    [SerializeField] private float CameraLocalXMin;
    [SerializeField] private float CameraLocalXMax;
    [SerializeField] private float CameraLocalYMin;

    Resolution resolution;

    private void Start()
    {
        CameraLocalXMax = GetMax();
        Application.targetFrameRate = 60;
        resolution = Screen.currentResolution;
    }

    void LateUpdate()
    {
        //Debug.Log(resolution);
        if (target != null)
        {
            // Вычисляем новую позицию для камеры с использованием метода Vector3.Lerp
            Vector3 desiredPosition = target.position;
            desiredPosition.y += CameraY;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            if(smoothedPosition.x < CameraLocalXMin)
            {
                smoothedPosition.x = CameraLocalXMin;
            }

            if (smoothedPosition.x > CameraLocalXMax)
            {
                smoothedPosition.x = CameraLocalXMax;
            }

            if (smoothedPosition.y < CameraLocalYMin)
            {
                smoothedPosition.y = CameraLocalYMin;
            }

            // Устанавливаем новую позицию камеры
            transform.position = new Vector3 (smoothedPosition.x, smoothedPosition.y, -10f);
        }
    }
    private int GetMax()
    {
        int max = 0;
        string nameScene = SceneManager.GetActiveScene().name;
        if(nameScene == "Level1")
        {
            max = 34;
        }
        else if (nameScene == "Level2")
        {
            max = 20;
        }
        else if (nameScene == "Level3")
        {
            max = 21;
        }else if (nameScene == "Level4")
        {
            max = 37;
        } else if (nameScene == "Level5")
        {
            max = 38;
        } else
        {
            Debug.LogError("Не прописан max для камеры");
            max = 100;
        }

        return max;
    }
}
