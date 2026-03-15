using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessAudio : MonoBehaviour
{

    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = (float) MenuManager.musicVolume;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        
        DontDestroyOnLoad(transform.gameObject);
        
        
    }
}
