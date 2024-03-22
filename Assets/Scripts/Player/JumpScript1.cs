//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.XR;

//public class TouchInput1 : MonoBehaviour
//{
//    Vector2 pos;
//    Vector2 pos2;

//    Rigidbody2D rb;
//    public Animator animator;

//    [SerializeField] private GameObject CircleCollider;

//    public bool JumpingApproal = true;
//    PolygonCollider2D polygonCollider;
//    CircleCollider2D circleCollider;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//        polygonCollider = gameObject.GetComponent<PolygonCollider2D>();
//        circleCollider = gameObject.GetComponent<CircleCollider2D>();
//    }

//    void Update()
//    {
//        float currentRotation = transform.rotation.eulerAngles.z;

//        switch (touch.phase)
//        {
//            case TouchPhase.Began:
//                startPosition = touch.position;
//                break;

//            case TouchPhase.Ended:
//                Vector2 endPosition = touch.position;
//                float vectorLength = (endPosition - startPosition).magnitude;
//                text.text = "Длина вектора: " + vectorLength;
//                break;
//        }

//        // Проверка, есть ли касание на экране
//        if (Input.touchCount > 0 && JumpingApproal)
//        {
//            // Получаем первое касание
//            Touch touch = Input.GetTouch(0);

//            // Проверяем, было ли начало касания
//            if (touch.phase == TouchPhase.Began)
//            {
//                pos = touch.position;
//                animator.SetBool("Jumping", false);
//                animator.SetBool("Jump", true);
//            }

//            // Проверяем, было ли завершение касания
//            if (touch.phase == TouchPhase.Ended)
//            {
//                pos2 = touch.position;

//                Vector2 combinedVector = new Vector2(pos2.x - pos.x, pos2.y- pos.y);
//                combinedVector.Normalize();
//                Debug.Log(combinedVector);

//                if (combinedVector.y > 0)
//                {
//                    animator.SetBool("Jumping", true);
//                    animator.SetBool("Ground", false);
//                    JumpingApproal = false;
//                } else
//                {
//                    animator.SetBool("Jumping", false);
//                    animator.SetBool("Jump", false);
//                }
//            }

//            if (Settings.EyesBool)
//            {
//                EyesRot(pos, touch.position);
//            }
//        } else
//        {
//            animator.SetBool("Jump", false);
//        }

//        Vector3 currentVelocity = rb.velocity;

//        if (currentVelocity != Vector3.zero)
//        {
//            Vector3 normalizedVelocity = currentVelocity.normalized;

//            if(normalizedVelocity.y < 0 && !animator.GetBool("Jump"))
//            {
//                animator.SetBool("Jumping", false);
//            }
//        } 

//        if(currentVelocity == Vector3.zero && animator.GetBool("Jumping") && JumpingApproal)
//        {
//            if (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpAnimation0"))
//            {
//                // Ваш код, который будет выполнен, если анимация проигрывается
//                animator.SetBool("Jumping", false);
//            }
//        }

//        if (rotate && Mathf.Floor(transform.rotation.eulerAngles.z) == 0f)
//        {
//            rb.freezeRotation = true;
//            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
//            rotate = false;
//        }



//        if (rotate && !ground )
//        {
//            // Задаем конечный угол (0 градусов)
//            float targetRotation = 0.0f;

//            // Используем функцию Lerp для плавного перехода между текущим и конечным углом
//            float newRotation = Mathf.LerpAngle(currentRotation, targetRotation, Time.deltaTime * transitionSpeed);

//            // Создаем новый кватернион с новым углом поворота
//            Quaternion newQuaternion = Quaternion.Euler(0, 0, newRotation);

//            // Применяем поворот к объекту
//            transform.rotation = newQuaternion;
//        }
//    }

//    public GameObject eyes;
//    public GameObject eyes2;

//    void EyesRot(Vector2 pos, Vector2 pos2)
//    {
//        Vector2 transf = eyes2.transform.position; // 0 значение

//        float maxLengthX = 700f;
//        float minLengthX = -700f;
//        float maxLengthY = 700f;
//        float minLengthY = -300f;

//        float length = GetVectorLength(pos - pos2);

//        if(length > 700f)
//        {
//            length = 700f;
//        }

//        Vector2 vector = new Vector2(
//            Mathf.Clamp(pos2.x - pos.x, minLengthX, maxLengthX),
//            Mathf.Clamp(pos2.y - pos.y, minLengthY, maxLengthY)
//        );

//        vector.Normalize();

//        Vector2 vector2 = new Vector2(transf.x + vector.x * length / 3000, transf.y + vector.y * length / 6000);

//        Debug.DrawLine(vector, vector2);
//        Debug.Log(vector2);

//        eyes.transform.position = vector2;
//    }


//    public float transitionSpeed = 0.5f;

//    public bool rotate = false;
//    public bool ground = false;

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Ground"))
//        {
//            animator.SetBool("Ground", false);
//            ground = false;
//            JumpingApproal = false;
//            Play();
//        }

//        if (collision.CompareTag("Rotate") && Settings.rotate)
//        {
//            //rb.freezeRotation = true;
//            rotate = true;
//        }
//    }
//    private void OnTriggerStay2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Ground")) // || collision.CompareTag("Ramp")
//        {
//            ground = true;
//            animator.SetBool("Ground", true);
//            JumpingApproal = true;
//            polygonCollider.enabled = true;
//            //circleCollider.enabled = false;

//        }

//        if (collision.CompareTag("Rotate") && Settings.rotate)
//        {
//            rb.freezeRotation = false;
//        }

//        if (collision.CompareTag("Death"))
//        {
//            objectSquareDeath.SetActive(true);
//        }

//        if (collision.CompareTag("Continue"))
//        {
//            objectSquareContinue.SetActive(true);
//        }
//    }

//    [SerializeField]private GameObject objectSquareDeath;
//    [SerializeField] private GameObject objectSquareContinue;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("Ramp"))
//        {
//            //CircleCollider.SetActive(true);
//            animator.SetBool("Circle", true);
//            polygonCollider.enabled = false;
//            circleCollider.enabled = true;
//        }
//    }

//    public void Jumping()
//    {
        
//        animator.SetBool("Jump", false);
//        float jumpStreng = GetVectorLength(pos - pos2);
//        Vector2 vec = pos2 - pos;

//        if (jumpStreng > 700.0f)
//        {
//            jumpStreng = 700.0f;
//        }

//        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
//        float angleInRadians = angle * Mathf.Deg2Rad;
//        Vector3 launchDirection = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0f);

//        // Используем AddForce вместо установки velocity
//        rb.AddForce(launchDirection * jumpStreng/2);
//        //if(GameObject.FindGameObjectWithTag("CircleCollider") != null) GameObject.FindGameObjectWithTag("CircleCollider").GetComponent<ConnectedPos>().Jump(launchDirection,jumpStreng);

//        Debug.Log("Позиция: " + jumpStreng);
//    }

//    public void JumpingCon()
//    {
//        JumpingApproal = true;
//    }

//    Vector2 CombineVectors(Vector2 v1, Vector2 v2)
//    {
//        // Просто сложим компоненты векторов
//        float combinedX = v1.x + v2.x;
//        float combinedY = v1.y + v2.y;

//        // Создаем новый единичный вектор
//        Vector3 combinedVector = new Vector3(combinedX, combinedY);
//        return combinedVector;
//    }

//    float GetVectorLength(Vector2 v)
//    {
//        // Используем метод magnitude для получения длины вектора
//        float length = v.magnitude;

//        return length;
//    }

//    public void Circle()
//    {
//        animator.SetBool("Circle", false);
//    }


//    public AudioClip soundClip;

//    private void Play()
//    {
//        Vector3 position = transform.position;
//        if (Settings.volumeSoundEffectsBool)
//        {
//            AudioSource.PlayClipAtPoint(soundClip, position, 1.0f);
//        }
//    }

//}
