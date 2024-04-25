using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJumpAnimatorScript : MonoBehaviour
{
    PlatformJumpScript triggerObject;
    void Start()
    {
        triggerObject = GetComponentInChildren<PlatformJumpScript>();
    }

    public void AnimatorJumpAddForce()
    {
        triggerObject.JumpAddForce();
    }
}
