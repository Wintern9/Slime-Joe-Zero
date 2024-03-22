using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ConnectedPos : MonoBehaviour
{
    GameObject Slime;
    Rigidbody2D rigidbody;
    Rigidbody2D rg;
    public float pos;

    private void Awake()
    {
        Slime = GameObject.FindGameObjectWithTag("Player");
        rigidbody = Slime.GetComponent<Rigidbody2D>();
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 transfor = transform.position;
        transfor.y -= pos;
        Slime.transform.position = transfor;
    }

    private void OnDisable()
    {
        //rigidbody.isKinematic = false;
        Slime.GetComponent<PolygonCollider2D>().enabled = true;
    }

    private void OnEnable()
    {
        Slime.GetComponent<PolygonCollider2D>().enabled = false;
        //rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ramp"))
        {
            TouchInput touchInput = Slime.GetComponent<TouchInput>();
            //touchInput.ground = true;
            touchInput.animator.SetBool("Ground", true);
            touchInput.JumpingApproal = true;
        }
    }

    public void Jump(Vector3 launchDirection, float jumpStreng)
    {
        rg.AddForce(launchDirection * jumpStreng / 2);
    }
}
