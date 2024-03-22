using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject GameObject;
    [SerializeField] GameObject GameObject2;

    private void OnDisable()
    {
        GameObject.SetActive(true);
        if(GameObject2 != null)
        {
            GameObject2.SetActive(false);
        }
    }
}
