using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPosJump : MonoBehaviour
{
    static public Vector2 position;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            position = touch.position;
            transform.position = touch.position / 100 / 3;
        } 
    }
}
