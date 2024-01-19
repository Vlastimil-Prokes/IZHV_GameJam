using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }


    }
}
