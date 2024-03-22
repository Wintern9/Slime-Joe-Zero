using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextVisualize : MonoBehaviour
{
    void Start()
    {
        Button parentButton = GetComponentInParent<Button>();
        if(parentButton.interactable == false)
        {
            gameObject.SetActive(false);
        }
        else
        {
            if(parentButton.interactable == true)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
