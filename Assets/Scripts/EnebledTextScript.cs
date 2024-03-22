using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnebledTextScript : MonoBehaviour
{
    [SerializeField] private GameObject gameObj;
    [SerializeField] private GameObject Text;

    void Update()
    {
        if (gameObj.active == false)
        {
            Text.SetActive(false);
        } else
        {
            Text.SetActive(true);
        }
    }
}
