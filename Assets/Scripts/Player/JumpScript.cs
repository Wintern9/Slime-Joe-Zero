using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TouchInput : MonoBehaviour
{
    Vector2 pos;
    Vector2 pos2;

    Rigidbody2D rb;
    public Animator animator;

    [SerializeField] private GameObject CircleCollider;

    public bool JumpingApproal = true;
    BoxCollider2D polygonCollider;
    CircleCollider2D circleCollider;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;

    [SerializeField] private GameObject eyes;
    [SerializeField] private GameObject eyes2;

    private float _transitionSpeed = 10f;

    [SerializeField] private bool rotate = false;
    [SerializeField] private bool ground = false;

    float _resolutionPrecent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        polygonCollider = gameObject.GetComponent<BoxCollider2D>();
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    private void Start()
    {

        Vector2 resolution = new Vector2(Screen.width, Screen.height);
        //_resolutionPrecent = new Vector2(2620, 1200) / (resolution);
        _resolutionPrecent = (2620 * 1200) / (resolution.x * resolution.y);
    }

    void Update()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        
        // Проверка, есть ли касание на экране
        if (Input.touchCount > 0 && JumpingApproal)
        {
            // Получаем первое касание
            Touch touch = Input.GetTouch(0);

            // Проверяем, было ли начало касания
            if (touch.phase == TouchPhase.Began)
            {
                if (Settings.JumpControlSwitch)
                {
                    pos = touch.position;
                }
                else
                {
                    pos = new Vector2(Screen.width / 2, Screen.height / 2 * 0.8f);
                }
                animator.SetBool("Jumping", false);
                animator.SetBool("Jump", true);
                text1.text = "Pos:" + pos;
            }

            // Проверяем, было ли завершение касания
            if (touch.phase == TouchPhase.Ended)
            {
                pos2 = touch.position;
                text2.text = "Pos:" + pos2;
                Vector2 combinedVector = new Vector2(pos2.x - pos.x, pos2.y- pos.y);
                combinedVector.Normalize();
                Debug.Log(combinedVector);

                if (combinedVector.y > 0)
                {
                    animator.SetBool("Jumping", true);
                    animator.SetBool("JumpDown", false);
                    JumpingApproal = false;
                } else
                {

                    animator.SetBool("JumpDown", true);
                    animator.SetBool("Jumping", false);
                    animator.SetBool("Jump", false);
                }
            }

            if (Settings.EyesBool)
            {
                EyesRot(pos, touch.position);
            }
        } else
        {
            animator.SetBool("Jump", false);
        }

        Vector3 currentVelocity = rb.velocity;

        if (currentVelocity != Vector3.zero)
        {
            Vector3 normalizedVelocity = currentVelocity.normalized;

            if(normalizedVelocity.y < 0 && !animator.GetBool("Jump"))
            {
                animator.SetBool("Jumping", false);

                animator.SetBool("JumpDown", true);
            }
        } 

        if(currentVelocity == Vector3.zero && animator.GetBool("Jumping") && JumpingApproal)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpAnimation"))
            {
                // Ваш код, который будет выполнен, если анимация проигрывается
                animator.SetBool("Jumping", false);
                Invoke("Jumping", 0.03f);
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpAnimation"))
            {
                animator.SetBool("Jump", false);
            }
        }

        ///--------------///

        if (rotate && Mathf.Floor(transform.rotation.eulerAngles.z) == 0f)
        {
            rb.freezeRotation = true;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            rotate = false;
        }



        if (!ground && Mathf.Floor(transform.rotation.eulerAngles.z) != 0f)
        {
            rotate = true;
            // Задаем конечный угол (0 градусов)
            float targetRotation = 0.0f;

            // Используем функцию Lerp для плавного перехода между текущим и конечным углом
            float newRotation = Mathf.LerpAngle(currentRotation, targetRotation, Time.deltaTime * _transitionSpeed);

            Quaternion newQuaternion = Quaternion.Euler(0, 0, newRotation);

            // Применяем поворот к объекту
            transform.rotation = newQuaternion;
        }
    }

    void EyesRot(Vector2 pos, Vector2 pos2)
    {
        Vector2 transf = eyes2.transform.position; // 0 значение

        float maxLengthX = 700f;
        float minLengthX = -700f;
        float maxLengthY = 700f;
        float minLengthY = -300f;


        Vector2 vec1 = pos - pos2;
        //vec1 *= _resolutionPrecent;// Адаптивнрое значение под экран

        float length = GetVectorLength(vec1);

        if(_resolutionPrecent > 1)
        {
            length *= _resolutionPrecent;
        }

        if(length > 700f)
        {
            length = 700f;
        }

        Vector2 vector = new Vector2(
            Mathf.Clamp(pos2.x - pos.x, minLengthX, maxLengthX),
            Mathf.Clamp(pos2.y - pos.y, minLengthY, maxLengthY)
        );

        vector.Normalize();

        Vector2 vector2 = new Vector2(transf.x + vector.x * length / 3000, transf.y + vector.y * length / 6000);

        Debug.DrawLine(vector, vector2);
        Debug.Log(vector2);

        eyes.transform.position = vector2;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            animator.SetBool("Ground", false);
            ground = false;
            JumpingApproal = false;
            animator.SetBool("JumpDown", false);
            
        }

        //if (collision.CompareTag("Rotate") && Settings.rotate)
        //{
        //    //rb.freezeRotation = true;
        //    rotate = true;
        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) // || collision.CompareTag("Ramp")
        {
            ground = true;
            JumpingApproal = true;
            polygonCollider.enabled = true;
            animator.SetBool("JumpDown", true);
            //circleCollider.enabled = false;

        }

        //if (Settings.rotate)
        //{
        //    if (collision.CompareTag("Rotate"))
        //    {
        //        rb.freezeRotation = false;
        //    }
        //}
    }

    [SerializeField]private GameObject objectSquareDeath;
    [SerializeField] private GameObject objectSquareContinue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) // || collision.CompareTag("Ramp")
        {
            animator.SetBool("Ground", true);
        }

        //if (collision.CompareTag("Ramp"))
        //{
        //    //CircleCollider.SetActive(true);
        //    animator.SetBool("Circle", true);
        //    polygonCollider.enabled = false;
        //    circleCollider.enabled = true;
        //}

        if (collision.CompareTag("Death"))
        {
            objectSquareDeath.SetActive(true);
        }

        if (collision.CompareTag("Continue"))
        {
            objectSquareContinue.SetActive(true);
            Settings settings = new Settings();
            settings.LevelComSet(SceneManager.GetActiveScene().name);
        }
    }

    public void Jumping()
    {
        Play();
        Vector2 vec1 = pos - pos2;

        Debug.Log("Procaent: " + _resolutionPrecent);

        float jumpStreng = GetVectorLength(vec1);

        if (_resolutionPrecent > 1)
        {
            jumpStreng *= _resolutionPrecent; //Адаптация под экраны
        }

        Vector2 vec = pos2 - pos;


        if (jumpStreng > 700.0f)
        {
            jumpStreng = 700.0f;
        }

        float angle = Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg;
        float angleInRadians = angle * Mathf.Deg2Rad;
        Vector3 launchDirection = new Vector3(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians), 0f);

        // Используем AddForce вместо установки velocity
        rb.AddForce(launchDirection * jumpStreng/2);
        //if(GameObject.FindGameObjectWithTag("CircleCollider") != null) GameObject.FindGameObjectWithTag("CircleCollider").GetComponent<ConnectedPos>().Jump(launchDirection,jumpStreng);

        text.text = "JumpPower: " + jumpStreng;
        Debug.Log("Позиция: " + jumpStreng);
    }

    public void JumpingCon()
    {
        //text.text = "Jump: False";
        JumpingApproal = true;
    }

    float GetVectorLength(Vector2 v)
    {
        // Используем метод magnitude для получения длины вектора
        float length = v.magnitude;

        return length;
    }

    //public void Circle()
    //{
    //    animator.SetBool("Circle", false);
    //}


    [SerializeField] private AudioClip soundClip;

    private void Play()
    {
        Vector3 position = transform.position;
        if (Settings.SoundBool && Settings.MusicPlaying)
        {
            AudioSource.PlayClipAtPoint(soundClip, position, 1.0f);
        }
    }

}
