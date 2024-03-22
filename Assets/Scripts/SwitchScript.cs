using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScript : MonoBehaviour
{
    [SerializeField] private GameObject CanvasEnebled;
    [SerializeField] private GameObject CanvasDisable;
    [SerializeField] private GameObject GameObjectEnabled;
    [SerializeField] private bool isPause;
    [SerializeField] private bool Disable;
    [SerializeField] private string SceneName;
    [SerializeField] private bool ThisScene;

    public void SwitchCanvas()
    {
        if (CanvasEnebled != null)
        {
            CanvasEnebled.SetActive(false);
        }
        if (CanvasDisable != null)
        {
            CanvasDisable.SetActive(true);
        }
       
        if (isPause && Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else if (isPause && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        if (Disable)
        {
            gameObject.SetActive(false);
            if (GameObjectEnabled != null)
            {
                GameObjectEnabled.SetActive(true);
            }
        }

    }
    public void SwitchScene()
    {
        if(ThisScene == true)
        {
            SceneName = SceneManager.GetActiveScene().name;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }

    public void DestroyObject()
    {
        gameObject.SetActive(false);
    }

    [SerializeField] private GameObject objectActivete;
    [SerializeField] private bool objectActivBool;

    public void ActiveObject()
    {
        objectActivete.SetActive(true);
        if (objectActivBool)
        {
            objectActivete.GetComponent<SwitchScript>().SceneName = this.SceneName;
        }
    }
}
