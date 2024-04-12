using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(Advertisement.isInitialized == true)
        {
            Debug.Log("Initialized");
            Interstitial inst = gameObject.GetComponent<Interstitial>();
            inst.LoadAd();
            inst.ShowAd();
        }
    }
}
