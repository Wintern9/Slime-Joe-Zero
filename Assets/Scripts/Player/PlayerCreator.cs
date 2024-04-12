using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += CreatPlayerIfNotExist;
    }

    [SerializeField] private GameObject Player;

    void CreatPlayerIfNotExist(Scene scene, LoadSceneMode mode)
    {
        try
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject gameObject = GameObject.FindGameObjectWithTag("CreatePlayer");
                Instantiate(Player, gameObject.transform);
                //Destroy(gameObject);
            }
        }
        catch {
            Debug.LogError("Не существует точки создания Игрока");
        }
    }
}
