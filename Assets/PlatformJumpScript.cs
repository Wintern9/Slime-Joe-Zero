using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJumpScript : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;

    private Animator animator;
    private Collider2D collider;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            animator.Play("Пружина");
            this.collider = collider;
        }
    }

    [SerializeField] private Vector2 vetor2Jump;

    public void JumpAddForce()
    {
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce(vetor2Jump * jumpForce, ForceMode2D.Impulse);
        collider = new Collider2D();
    }
}
