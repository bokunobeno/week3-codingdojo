using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoard : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        audioSource.Play();
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        audioSource.Stop();
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            audioSource.Pause();
    }
}
