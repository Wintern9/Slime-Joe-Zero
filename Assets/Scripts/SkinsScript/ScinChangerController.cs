using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class ScinChanger : MonoBehaviour
{
    [SerializeField] private List<Sprite> ScinsMass;



    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Switch Scins");
        GameObject obj = GameObject.FindGameObjectWithTag("ScinSlime");
        if (obj != null)
        {
            SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();
            sprite.sprite = ScinsMass[Settings.ScinNumEquipped];
        }
    }

    public Sprite GetSprite()
    {
        return ScinsMass[Settings.ScinNum];
    }
}
