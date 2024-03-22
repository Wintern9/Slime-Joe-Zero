using UnityEngine;

public class RandomAnimationTime : MonoBehaviour
{
    private string animationName = "Eyes";
    private float minTime = 6;
    private float maxTime = 10;

    private void Start()
    {
        InvokeRepeating("PlayAnimation", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
    }

    private void PlayAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play(animationName);
    }
}