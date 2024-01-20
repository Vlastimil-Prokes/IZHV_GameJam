using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
    public AudioClip[] audioClip;
    public AudioSource audioSource;

    int i = 0;

    void PlaySound()
    {
        audioSource.PlayOneShot(audioClip[GameManager.IndicesOfSounds[GameManager.CorrectSerie[i]]]);
        i++;
    }

    void LoadS()
    {
        SceneManager.LoadScene("Game");
    }


    public void ContinueToGame()
    {
        Invoke("PlaySound", 2);
        Invoke("PlaySound", 3);
        Invoke("PlaySound", 4);
        Invoke("PlaySound", 5);
        Invoke("PlaySound", 6);
        Invoke("LoadS", 8);
    }
}
