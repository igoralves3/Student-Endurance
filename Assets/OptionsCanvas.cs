using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvas : MonoBehaviour
{

    public Scrollbar musicBar;
    public Scrollbar soundBar;

    // Start is called before the first frame update
    void Start()
    {
        musicBar.onValueChanged.AddListener(ChangeMusicVolume);
        soundBar.onValueChanged.AddListener(ChangeSoundVolume);
    }

    // Update is called once per frame
    void Update()
    {
        musicBar.value = (float) MenuManager.musicVolume;
        soundBar.value = (float) MenuManager.soundVolume;
    }

    void ChangeMusicVolume(float value)
    {
        MenuManager.audioSource.volume = value;
        MenuManager.musicVolume = value;
    }

    void ChangeSoundVolume(float value)
    {
        MenuManager.soundVolume = value;
    }
}
