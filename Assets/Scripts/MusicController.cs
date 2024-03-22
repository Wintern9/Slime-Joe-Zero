using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private GameObject musicButtonOn;
    [SerializeField] private GameObject musicButtonOff;

    public void Update()
    {
        if (Settings.MusicPlaying == true)
        {
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
        else if (Settings.MusicPlaying == false)
        {
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
    }

    public void MusicOn()
    {
        Settings.MusicPlaying = true;
    }

    public void MusicOff()
    {
        Settings.MusicPlaying = false;
    }
}
